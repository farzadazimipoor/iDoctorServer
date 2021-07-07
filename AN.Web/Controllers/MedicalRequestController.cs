using AN.BLL.Services.MedicalRequest;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class MedicalRequestController : AwroNoreController
    {
        private readonly IMedicalRequestService _medicalRequestService;
        public MedicalRequestController(IMedicalRequestService medicalRequestService)
        {
            _medicalRequestService = medicalRequestService;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new MedicalRequestListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var results = await _medicalRequestService.GetPagingListDataAsync(param);

                var offers = await Task.WhenAll(results.Items.Select(async (x) => new MedicalRequestListViewModel
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                    PersonName = x.PersonName,
                    PersonPhone = x.PersonPhone,
                    AttachmentsCount = x.AttachmentsCount,
                    RequestDate = x.RequestDate,
                    PersonPhoneHtml = await this.RenderViewToStringAsync("_MedicalRequestItemPersonPhone", x),
                    DocumentsHtml = await this.RenderViewToStringAsync("_MedicalRequestItemDocuments", x),
                    ActionsHtml = await this.RenderViewToStringAsync("_MedicalRequestItemActions", x)
                }).ToList());

                return new JsonResult(new DataTablesResult<MedicalRequestListViewModel>
                {
                    Draw = param.Draw,
                    Data = offers.ToList(),
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

        public async Task<IActionResult> Details(int id)
        {
            var result = await _medicalRequestService.GetMedicalRequestDetailsAsync(id);

            return PartialView(result);
        }
    }
}
