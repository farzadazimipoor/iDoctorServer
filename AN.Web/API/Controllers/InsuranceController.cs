using AN.BLL.DataRepository.Insurances;
using AN.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class InsuranceController : ANBaseApiController
    {
        private readonly IInsuranceService _insuranceService;
        private readonly IInsuranceServiceService _insuranceServiceService;
        public InsuranceController(IInsuranceService insuranceService, IInsuranceServiceService insuranceServiceService)
        {
            _insuranceService = insuranceService;
            _insuranceServiceService = insuranceServiceService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetInsurances([FromQuery] int? cityId = null)
        {
            var result = await _insuranceService.GetInsurancesAsync(RequestLang, HostAddress, cityId);

            return Ok(result);
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetInsuranceServices([FromQuery] int insuranceId)
        {
            var result = await _insuranceServiceService.GetInsuranceServicesAsync(insuranceId, RequestLang, HostAddress);

            return Ok(result);
        }
    }
}
