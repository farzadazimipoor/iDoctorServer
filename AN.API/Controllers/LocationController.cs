using AN.BLL.DataRepository.Places;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.WebAPI.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class LocationController : AwroNoreBaseController
    {
        private readonly IPlaceService _placeService;
        public LocationController(IPlaceService placeService)
        {
            _placeService = placeService;
        }       

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _placeService.GetProvincesListAsync(RequestLang);

            return Ok(result);
        }

        [HttpGet("cities/{provinceId:int}")]
        public async Task<IActionResult> GetCities(int provinceId)
        {
            return Ok();
        }
    }
}