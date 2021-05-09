using AN.BLL.DataRepository.Places;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class PlacesController : ANBaseApiController
    {
        private readonly IPlaceService _placeService;
        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _placeService.GetCountriesListAsync(RequestLang);

            return Ok(result);
        }
    }
}
