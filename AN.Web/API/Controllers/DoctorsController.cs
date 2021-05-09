using AN.BLL.DataRepository.Persons;
using AN.BLL.Services.Doctors;
using AN.Core.DTO;
using AN.Core.DTO.Doctors;
using AN.Core.DTO.Rating;
using AN.Core.Exceptions;
using AN.Core.Resources.New;
using AN.Web.AppCode;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class DoctorsController : ANBaseApiController
    {
        private readonly IDoctorsService _doctorsService;
        private readonly IPersonService _userService;
        public DoctorsController(IDoctorsService doctorsService, IPersonService userService)
        {
            _doctorsService = doctorsService;
            _userService = userService;
        }

        [HttpGet("schedules/{id:int}", Name = "DoctorSchedules")]
        public async Task<IActionResult> GetDoctorSchedules([FromRoute]int id)
        {
            var result = await _doctorsService.GetSchedulesAsync(id, RequestLang);

            return Ok(result);
        }

        [HttpGet("centertypes", Name = "CenterTypesList")]
        public async Task<IActionResult> GetSupportAppointmentsCenterTypes()
        {
            var result = await _doctorsService.GetSupportAppointmentsCenterTypesAsync(HostAddress);

            return Ok(result);
        }

        [HttpGet("center/services/{id:int}", Name = "GetDoctorCenterServices")]
        public async Task<IActionResult> GetCenterServicesList([FromRoute] int id)
        {
            var result = await _doctorsService.GetCenterServicesAsync(id, RequestLang);

            return Ok(result);
        }

        [HttpPost("{pageIndex:int}/{limit:int}", Name = "DoctorsList")]
        [ProducesResponseType(typeof(DoctorsResultDTO), (int)HttpStatusCode.OK)]
        [TypeFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> DoctorsListPaging([FromBody] DoctorFilterDTO filterModel, int pageIndex, int limit)
        {
            var (totalCount, _, doctors) = await _doctorsService.GetDoctorsListPagingAsync(filterModel, RequestLang, HostAddress, pageIndex);

            var result = new DoctorsResultDTO
            {
                TotalCount = totalCount,
                Doctors = doctors
            };

            return Ok(result);
        }

        [HttpPost("favorites", Name = "FavoriteDoctorsList")]
        [ProducesResponseType(typeof(DoctorsResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFavoriateDoctorsList([FromBody] FavoriatesDTO model)
        {
            var result = await _doctorsService.GetFavoriateDoctorsAsync(model, RequestLang, "");

            return Ok(result);
        }

        [HttpGet("reservationtype/{id:int}")]
        public async Task<IActionResult> GetDoctorReservationType(int id)
        {
            var result = await _doctorsService.GetReservationTypeAsync(id);

            return Ok(result);
        }

        [HttpGet("details/{id:int}")]
        [ProducesResponseType(typeof(DoctorDetailsDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDoctorDetails(int id, [FromQuery] int? centerServiceId = null, [FromQuery] int? offerId = null)
        {
            var details = await _doctorsService.GetDoctorDetailsAsync(id, RequestLang, centerServiceId, offerId:offerId);

            return Ok(details);
        }

        [HttpGet("gallery/{id:int}")]
        public async Task<IActionResult> GetDoctorPhotosGallery(int id)
        {
            var photos = await _doctorsService.GetDoctorsPhotosGallery(id, RequestLang);

            return Ok(photos);
        }

        [HttpGet("reservationstatus/{id:int}/{serviceId:int}")]
        [ProducesResponseType(typeof(DoctorReservationStatusDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDoctorReservationStatus(int id, int serviceId)
        {
            var result = await _doctorsService.GetDoctorReservationStatusAsync(id, serviceId);

            return Ok(result);
        }

        [HttpGet("bookableturns/{id:int}/{serviceId:int}/{date}")]
        [ProducesResponseType(typeof(DateBookableTurnsDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBookableTurnsForDate(int id, int serviceId, string date)
        {
            var result = await _doctorsService.GetBookableTurnsForDateAsync(id, serviceId, date);

            return Ok(result);
        }

        [HttpGet("rate/{id:int}/{averageRating:double}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Rate(int id, double averageRating, [FromQuery] int? appointmentId = null)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            // Get Current UserId Here (From Token)
            var user = await _userService.GetPersonByMobileAsync(CurrentUserName);

            if (user == null) throw new AwroNoreException(NewResource.UserNotFound);

            var rateModel = new RatingDTO
            {
                UserId = user.Id,
                ServiceSupplyId = id,
                AppointmentId = appointmentId,
                AverageRating = averageRating
            };

            await _doctorsService.RateDoctorAsync(rateModel);

            return Ok();
        }

        // TEMPORARY API
        [HttpGet("xyz")]
        public async Task<IActionResult> UpdateSecretaryPhones()
        {
            await _doctorsService.UpdateSecretaryPhonesAsync();

            return Ok();
        }
    }
}