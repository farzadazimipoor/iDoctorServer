using AN.BLL.Services.Treatment;
using AN.Core.DTO.Treatment;
using AN.Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TreatmentsController : ANBaseApiController
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentsController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [HttpPost("{pageIndex:int}/{limit:int}", Name = "TreatmentsList")]
        [ProducesResponseType(typeof(TreatmentsResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DoctorsListPaging(int pageIndex, int limit)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var (totalCount, _, treatments) = await _treatmentService.GetTreatmentsListPagingAsync(CurrentUserName, RequestLang, pageIndex);

            var result = new TreatmentsResultDTO
            {
                TotalCount = totalCount,
                Treatments = treatments
            };

            return Ok(result);
        }

        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> GetTreatmentDetails(int id)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var details = await _treatmentService.GetTreatmentDetailsAsync(CurrentUserName, id, RequestLang);

            return Ok(details);
        }

        [HttpPost("attach/{id:int}")]
        public async Task<IActionResult> UploadAttachmentFile(int id, List<IFormFile> files)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            if (!files.Any()) throw new AwroNoreException("No file found to upload");

            var newAttachesUrl = await _treatmentService.SetNewAttachmentsAsync(files, id, CurrentUserName);

            return Ok(newAttachesUrl);
        }

        [HttpGet("attach/remove/{treatmentId:int}/{attachId:int}")]
        public async Task<IActionResult> RemoveTreatmentAttachment(int treatmentId, int attachId)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            await _treatmentService.RemoveTreatmentAttachmentAsync(treatmentId, attachId, CurrentUserName);

            return Ok();
        }
    }
}