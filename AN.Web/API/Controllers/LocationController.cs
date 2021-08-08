using AN.BLL.Services.Location;
using AN.Core.DTO.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class LocationController : ANBaseApiController
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost("nearby/{x_longitude:double}/{y_latitude:double}")]
        public IActionResult GetNearByShiftCenters(double x_longitude, double y_latitude, [FromBody]DoctorFilterDTO filterModel, [FromQuery]double radiusMeters = 1000) // x Meters Nearby Me
        {
            var locations = _locationService.GetNearbyShiftCenters(x_longitude, y_latitude, filterModel, radiusMeters, RequestLang);

            return Ok(locations);
        }
    }
}