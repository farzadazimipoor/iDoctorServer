using AN.BLL.DataRepository.Persons;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class PersonController : AdminController
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly BanobatDbContext _dbContext;
        public PersonController(IPersonService personService, IMapper mapper, IUploadService uploadService, BanobatDbContext dbContext)
        {
            _personService = personService;
            _mapper = mapper;
            _uploadService = uploadService;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.Genders = MyEnumExtensions.EnumToSelectList<Gender>().ToList();

            return View(new PersonListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(DataTablesParameters), JsonConvert.SerializeObject(param));

                var filtersModel = JsonConvert.DeserializeObject<PersonFilterViewModel>(param.FiltersObject);

                if (!string.IsNullOrEmpty(filtersModel.IsEmployeeFilter))
                {
                    filtersModel.IsEmployee = filtersModel.IsEmployeeFilter == "on" ? true : false;
                }

                var results = await _personService.GetDataTableAsync(param, filtersModel, Lng);

                var persons = await Task.WhenAll(results.Items.Select(async (x) => new PersonListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Gender = x.Gender,
                    IsEmployee = x.IsEmployee,
                    Avatar = x.Avatar,
                    AvatarHtml = await this.RenderViewToStringAsync("_PersonItemAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_PersonItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<PersonListViewModel>
                {
                    Draw = param.Draw,
                    Data = persons.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id = null)
        {
            ViewBag.GendersList = MyEnumExtensions.EnumToSelectList<Gender>().ToList();

            var model = new PersonCreateUpdateViewModel
            {
                Id = id,
            };

            if (id != null)
            {
                var person = await _personService.GetByIdAsync(id.Value);

                if (person == null) throw new Exception("Person Not Found");

                if (!string.IsNullOrEmpty(person.Avatar))
                {
                    ViewBag.AvatarPreview = "<img src=" + person.Avatar + " alt=\"Avatar\">";
                }                

                model = _mapper.Map<PersonCreateUpdateViewModel>(person);
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(PersonCreateUpdateViewModel model)
        {
            if (string.IsNullOrEmpty(model.Mobile) || model.Mobile.Length < 10) throw new Exception("Mobile is not valid");

            var isNumeric = double.TryParse(model.Mobile, out _);

            if (!isNumeric) throw new Exception("Mobile Number Is Not Valid");

            if (model.Mobile.Length > 10)
            {
                model.Mobile = model.Mobile.Substring(model.Mobile.Length - 10);
            }

            var duplicateMobile = await _dbContext.Persons.AnyAsync(x => x.Id != model.Id && x.Mobile == model.Mobile);

            if (duplicateMobile) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PersonMobileDuplicate);

            var success = false;
            var message = Core.Resources.Global.Global.Err_ErrorOccured;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var person = await _personService.GetByIdAsync(model.Id.Value);

                        if (person == null) throw new Exception("Person Not Found");

                        person.FirstName = model.FirstName;
                        person.FirstName_Ku = model.FirstName_Ku;
                        person.FirstName_Ar = model.FirstName_Ar;
                        person.SecondName = model.SecondName;
                        person.SecondName_Ku = model.SecondName_Ku;
                        person.SecondName_Ar = model.SecondName_Ar;
                        person.ThirdName = model.ThirdName;
                        person.ThirdName_Ku = model.ThirdName_Ku;
                        person.ThirdName_Ar = model.ThirdName_Ar;
                        person.Gender = model.Gender;
                        person.Mobile = model.Mobile;
                        person.IsEmployee = model.IsEmployee;

                        _dbContext.Persons.Attach(person);

                        _dbContext.Entry(person).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        if (model.ImageUpload != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GeneratePersonAvatarName(person.Id, model.ImageUpload);

                            person.Avatar = $"{baseUrl}/{thumbName}";

                            _dbContext.Persons.Attach(person);

                            _dbContext.Entry(person).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadPersonAvatarAsync(model.ImageUpload, dirPath, newName, thumbName);
                        }

                        message = AN.Core.Resources.EntitiesResources.Messages.ItemUpdatedSuccessFully;
                    }
                    else
                    {
                        var person = _mapper.Map<Person>(model);

                        person.UniqueId = await _personService.GenerateUniqueIdAsync();

                        await _dbContext.Persons.AddAsync(person);

                        await _dbContext.SaveChangesAsync();

                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GeneratePersonAvatarName(person.Id, model.ImageUpload);

                        person.Avatar = $"{baseUrl}/{thumbName}";

                        _dbContext.Persons.Attach(person);

                        _dbContext.Entry(person).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadPersonAvatarAsync(model.ImageUpload, dirPath, newName, thumbName);

                        message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully;
                    }

                    transaction.Commit();

                    success = true;

                }
            });

            return Json(new { success, message });
        }
    }
}