using AN.BLL.Services.Offers;
using AN.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class OffersController : ANBaseApiController
    {
        private readonly IOffersService _offersService;
        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOffersCategories(int? cityId = null)
        {
            var result = await _offersService.GetOffersDataAsync(RequestLang, HostAddress, cityId: cityId);

            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetOffersByFilter([FromBody] OffersFilterDTO filters)
        {
            var result = await _offersService.GetOffersByCategoryAsync(RequestLang, HostAddress,filters);

            return Ok(result);
        }

        [HttpPost("{pageIndex:int}/{limit:int}", Name = "OffersList")]
        [ProducesResponseType(typeof(OffersResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OffersListPaging(int pageIndex, int limit, bool supportBasicOffers = false)
        {
            var (totalCount, _, offers) = await _offersService.GetOffersListAsync(RequestLang, HostAddress, pageIndex, supportBasicOffers: supportBasicOffers);

            var result = new OffersResultDTO
            {
                TotalCount = totalCount,
                Offers = offers
            };

            return Ok(result);
        }

        [HttpGet("timeperiods/{id:int}")]
        [ProducesResponseType(typeof(OfferTimePeriodsDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOfferTimePeriods(int id)
        {
            var result = await _offersService.GetOfferTimePeriodsAsync(id);

            return Ok(result);
        }
    }
}