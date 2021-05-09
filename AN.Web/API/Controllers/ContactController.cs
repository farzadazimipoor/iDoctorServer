using AN.BLL.DataRepository.ContactUsRepo;
using AN.BLL.DataRepository.Persons;
using AN.Core.DTO;
using AN.Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]    
    public class ContactController : ANBaseApiController
    {
        private readonly IContactUsService _contactUsService;
        private readonly IPersonService _personService;
        public ContactController(IContactUsService contactUsService, IPersonService personService)
        {
            _contactUsService = contactUsService;
            _personService = personService;
        }

        [HttpPost("feedback")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostFeedBack([FromBody] FeedBackDTO model)
        {
            var person = await _personService.GetPersonByMobileAsync(CurrentUserName);

            if (person == null) throw new AwroNoreException("You are not a member of the system");

            await _contactUsService.InsertNewAsync(new Core.Domain.ContactUs
            {
                CreatedAt = DateTime.Now,
                Email = person.Email ?? "",
                Name = RequestLang == Core.Enums.Lang.KU ? person.FullName_Ku : RequestLang == Core.Enums.Lang.AR ? person.FullName_Ar : person.FullName,
                Topic = "App Feedback",
                Message = model.Comment,
                Mobile = person.Mobile
            });

            return Ok();
        }

        [HttpPost("feedback/web")]
        public async Task<IActionResult> PostFeedBackFromWeb([FromBody] WebFeedBackDTO model)
        {           
            await _contactUsService.InsertNewAsync(new Core.Domain.ContactUs
            {               
                Email = model.Email ?? "",
                Name = model.FullName ?? "",
                Topic = model.Topic ?? "Feedback From Web",
                Message = model.Comment ?? "",
                Mobile = model.Mobile ?? "",
                CreatedAt = DateTime.Now,
            });

            return Ok();
        }
    }
}