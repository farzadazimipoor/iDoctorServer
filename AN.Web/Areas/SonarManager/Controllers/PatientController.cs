using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Patients;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Services.Upload;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.Areas.PolyClinicManager.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.SonarManager.Controllers
{
    public class PatientController : SonarManagerController
    {
        private readonly IPersonService _personService;
        private readonly IPatientService _patientService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IAppointmentService _appointmentService;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly BanobatDbContext _dbContext;
        public PatientController(IWorkContext workContext,
                                 IPersonService personService,
                                 IPatientService patientService,
                                 IServiceSupplyService serviceSupplyService,
                                 IAppointmentService appointmentService,
                                 IUploadService uploadService,
                                 IMapper mapper,
                                 BanobatDbContext dbContext) : base(workContext)
        {
            _personService = personService;
            _patientService = patientService;
            _serviceSupplyService = serviceSupplyService;
            _appointmentService = appointmentService;
            _uploadService = uploadService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentSonar.Id, CurrentSonar.ServiceSupplyIds);

            return View(new PatientListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<PatientFilterViewModel>(param.FiltersObject);

                filtersModel.ServiceSupplyIds = CurrentSonar.ServiceSupplyIds;

                var results = await _patientService.GetDataTableAsync(CurrentSonar.Id, param, filtersModel, Lng, onlyForCenter: true);

                var persons = await Task.WhenAll(results.Items.Select(async (x) => new PatientListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Gender = x.Gender,
                    Age = x.Age,
                    IdNumber = x.IdNumber,
                    UniqueId = x.UniqueId,
                    Doctor = x.Doctor,
                    Avatar = x.Avatar,
                    AvatarHtml = await this.RenderViewToStringAsync("_SonarPatientItemAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_SonarPatientItemActions", (x.Id, x.PersonId, x.ServiceSupplyId))
                }).ToList());

                return new JsonResult(new DataTablesResult<PatientListViewModel>
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

        [HttpPost]
        public async Task<IActionResult> FindPerson(FindPersonModel model)
        {
            var person = await _personService.FindByMobileOrUniqueIdAsync(model.SearchString);

            if (person == null)
            {
                string htmlContent = await this.RenderViewToStringAsync("PersonNotFound", model);

                return Json(new { isFounded = false, htmlContent });
            }
            else
            {
                var createModel = new CreateSonarPatientFromPersonViewModel
                {
                    DoctorsList = (await _serviceSupplyService.GetSelectListAsync(CurrentSonar.Id, CurrentSonar.ServiceSupplyIds)).ToList(),
                    PersonInfo = new PersonInfoViewModel
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        SecondName = person.SecondName,
                        ThirdName = person.ThirdName,
                        Age = person.Age ?? 0,
                        Birthdate = person.Birthdate != null ? person.Birthdate.Value.ToString("yyyy-MM-dd") : "",
                        Address = person.Address,
                        Height = person.Height ?? 0,
                        Weight = person.Weight ?? 0,
                        IdNumber = person.IdNumber,
                        Language = person.Language != null ? person.Language.GetLocalizedDisplayName() : "",
                        MarriageStatus = person.MarriageStatus != null ? person.MarriageStatus.GetLocalizedDisplayName() : "",
                        MobileNumber = person.Mobile,
                        Sex = person.Gender.GetLocalizedDisplayName(),
                        UniqueId = person.UniqueId,
                        Avatar = person.RealAvatar
                    }
                };

                string htmlContent = await this.RenderViewToStringAsync("CreateFromPerson", createModel);

                return Json(new { isFounded = true, htmlContent });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromPerson(CreatePatientFromPersonViewModel model)
        {
            var existBefore = await _patientService.FindForCenterAsync(CurrentSonar.Id, model.PersonInfo.Id) != null;

            if (existBefore) throw new AwroNoreException("Patient already exist");

            var person = await _dbContext.Persons.FindAsync(model.PersonInfo.Id);

            if (person == null) throw new AwroNoreException("Person not found");

            if (string.IsNullOrEmpty(person.UniqueId))
            {
                var uniqueId = await _personService.GenerateUniqueIdAsync();

                person.UniqueId = uniqueId;

                _dbContext.Persons.Attach(person);

                _dbContext.Entry(person).State = EntityState.Modified;
            }

            await _dbContext.Patients.AddAsync(new Patient
            {
                ServiceSupplyId = model.ServiceSupplyId,
                CenterId = CurrentSonar.Id,
                PersonId = model.PersonInfo.Id,
                CreatedAt = DateTime.Now
            });

            await _dbContext.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id = null, int? appointmentId = null)
        {
            ViewBag.GendersList = MyEnumExtensions.EnumToSelectList<Gender>().ToList();

            ViewBag.MarriageStatusList = MyEnumExtensions.EnumToSelectList<MarriageStatus>().ToList();

            ViewBag.LanguagesList = MyEnumExtensions.EnumToSelectList<Language>().ToList();

            ViewBag.BloodTypesList = MyEnumExtensions.EnumToSelectList<BloodType>().ToList();

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentSonar.Id, CurrentSonar.ServiceSupplyIds);

            var model = new CreateSonarPatientViewModel
            {
                Id = id,
                AppointmentId = appointmentId,
            };

            if (id != null)
            {
                var patient = await _patientService.GetByIdAsync(id.Value);

                if (patient == null) throw new AwroNoreException("Patient Not Found");

                model.ServiceSupplyId = patient.ServiceSupplyId;

                model.PersonModel = _mapper.Map<PersonCreateUpdateViewModel>(patient.Person);

                if (Lng == Lang.KU)
                {
                    model.PersonModel.FirstName = patient.Person.FirstName_Ku;
                    model.PersonModel.SecondName = patient.Person.SecondName_Ku;
                    model.PersonModel.ThirdName = patient.Person.ThirdName_Ku;
                }
                else if (Lng == Lang.AR)
                {
                    model.PersonModel.FirstName = patient.Person.FirstName_Ar;
                    model.PersonModel.SecondName = patient.Person.SecondName_Ar;
                    model.PersonModel.ThirdName = patient.Person.ThirdName_Ar;
                }

                if (!string.IsNullOrEmpty(patient.Person.Avatar))
                {
                    ViewBag.AvatarPreview = "<img src=" + patient.Person.Avatar + " alt=\"Avatar\">";
                }
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(CreateSonarPatientViewModel model)
        {
            if (string.IsNullOrEmpty(model.PersonModel.Mobile) || model.PersonModel.Mobile.Length < 10) throw new AwroNoreException("Mobile is not valid");

            var isNumeric = double.TryParse(model.PersonModel.Mobile, out _);

            if (!isNumeric) throw new AwroNoreException("Mobile Number Is Not Valid");

            if (model.PersonModel.Mobile.Length > 10)
            {
                model.PersonModel.Mobile = model.PersonModel.Mobile.Substring(model.PersonModel.Mobile.Length - 10);
            }

            var success = false;
            var message = Core.Resources.Global.Global.Err_ErrorOccured;

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var patient = await _patientService.GetByIdAsync(model.Id.Value);

                        if (patient == null) throw new AwroNoreException("Patient Not Found");

                        var person = await _personService.GetByIdAsync(patient.PersonId);

                        if (person == null) throw new Exception("Person Not Found");

                        var duplicateMobile = await _dbContext.Persons.AnyAsync(x => x.Id != person.Id && x.Mobile == model.PersonModel.Mobile);

                        if (duplicateMobile) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PersonMobileDuplicate);

                        if (Lng == Lang.KU)
                        {
                            person.FirstName_Ku = model.PersonModel.FirstName;
                            person.SecondName_Ku = model.PersonModel.SecondName;
                            person.ThirdName_Ku = model.PersonModel.ThirdName;
                        }
                        else if (Lng == Lang.AR)
                        {
                            person.FirstName_Ar = model.PersonModel.FirstName;
                            person.SecondName_Ar = model.PersonModel.SecondName;
                            person.ThirdName_Ar = model.PersonModel.ThirdName;
                        }
                        else
                        {
                            person.FirstName = model.PersonModel.FirstName;
                            person.SecondName = model.PersonModel.SecondName;
                            person.ThirdName = model.PersonModel.ThirdName;
                        }

                        person.Age = model.PersonModel.Age;
                        person.Birthdate = model.PersonModel.Birthdate;
                        person.UpdatedAt = DateTime.Now;
                        person.Height = model.PersonModel.Height;
                        person.Weight = model.PersonModel.Weight;
                        person.IdNumber = model.PersonModel.IdNumber;
                        person.Language = model.PersonModel.Language;
                        person.Address = model.PersonModel.Address;
                        person.MarriageStatus = model.PersonModel.MarriageStatus;
                        person.Mobile = model.PersonModel.Mobile;
                        person.Gender = model.PersonModel.Gender;
                        person.BloodType = model.PersonModel.BloodType;

                        _personService.UpdatePerson(person);

                        if (model.PersonModel.ImageUpload != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GeneratePersonAvatarName(person.Id, model.PersonModel.ImageUpload);

                            person.Avatar = $"{baseUrl}/{thumbName}";

                            _dbContext.Persons.Attach(person);

                            _dbContext.Entry(person).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadPersonAvatarAsync(model.PersonModel.ImageUpload, dirPath, newName, thumbName);
                        }

                        message = Core.Resources.EntitiesResources.Messages.ItemUpdatedSuccessFully;
                    }
                    else
                    {
                        var duplicateMobile = await _dbContext.Persons.AnyAsync(x => x.Mobile == model.PersonModel.Mobile);

                        if (duplicateMobile) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PersonMobileDuplicate);

                        var person = _mapper.Map<Person>(model.PersonModel);

                        person.FirstName_Ku = model.PersonModel.FirstName;
                        person.SecondName_Ku = model.PersonModel.SecondName;
                        person.ThirdName_Ku = model.PersonModel.ThirdName;

                        person.FirstName_Ar = model.PersonModel.FirstName;
                        person.SecondName_Ar = model.PersonModel.SecondName;
                        person.ThirdName_Ar = model.PersonModel.ThirdName;


                        person.UniqueId = await _personService.GenerateUniqueIdAsync();

                        _dbContext.Persons.Add(person);

                        await _dbContext.SaveChangesAsync();

                        var patient = new Patient
                        {
                            CenterId = CurrentSonar.Id,
                            ServiceSupplyId = model.ServiceSupplyId,
                            PersonId = person.Id,
                            CreatedAt = DateTime.Now
                        };

                        _dbContext.Patients.Add(patient);

                        await _dbContext.SaveChangesAsync();

                        if (model.AppointmentId != null)
                        {
                            var appointment = await _dbContext.Appointments.FindAsync(model.AppointmentId);

                            if (appointment == null) throw new Exception("Appointment Not Found");

                            appointment.PersonId = person.Id;

                            _dbContext.Entry(appointment).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();
                        }

                        if (model.PersonModel.ImageUpload != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GeneratePersonAvatarName(person.Id, model.PersonModel.ImageUpload);

                            person.Avatar = $"{baseUrl}/{thumbName}";

                            _dbContext.Persons.Attach(person);

                            _dbContext.Entry(person).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadPersonAvatarAsync(model.PersonModel.ImageUpload, dirPath, newName, thumbName);

                            message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully;
                        }
                    }

                    transaction.Commit();

                    success = true;
                }
            });

            return Json(new { success, message });
        }

        [HttpGet]
        public async Task<IActionResult> Attachments(int id)
        {
            var patient = await _dbContext.Patients.Where(x => x.CenterId == CurrentSonar.Id && x.Id == id).FirstOrDefaultAsync();

            if (patient == null) throw new AwroNoreException("Patient not found");

            ViewBag.PatientId = id;

            var attachments = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.PATIENT && x.OwnerTableId == id).Select(x => new PatientAttachmentViewModel
            {
                Id = x.Id,
                name = x.Name,
                url = x.Url,
                thumbnailUrl = x.ThumbnailUrl,
                deleteType = "POST",
                deleteUrl = x.DeleteUrl,
                size = x.Size,
                PatientId = patient.Id,
                CreatedAt = x.CreatedAt
            }).ToListAsync();

            return PartialView(attachments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _dbContext.Patients.Where(x => x.CenterId == CurrentSonar.Id && x.Id == id).FirstOrDefaultAsync();
            if (patient != null)
            {
                if (patient.TreatmentHistories.Any()) throw new AwroNoreException("This patient is used. You can not delete it");

                _dbContext.Patients.Remove(patient);

                await _dbContext.SaveChangesAsync();
            }

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });
        }
    }
}