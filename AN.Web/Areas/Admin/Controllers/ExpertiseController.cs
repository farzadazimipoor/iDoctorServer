using AN.BLL.DataRepository.Expertises;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.Admin.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Http;
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
    public class ExpertiseController : AdminController
    {
        #region Ctor
        private readonly IExpertiseService _expertiseService;
        private readonly ICommonUtils _commonUtils;
        public ExpertiseController(IExpertiseService expertiseService, ICommonUtils commonUtils)
        {
            _expertiseService = expertiseService;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Tabs
        public IActionResult Tabs()
        {
            ViewBag.Lang = Lng;

            return View();
        }

        [HttpGet]
        public IActionResult CategoriesTab()
        {
            ViewBag.Lang = Lng;

            var expertiseCats = _expertiseService.GetAllExpertiseCategories().Select(x => new ExpertiseCategoryViewModel
            {
                Id = x.Id,
                Name = Lng == Lang.AR ? x.Name_Ar : Lng == Lang.KU ? x.Name_Ku : x.Name,
                Description = Lng == Lang.AR ? x.Description_Ar : Lng == Lang.KU ? x.Description_Ku : x.Description
            }).OrderBy(x => x.Name).ToList();

            return PartialView(expertiseCats);
        }

        public async Task<IActionResult> ExpertisesTab()
        {
            ViewBag.Lang = Lng;

            ViewBag.ExpertiseCategories = await _expertiseService.GetCatrgoriesSelectListAsync(Lng);

            return PartialView(new ExpertiseListViewModel());
        }

        #endregion

        #region Expertises       
        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(DataTablesParameters), JsonConvert.SerializeObject(param));

                var filtersModel = JsonConvert.DeserializeObject<ExpertiseFilterViewModel>(param.FiltersObject);

                var results = await _expertiseService.GetDataTableAsync(param, filtersModel, Lng);

                var expertises = await Task.WhenAll(results.Items.Select(async (x) => new ExpertiseListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    ActionsHtml = await this.RenderViewToStringAsync("_ExpertiseItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<ExpertiseListViewModel>
                {
                    Draw = param.Draw,
                    Data = expertises.ToList(),
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
            ViewBag.ExpertiseCategories = await _expertiseService.GetCatrgoriesSelectListAsync(Lng);

            var model = new ExpertiseCreateUpdateViewModel
            {
                Id = id,
            };

            if (id != null)
            {
                var expertise = await _expertiseService.GetByIdAsync(id.Value);

                if (expertise == null) throw new Exception("Expertise Not Found");

                model = new ExpertiseCreateUpdateViewModel
                {
                    Id = expertise.Id,
                    Name = expertise.Name,
                    Name_Ku = expertise.Name_Ku,
                    Name_Ar = expertise.Name_Ar,
                    Description = expertise.Description,
                    Description_Ku = expertise.Description_Ku,
                    Description_Ar = expertise.Description_Ar,
                    CategoryId = expertise.ExpertiseCategoryId
                };
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(ExpertiseCreateUpdateViewModel model)
        {
            string message;

            if (model.Id != null)
            {
                var expertise = await _expertiseService.GetByIdAsync(model.Id.Value);

                if (expertise == null) throw new Exception("Expertise Not Found");

                expertise.Name = model.Name;
                expertise.Name_Ku = model.Name_Ku;
                expertise.Name_Ar = model.Name_Ar;
                expertise.ExpertiseCategoryId = model.CategoryId;
                expertise.Description = model.Description;
                expertise.Description_Ar = model.Description_Ar;
                expertise.Description_Ku = model.Description_Ku;

                _expertiseService.UpdateExpertise(expertise);

                message = Messages.ItemUpdatedSuccessFully;
            }
            else
            {
                var expertise = new Expertise
                {
                    Name = model.Name,
                    Name_Ku = model.Name_Ku,
                    Name_Ar = model.Name_Ar,
                    ExpertiseCategoryId = model.CategoryId,
                    Description = model.Description,
                    Description_Ku = model.Description_Ku,
                    Description_Ar = model.Description_Ar,
                    CreatedAt = DateTime.Now
                };

                _expertiseService.InsertExpertise(expertise);

                message = Messages.ItemAddedSuccessFully;
            }

            return Json(new { success = true, message });
        }

        public async Task<IActionResult> Delete(int id)
        {
            string message = Messages.AnErrorOccuredWhileDeleteItem;
            bool success = false;
            try
            {
                var expertise = await _expertiseService.GetByIdAsync(id);

                if (expertise != null) _expertiseService.DeleteExpertise(expertise);

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

        #region Categories              
        public IActionResult CreateUpdateExpertiseCategory(int? id)
        {
            var model = new ExpertiseCategoryViewModel();

            if(id != null)
            {
                var expertiseCat = _expertiseService.GetExpertiseCategoryById((int)id);

                if (expertiseCat == null) throw new AwroNoreException("Expertise Category Not Found");

                model = new ExpertiseCategoryViewModel
                {
                    Id = expertiseCat.Id,
                    Name = expertiseCat.Name,
                    Name_Ku = expertiseCat.Name_Ku,
                    Name_Ar = expertiseCat.Name_Ar,
                    Description = expertiseCat.Description,
                    Description_Ku = expertiseCat.Description_Ku,
                    Description_Ar = expertiseCat.Description_Ar
                };
            }
            
            return PartialView(model);
        }

        [HttpPost]       
        public IActionResult CreateUpdateExpertiseCategory(ExpertiseCategoryViewModel model)
        {
            var message = model.Id != null ? Messages.ItemUpdatedSuccessFully : Messages.ItemAddedSuccessFully;

            if(model.Id != null)
            {
                var expertiseCat = _expertiseService.GetExpertiseCategoryById(model.Id.Value);

                expertiseCat.Name = model.Name;
                expertiseCat.Name_Ku = model.Name_Ku;
                expertiseCat.Name_Ar = model.Name_Ar;
                expertiseCat.Description = model.Description;
                expertiseCat.Description_Ku = model.Description_Ku;
                expertiseCat.Description_Ar = model.Description_Ar;

                _expertiseService.UpdateExpertiseCategory(expertiseCat);
            }
            else
            {
                _expertiseService.InsertExpertiseCategory(new ExpertiseCategory
                {
                    Name = model.Name,
                    Name_Ku = model.Name_Ku,
                    Name_Ar = model.Name_Ar,
                    Description = model.Description,
                    Description_Ku = model.Description_Ku,
                    Description_Ar = model.Description_Ar
                });
            }

            return Json(new { success = true, message });
        }             

        public IActionResult DeleteExpertiseCategory(int? id)
        {
            var expertiseCat = _expertiseService.GetExpertiseCategoryById((int)id);

           if(expertiseCat != null)
            {
                _expertiseService.DeleteExpertiseCategory(expertiseCat);
            }

            return Json(new { success = true, message = Messages.ItemDeletedSuccessFully });
        }
        #endregion
    }
}