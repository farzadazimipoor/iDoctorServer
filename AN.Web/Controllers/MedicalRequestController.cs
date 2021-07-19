using AN.BLL.Services;
using AN.BLL.Services.MedicalRequest;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class MedicalRequestController : AwroNoreController
    {
        private readonly IMedicalRequestService _medicalRequestService;
        private readonly IAttachmentService _attachmentService;
        public MedicalRequestController(IMedicalRequestService medicalRequestService, IAttachmentService attachmentService)
        {
            _medicalRequestService = medicalRequestService;
            _attachmentService = attachmentService;
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
            var result = await _medicalRequestService.GetMedicalRequestDetailsAsync(id, HostAddress);

            return PartialView(result);
        }


        public async Task<PhysicalFileResult> DownloadAttachment(int attachId)
        {
            var attach = await _attachmentService.GetByIdAsync(attachId);

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var fullFilePath = Path.Combine(basePath, attach.Url.Replace('/', '\\'));

            if (!System.IO.File.Exists(fullFilePath))
            {
                throw new AwroNoreException("File not found");
            }

            var mimeType = GetMimeType(fullFilePath);

            return new PhysicalFileResult(fullFilePath, mimeType);
        }

        private string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
