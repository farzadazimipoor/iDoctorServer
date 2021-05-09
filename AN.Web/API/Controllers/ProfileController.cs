using AN.BLL.Services.Profile;
using AN.Core.DTO.Profile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ANBaseApiController
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserProfileStatus([FromQuery] string fcmToken)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var result = await _profileService.GetUserProfileStatusAsync(CurrentUserName, fcmToken);

            result.IsDoctor = User.IsInRole("doctor");

            return Ok(result);
        }

        [HttpPost("crud")]
        public async Task<IActionResult> CreateOrUpdateUser([FromBody] ProfileCRUDDTO profile)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            if (!CurrentUserName.Equals(profile.Mobile)) return Unauthorized();

            profile.IdentityUserId = IdentityUserId;

            profile.Username = CurrentUserName;

            var result = await _profileService.CreateOrUpdateUserProfileAsync(profile);

            result.IsDoctor = User.IsInRole("doctor");

            return Ok(result);
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetProfileDataForUpdate()
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var result = await _profileService.GetUserProfileDataAsync(CurrentUserName);

            return Ok(result);
        }

        [HttpPost("avatar/upload")]
        public async Task<IActionResult> UploadProfileAvatar(IFormFile file)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var newAvatar = await _profileService.UpdateProfileAvatarAsync(CurrentUserName, file);

            return Ok(newAvatar);
        }

        [HttpGet("avatar/remove")]
        public async Task<IActionResult> RemoveProfileAvatar()
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var newAvatar = await _profileService.RemoveProfileAvatarAsync(CurrentUserName);

            return Ok(newAvatar);
        }

        [HttpGet("logout", Name = "LogOutUserFromDevice")]
        public async Task<IActionResult> LogOut([FromQuery] string fcmInstanceId)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            await _profileService.LogoutPersonFromDeviceAsync(CurrentUserName, fcmInstanceId);

            return Ok();
        }

        [HttpGet("form")]
        public async Task<IActionResult> DiseaseRecordsForm()
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var result = await _profileService.GetDiseaseRecordsFormAsync(CurrentUserName);

            return Ok(result);
        }

        [HttpPost("form/update")]
        public async Task<IActionResult> UpdateDiseaseRecordsForm([FromBody] DiseaseRecordsFormDTO form)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            await _profileService.UpdateDiseaseRecordsFormAsync(CurrentUserName, form);

            return Ok();
        }
    }
}