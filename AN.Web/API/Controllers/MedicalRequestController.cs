using AN.BLL.Services.MedicalRequest;
using AN.Core.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicalRequestController : ANBaseApiController
    {
        private readonly IMedicalRequestService _medicalRequestService;
        private static Logger _logger;
        public MedicalRequestController(IMedicalRequestService medicalRequestService)
        {
            _medicalRequestService = medicalRequestService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpPost("create", Name = "CreateNewMedicalRequest")]
        public async Task<IActionResult> CreateNewMedicalRequest(List<IFormFile> files)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var formData = Request.Form["FormData"];

            var formModel = JsonConvert.DeserializeObject<MedicalRequestBaseFormDTO>(formData);

            var model = new MedicalRequestDTO
            {
                Date = formModel.Date,
                Note = formModel.Note,
                CountryId = formModel.CountryId,
                Files = files
            };

            _logger.Info($"{model.Files.Count} files uploaded. Country id is {model.CountryId}");

            await _medicalRequestService.CreateNewMedicalRequestAsync(CurrentUserName, model);

            return Ok();
        }
    }
}
