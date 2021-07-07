using AN.BLL.DataRepository.Polyclinics;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class RegisterRequestController : AwroNoreController
    {
        private readonly IShiftCenterService _shiftCenterService;
        public RegisterRequestController(IShiftCenterService shiftCenterService)
        {
            _shiftCenterService = shiftCenterService;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new RegisterRequestsListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<RegisterRequestsFilterViewModel>(param.FiltersObject);
              
                var results = await _shiftCenterService.GetRegistrationRequestsDataTableAsync(param, filtersModel, Lng);

                var requests = await Task.WhenAll(results.Items.Select(async (x) => new RegisterRequestsListViewModel
                {
                    Id = x.Id,
                    CreateDate = x.CreateDate,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Gender = x.Gender,
                    CenterName = x.CenterName,
                    CenterPhone = x.CenterPhone,      
                    CenterCity = x.CenterCity,
                    CenterType = x.CenterType,
                    Avatar = x.Avatar,
                    AvatarHtml = await this.RenderViewToStringAsync("_RegisterRequestPersonAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_RegisterRequestActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<RegisterRequestsListViewModel>
                {
                    Draw = param.Draw,
                    Data = requests.ToList(),
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

        public async Task<IActionResult> ApproveRequest(int id)
        {
            await _shiftCenterService.ApproveRegistrationRequestAsync(id);

            return new JsonResult(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeleteRegisterRequest(int id)
        {
            await _shiftCenterService.DeleteRegistrationRequestAsync(id);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });
        }
    }
}