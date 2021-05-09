using AN.BLL.DataRepository.HealthServices;
using AN.BLL.Services.Upload;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    /// <summary>
    /// Health Services & Categories Controller
    /// </summary>
    public class ServiceController : CpanelBaseController
    {
        #region Service
        private readonly IWorkContext _workContext;
        private readonly IServicesService _servicesService;
        private readonly IUploadService _uploadService;
        private readonly BanobatDbContext _dbContext;
        public ServiceController(IWorkContext workContext, IServicesService servicesService, IUploadService uploadService, BanobatDbContext dbContext) : base(workContext)
        {
            _workContext = workContext;
            _servicesService = servicesService;
            _uploadService = uploadService;
            _dbContext = dbContext;
        }
        #endregion

        #region List
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            var services = await _servicesService.GetServicePagingDataAsync(Lng);

            return View(services);
        } 
        #endregion

        #region Service
        public async Task<IActionResult> CreateUpdate(int? id)
        {
            var model = new ServiceViewModel();

            if (id != null)
            {
                model = await _servicesService.GetServiceForCRUD(id.Value);
            }

            ViewBag.Categories = await _servicesService.GetServiceCategoriesSelectListAsync(Lng);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(ServiceViewModel model)
        {
            var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

            decimal.TryParse(model.Price, out decimal price);

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var service = await _dbContext.Services.FindAsync(model.Id);

                        if (service == null) throw new AwroNoreException("Service Not Found");

                        service.Name = model.Name;
                        service.Name_Ar = model.Name_Ar;
                        service.Name_Ku = model.Name_Ku;
                        service.Description = model.Description;
                        service.Description_Ku = model.Description_Ku;
                        service.Description_Ar = model.Description_Ar;
                        service.Price = price;
                        service.Time = model.Time;
                        service.ServiceCategoryId = model.ServiceCategoryId;
                        service.UpdatedAt = DateTime.Now;

                        _dbContext.Services.Attach(service);

                        _dbContext.Entry(service).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var service = new Service
                        {
                            Name = model.Name,
                            Name_Ku = model.Name_Ku,
                            Name_Ar = model.Name_Ar,
                            Description = model.Description,
                            Description_Ar = model.Description_Ar,
                            Description_Ku = model.Description_Ku,
                            ServiceCategoryId = model.ServiceCategoryId,
                            Price = price,
                            Time = model.Time,
                            CreatedAt = DateTime.Now,
                        };

                        await _dbContext.Services.AddAsync(service);

                        await _dbContext.SaveChangesAsync();
                    }

                    transaction.Commit();

                }
            });

            return Json(new { success = true, message });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _dbContext.Services.FindAsync(id);

            if (service != null)
            {
                _dbContext.Services.Remove(service);

                await _dbContext.SaveChangesAsync();
            }

            return Json(new { success = true, message = Messages.ItemDeletedSuccessFully });
        } 
        #endregion

        #region Category
        public async Task<IActionResult> CreateUpdateCategory(int? id)
        {
            var model = new ServiceCategoryViewModel();

            if (id != null)
            {
                model = await _servicesService.GetServiceCategoryForCRUD(id.Value);

                if (!string.IsNullOrEmpty(model.Photo))
                {
                    ViewBag.AvatarPreview = "<img src=" + model.Photo + " alt=\"Avatar\">";
                }
            }

            ViewBag.ShiftCenterTypes = MyEnumExtensions.EnumToSelectList<ShiftCenterType>().ToList();

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateCategory(ServiceCategoryViewModel model)
        {
            var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var group = await _dbContext.ServiceCategories.FindAsync(model.Id);

                        if (group == null) throw new AwroNoreException("Service Category Not Found");

                        group.Name = model.Name;
                        group.Name_Ar = model.Name_Ar;
                        group.Name_Ku = model.Name_Ku;
                        group.CenterType = model.CenterType;
                        group.UpdatedAt = DateTime.Now;

                        _dbContext.ServiceCategories.Attach(group);

                        _dbContext.Entry(group).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        if (model.ImageUpload != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateServiceCategoryLogoName(group.Id, model.ImageUpload);

                            group.Photo = $"{baseUrl}/{thumbName}";

                            _dbContext.ServiceCategories.Attach(group);

                            _dbContext.Entry(group).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadServiceCategoryLogoAsync(model.ImageUpload, dirPath, newName, thumbName);
                        }                       
                    }
                    else
                    {
                        var group = new ServiceCategory
                        {
                            Name = model.Name,
                            Name_Ku = model.Name_Ku,
                            Name_Ar = model.Name_Ar,
                            CenterType = model.CenterType,
                            CreatedAt = DateTime.Now,
                        };

                        await _dbContext.ServiceCategories.AddAsync(group);

                        await _dbContext.SaveChangesAsync();

                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateServiceCategoryLogoName(group.Id, model.ImageUpload);

                        group.Photo = $"{baseUrl}/{thumbName}";

                        _dbContext.ServiceCategories.Attach(group);

                        _dbContext.Entry(group).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadServiceCategoryLogoAsync(model.ImageUpload, dirPath, newName, thumbName);                        
                    }

                    transaction.Commit();
                }
            });

            return Json(new { success = true, message });
        }

        public async Task<IActionResult> DeleteServiceCategory(int id)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var group = await _dbContext.ServiceCategories.FindAsync(id);

                    if (group != null)
                    {
                        _dbContext.ServiceCategories.Remove(group);

                        await _dbContext.SaveChangesAsync();

                        _uploadService.RemoveServiceCategoryLogo(id);
                    }

                    transaction.Commit();
                }
            });

            return Json(new { success = true, message = Messages.ItemDeletedSuccessFully });
        }
        #endregion
    }
}
