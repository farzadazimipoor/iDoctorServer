using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "rootadmin")]
    public class ConsultancyController : AdminController
    {
        private readonly IConsultancyRepository _consultancyRepository;
        private readonly IPersonService _personService;
        private readonly IServiceSupplyService _serviceSupplyService;
        public ConsultancyController(IConsultancyRepository consultancyRepository, IPersonService personService, IServiceSupplyService serviceSupplyService)
        {
            _consultancyRepository = consultancyRepository;
            _personService = personService;
            _serviceSupplyService = serviceSupplyService;
        }

        public async Task<IActionResult> Chats()
        {
            ViewBag.Lang = Lng;

            ViewBag.PersonsList = await GetPersonListItemsAsync();

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(isConsultancyEnabled: true);

            return View(new ConsultancyChatsListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadChatsTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<ConsultancyChatsFilterViewModel>(param.FiltersObject);

                var results = await _consultancyRepository.GetDataTableAsync(param, filtersModel, Lng);

                var chats = await Task.WhenAll(results.Items.Select(async (x) => new ConsultancyChatsListViewModel
                {
                    Id = x.Id,
                    Doctor = x.Doctor,
                    Patient = x.Patient,
                    FinishDate = x.FinishDate,
                    StartDate = x.StartDate,
                    MessagesCount = x.MessagesCount,
                    Status = x.Status,
                    CreateDate = x.CreateDate,
                    ActionsHtml = await this.RenderViewToStringAsync("_ChatItemActions",(x.MessagesCount, x.Id)),
                }).ToList());

                return new JsonResult(new DataTablesResult<ConsultancyChatsListViewModel>
                {
                    Draw = param.Draw,
                    Data = chats,
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> ChatMessages(int id)
        {
            var result = await _consultancyRepository.GetChatMessagesAsync(id);

            return PartialView(result);
        }


        private async Task<List<SelectListItem>> GetPersonListItemsAsync()
        {
            var personsList = new List<SelectListItem>
            {
                new SelectListItem{Value = "", Text = "..."},
            };
            personsList.AddRange(await _personService.GetSelectListAsync(Lng));
            return personsList;
        }
    }
}