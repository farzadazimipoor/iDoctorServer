using AN.BLL.DataRepository.Insurances;
using AN.BLL.Services;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class InsuranceController : AdminController
    {
        private readonly IInsuranceService _insuranceService;       
        private readonly IAttachmentService _attachmentService;       
        private readonly IInsuranceServiceService _insuranceServiceService;       
        public InsuranceController(IInsuranceService insuranceService, IAttachmentService attachmentService, IInsuranceServiceService insuranceServiceService)
        {
            _insuranceService = insuranceService;
            _attachmentService = attachmentService;
            _insuranceServiceService = insuranceServiceService;
        }

        #region Insurance
        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new InsuranceListItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<InsuranceFilterViewModel>(param.FiltersObject);

                var results = await _insuranceService.GetDataTableAsync(param, filtersModel, Lng);

                var insurances = await Task.WhenAll(results.Items.Select(async (x) => new InsuranceListItemViewModel
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Logo = x.Logo,
                    Name = x.Name,
                    LogoHtml = await this.RenderViewToStringAsync("_InsuranceItemLogo", x.Logo),
                    ActionsHtml = await this.RenderViewToStringAsync("_InsuranceItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<InsuranceListItemViewModel>
                {
                    Draw = param.Draw,
                    Data = insurances.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id = null)
        {
            var model = new InsuranceCRUDViewModel
            {
                Id = id,
            };

            if (id != null)
            {
                var insurance = await _insuranceService.GetByIdAsync(id.Value);

                if (insurance == null) throw new Exception("Insurance Not Found");

                if (!string.IsNullOrEmpty(insurance.Logo))
                {
                    ViewBag.AvatarPreview = "<img src=" + insurance.Logo + " alt=\"Logo\">";
                }

                model = new InsuranceCRUDViewModel
                {
                    Id = insurance.Id,
                    Name = insurance.Name,
                    Name_Ar = insurance.Name_Ar,
                    Name_Ku = insurance.Name_Ku,
                    Description = insurance.Description,
                    Description_Ar = insurance.Description_Ar,
                    Description_Ku = insurance.Description_Ku
                };
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(InsuranceCRUDViewModel model)
        {
            try
            {
                await _insuranceService.CreateUpdateInsuranceAsync(model);

                var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

                return Json(new { success = true, message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            string message = Messages.AnErrorOccuredWhileDeleteItem;

            bool success = false;
            try
            {
                await _insuranceService.DeleteInsuranceAsync(id);
                message = Messages.ItemDeletedSuccessFully;
                success = true;
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        message = Core.Resources.UI.AdminPanel.PanelResource.ItemIsUsedYouCannotDeleteIt;
                    }
                }
            }
            catch
            {
                message = Messages.AnErrorOccuredWhileDeleteItem;
            }

            return Json(new { success, message });
        }
        #endregion

        #region Insurance Services
        public async Task<IActionResult> InsuranceServices()
        {
            ViewBag.Lang = Lng;

            ViewBag.Insurances = await _insuranceService.GetSelectListItemsAsync(Lng);

            return View(new InsuranceServiceListItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadInsuranceServicesTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<InsuranceServiceFilterViewModel>(param.FiltersObject);

                var results = await _insuranceServiceService.GetDataTableAsync(param, filtersModel, Lng);

                var insurances = await Task.WhenAll(results.Items.Select(async (x) => new InsuranceServiceListItemViewModel
                {
                    Id = x.Id,    
                    CreateDate = x.CreateDate,
                    Insurance = x.Insurance,
                    Summary = x.Summary,
                    Title = x.Title,
                    PhotoUrl = x.PhotoUrl,                   
                    PhotoHtml = await this.RenderViewToStringAsync("_InsuranceServiceItemPhoto", x.PhotoUrl),
                    ActionsHtml = await this.RenderViewToStringAsync("_InsuranceServiceItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<InsuranceServiceListItemViewModel>
                {
                    Draw = param.Draw,
                    Data = insurances.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdateInsuranceService(int? id = null)
        {
            ViewBag.Insurances = await _insuranceService.GetSelectListItemsAsync(Lng);

            var model = new InsuranceServiceCRUDViewModel
            {
                Id = id,
            };

            if (id != null)
            {
                var insurance = await _insuranceServiceService.GetByIdAsync(id.Value);

                if (insurance == null) throw new Exception("Insurance Service Not Found");

                if (!string.IsNullOrEmpty(insurance.Photo))
                {
                    ViewBag.AvatarPreview = "<img src=" + insurance.Photo + " alt=\"Logo\">";
                }

                model = new InsuranceServiceCRUDViewModel
                {
                    Id = insurance.Id,
                    Title = insurance.Title,
                    Title_Ar = insurance.Title_Ar,
                    Title_Ku = insurance.Title_Ku,
                    Summary = insurance.Summary,
                    Summary_Ar = insurance.Summary_Ar,
                    Summary_Ku = insurance.Summary_Ku,
                    Description = insurance.Description,
                    Description_Ar = insurance.Description_Ar,
                    Description_Ku = insurance.Description_Ku
                };
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdateInsuranceService(InsuranceServiceCRUDViewModel model)
        {
            try
            {
                await _insuranceServiceService.CreateUpdateInsuranceServiceAsync(model);

                var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

                return Json(new { success = true, message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> DeleteInsuranceService(int id)
        {
            string message = Messages.AnErrorOccuredWhileDeleteItem;

            bool success = false;
            try
            {
                await _insuranceServiceService.DeleteInsuranceServiceAsync(id);
                message = Messages.ItemDeletedSuccessFully;
                success = true;
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        message = Core.Resources.UI.AdminPanel.PanelResource.ItemIsUsedYouCannotDeleteIt;
                    }
                }
            }
            catch
            {
                message = Messages.AnErrorOccuredWhileDeleteItem;
            }

            return Json(new { success, message });
        }

        public async Task<IActionResult> InsuranceServiceAttachments(int id)
        {
            ViewBag.InsuranceServiceId = id;

            var attaches = await _attachmentService.GetAttachmentsAsync(FileOwner.INSURANCE_DOCUMENT, id);

            var attachments = attaches.Select(x => new InsuranceServiceAttachmentViewModel
            {
                Id = x.Id,
                name = x.Name,
                url = x.Url,
                thumbnailUrl = x.ThumbnailUrl,
                deleteType = "POST",
                deleteUrl = x.DeleteUrl,
                size = x.Size,
                InsuranceServiceId = id,
                CreatedAt = x.CreatedAt
            }).ToList();

            return PartialView(attachments);
        }
        #endregion
    }
}