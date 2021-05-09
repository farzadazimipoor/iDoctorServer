using AN.BLL.Services;
using AN.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class HealthBankController : ANBaseApiController
    {
        private readonly IHealthBankService _healthBankService;
        public HealthBankController(IHealthBankService healthBankService)
        {
            _healthBankService = healthBankService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetHealthBankCategories([FromQuery] int? cityId = null)
        {
            var result = await _healthBankService.GetHealthBankCategoriesAsync(RequestLang, HostAddress, cityId);

            return Ok(result);
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetHealthBankItems([FromQuery] HealthBankCategoryType type,
                                                            [FromQuery] int pageIndex,
                                                            [FromQuery] int? pageSize = null,
                                                            [FromQuery] ShiftCenterType? centerType = null,
                                                            [FromQuery] string filterString = "",
                                                            [FromQuery] int? cityId = null)
        {
            var result = await _healthBankService.GetHelathBankItemsAsync(type, RequestLang, HostAddress, centerType, cityId, filterString, pageIndex, pageSize: pageSize ?? 12);

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetHealthBankItemDetails([FromQuery] HealthBankCategoryType type, [FromQuery] int id)
        {
            var result = await _healthBankService.GetHealthBankItemDetailAsync(type, RequestLang, HostAddress, id);

            return Ok(result);
        }
    }
}
