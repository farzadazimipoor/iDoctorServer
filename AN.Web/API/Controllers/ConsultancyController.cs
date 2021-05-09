using AN.BLL.Services;
using AN.Core.DTO.Consultancy;
using AN.Core.Enums;
using AN.Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class ConsultancyController : ANBaseApiController
    {
        private readonly IConsultancyService _consultancyService;
        public ConsultancyController(IConsultancyService consultancyService)
        {
            _consultancyService = consultancyService;
        }

        [HttpGet("topdoctors")]
        public async Task<IActionResult> GetTopConsultancyDoctors()
        {
            var result = await _consultancyService.GetTopConsultancyDoctorsAsync(RequestLang);

            return Ok(result);
        }

        [HttpGet("groups")]
        public async Task<IActionResult> GetConsultancyGroups()
        {
            var result = await _consultancyService.GetConsultancyGroupsAsync(RequestLang);

            return Ok(result);
        }

        [HttpGet("groupdoctors/{categoryId:int}/{pageIndex:int}/{limit:int}", Name = "ConsultancyGroupDoctors")]
        public async Task<IActionResult> GetConsultancyGroupDoctors(int categoryId, int pageIndex, int limit)
        {
            var result = await _consultancyService.GetConsultancyGroupDoctorsAsync(categoryId, RequestLang, page: pageIndex);

            return Ok(result);
        }

        // This is for when user is logged in
        [HttpGet("mygroupdoctors/{categoryId:int}/{pageIndex:int}/{limit:int}", Name = "MyConsultancyGroupDoctors")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMyConsultancyGroupDoctors(int categoryId, int pageIndex, int limit)
        {
            var result = await _consultancyService.GetConsultancyGroupDoctorsAsync(categoryId, RequestLang, page: pageIndex, userMobile: CurrentUserName);

            return Ok(result);
        }

        [HttpGet("details/user/{serviceSupplyId:int}", Name = "UserConsultancyDetails")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserConsultancyDetails(int serviceSupplyId)
        {
            var result = await _consultancyService.GetUserConsultancyDetailsAsync(CurrentUserName, serviceSupplyId, RequestLang);

            return Ok(result);
        }

        /// <summary>
        /// Get or create new consultancy with return all messages 
        /// </summary>
        /// <param name="serviceSupplyId">Id of consultant</param>
        /// <param name="chatId">Id of current consultancy if exist</param>
        /// <returns>Consultancy data with messages</returns>
        [HttpGet("getorcreate", Name = "ChatMessages")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetChatMessages([FromQuery] int serviceSupplyId, [FromQuery] int? chatId = null)
        {
            var result = await _consultancyService.GetOrCreateNewChatMessagesAsync(serviceSupplyId, CurrentUserName, RequestLang, chatId);

            return Ok(result);
        }

        [HttpPost("message/send", Name = "SendNewMessage")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SendNewMessage([FromBody] SendMessageDTO model)
        {
            if (model.Sender == ConsultancyMessageSender.CONSULTANT && !User.IsInRole("doctor")) throw new AwroNoreException("You can not send massage as consultant");

            model.Type = ConsultancyMessageType.TEXT;

            var result = await _consultancyService.SendConsultancyMessageAsync(model);

            return Ok(result);
        }

        [HttpPost("message/multimedia/send", Name = "SendNewMultiMediaMessage")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SendNewMultiMediaMessage(IFormFile file)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var consultancyId = Request.Form["ConsultancyId"];
            var personId = Request.Form["PersonId"];
            var serviceSupplyId = Request.Form["ServiceSupplyId"];
            var sender = (ConsultancyMessageSender)int.Parse(Request.Form["Sender"]);
            var messageType = (ConsultancyMessageType)int.Parse(Request.Form["MessageType"]);

            if (sender == ConsultancyMessageSender.CONSULTANT && !User.IsInRole("doctor")) throw new AwroNoreException("You can not send massage as consultant");

            var model = new SendMessageDTO
            {
                ConsultancyId = int.Parse(consultancyId),
                PersonId = int.Parse(personId),
                ServiceSupplyId = int.Parse(serviceSupplyId),
                Type = messageType,
                Sender = sender
            };

            var message = await _consultancyService.SendMultiMediaMessageAsync(model, file);

            return Ok(message);
        }

        [HttpPost("mychats/{pageIndex:int}/{limit:int}", Name = "MyChatsPagingList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> MyChatsPagingList([FromBody] MyChatsFilterModel filterModel, int pageIndex, int limit)
        {
            var result = await _consultancyService.GetMyChatsPagingListAsync(CurrentUserName, filterModel, RequestLang, pageIndex);

            return Ok(result);
        }

        [HttpPost("chats/{pageIndex:int}/{limit:int}", Name = "ConsultantChatsPagingList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<IActionResult> ConsultantChatsPagingList([FromBody] ConsultantChatsFilterModel filterModel, int pageIndex, int limit)
        {
            var result = await _consultancyService.GetConsultantChatsPagingListAsync(CurrentUserName, filterModel, RequestLang, pageIndex);

            return Ok(result);
        }

        [HttpGet("getdoctorchat", Name = "GetDoctorChat")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<IActionResult> GetDoctorChat([FromQuery] int chatId)
        {
            var result = await _consultancyService.GetDoctorConsultancyMessagesAsync(CurrentUserName, chatId, RequestLang);

            return Ok(result);
        }

        [HttpGet("manage/status", Name = "SetConsultancyStatusBydoctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<IActionResult> SetConsultancyStatusBydoctor([FromQuery] int chatId, [FromQuery] ConsultancyStatus status)
        {
            var result = await _consultancyService.SetConsultancyStatusAsync(CurrentUserName, chatId, status, RequestLang);

            return Ok(result);
        }

        [HttpGet("manage/remove", Name = "RemoveConsultancyBydoctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<IActionResult> RemoveConsultancyBydoctor([FromQuery] int chatId)
        {
            await _consultancyService.RemoveConsultancyAsync(chatId, CurrentUserName);

            return Ok();
        }
    }
}