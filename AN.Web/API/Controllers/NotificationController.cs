using AN.BLL.DataRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class NotificationController : ANBaseApiController
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("me/{pageIndex:int}/{limit:int}")]
        public async Task<IActionResult> MyNotifications(int pageIndex, int limit)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var result = await _notificationRepository.GetMyNotifications(RequestLang, CurrentUserName);

            Response.Headers.Add("ServerTime", JsonConvert.SerializeObject(DateTime.Now));

            return Ok(result);
        }

        [HttpGet("public/{pageIndex:int}/{limit:int}")]
        public async Task<IActionResult> PublicNotifications(int pageIndex, int limit)
        {
            var result = await _notificationRepository.GetMyNotifications(RequestLang);

            Response.Headers.Add("ServerTime", JsonConvert.SerializeObject(DateTime.Now));

            return Ok(result);
        }
    }
}