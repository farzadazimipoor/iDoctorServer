using AN.BLL.Services.Filters;
using AN.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.Settings;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class FiltersController : ANBaseApiController
    {
        private readonly IFiltersService _filtersService;
        private readonly IOptions<AppSettings> _options;
        public FiltersController(IFiltersService filtersService, IOptions<AppSettings> options)
        {
            _filtersService = filtersService;
            _options = options;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(FilterDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFiltersData()
        {
            var result = await _filtersService.GetFilterDataAsync(RequestLang);

            return Ok(result);
        }

        [HttpGet("services")]
        [ProducesResponseType(typeof(ServicesFilterDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetServicesFiltersData()
        {
            var result = await _filtersService.GetServicesFilterDataAsync(RequestLang);

            var disclamer = _options.Value.AwroNoreSettings.ConsultancyDisclamer;

            result.ConsultancyDisclaimer = RequestLang == Core.Enums.Lang.KU ? disclamer.DisclamerKu : RequestLang == Core.Enums.Lang.AR ? disclamer.DisclamerAr : disclamer.Disclamer;

            return Ok(result);
        }       
    }
}