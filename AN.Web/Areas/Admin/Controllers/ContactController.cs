using AN.BLL.DataRepository.ContactUsRepo;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.Admin.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{

    public class ContactController : AdminController
    {
        private readonly IContactUsService _contactUsService;
        public ContactController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]      
        public IActionResult Index()
        {
            var result = _contactUsService.GetAll()
                .Where(x => !x.IsArchived)
                .Select(x => new ContactViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Topic = x.Topic,
                    IsUnread = x.IsUnread
                }).OrderByDescending(x => x.IsUnread);

            return View(result.ToList());
        }

        [HttpGet]      
        public IActionResult New()
        {
            var result = _contactUsService.GetAll()
                        .Where(x => x.IsUnread && !x.IsArchived)
                        .Select(x => new ContactViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Topic = x.Topic,
                            IsUnread = x.IsUnread
                        });

            return View(result.ToList());
        }

        public async Task<IActionResult> Read(int id)
        {
            var message = await _contactUsService.GetByIAsync(id);

            if (message == null) throw new System.Exception("Message Not Found");

            if (message.IsUnread)
            {
                await _contactUsService.ReadAsync(id);
            }

            var model = new ContactReadModel
            {
                Email = message.Email,
                IsArchived = message.IsArchived,
                IsUnread = false,
                Message = message.Message,
                Mobile = message.Mobile,
                Name = message.Name,
                Topic = message.Topic
            };

            return PartialView(model);
        }

        public async Task<IActionResult> Archive(int id)
        {
            await _contactUsService.ArchiveAsync(id);

            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = "Message Archived Successfully" });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _contactUsService.DeleteAsync(id);

            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = "Message Deleted Successfully" });

            return RedirectToAction("Index");
        }
    }
}