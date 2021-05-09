using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Patients;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.Areas.BeautyCenterManager.Models;
using AutoMapper;
using AWRO.Helper.UIHelper.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.BeautyCenterManager.Controllers
{
    public class InvoiceController : BeautyCenterManagerController
    {
        private readonly IShiftCenterService _shiftCenterService;
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly INotificationService _notificationService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly BanobatDbContext _dbContext;
        public InvoiceController(IWorkContext workContext,
                                 IShiftCenterService shiftCenterService,
                                 IMapper mapper,
                                 IInvoiceRepository invoiceRepository,
                                 IAppointmentService appointmentService,
                                 IPatientService patientService,
                                 INotificationService notificationService,
                                 IServiceSupplyService serviceSupplyService,
                                 BanobatDbContext dbContext) : base(workContext)
        {
            _shiftCenterService = shiftCenterService;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _notificationService = notificationService;
            _serviceSupplyService = serviceSupplyService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentBeautyCenter.Id, CurrentBeautyCenter.ServiceSupplyIds);

            ViewBag.Patients = await _patientService.GetSelectListItemsAsync(CurrentBeautyCenter.Id, CurrentBeautyCenter.ServiceSupplyIds, Lng);

            return View(new InvoiceListItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<InvoiceFilterViewModel>(param.FiltersObject);

                filtersModel.ServiceSupplyIds = CurrentBeautyCenter.ServiceSupplyIds;

                var results = await _invoiceRepository.GetDataTableAsync(CurrentBeautyCenter.Id, param, filtersModel, Lng);

                var invoices = await Task.WhenAll(results.Items.Select(async (x) => new InvoiceListItemViewModel
                {
                    Id = x.Id,
                    Patient = x.Patient,
                    Gender = x.Gender,
                    VisitDate = x.VisitDate,
                    Doctor = x.Doctor,
                    Avatar = x.Avatar,
                    Amount = x.Amount,
                    AvatarHtml = await this.RenderViewToStringAsync("_InvoiceCustomerAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_InvoiceActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<InvoiceListItemViewModel>
                {
                    Draw = param.Draw,
                    Data = invoices.ToList(),
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
        public async Task<IActionResult> Create(int? id, int? appointmentId, int? patientId)
        {
            if (appointmentId != null && patientId != null) throw new AwroNoreException("Can not create invoice for appointment & patient");

            var beautycenter = await _shiftCenterService.GetByIdAsync(CurrentBeautyCenter.Id);

            if (beautycenter == null || beautycenter.Type != ShiftCenterType.BeautyCenter) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.PolyclinicNotFound);

            if (id != null)
            {
                var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id.Value);

                if (invoice == null || invoice.Patient.ServiceSupply.ShiftCenterId != CurrentBeautyCenter.Id) throw new AwroNoreException("Invoice Not Found");

                var model = new InvoiceViewModel
                {
                    Id = invoice.Id,
                    VisitDate = invoice.VisitDate.ToString("yyyy/MM/dd"),
                    AppointmentId = invoice.AppointmentId,
                    PatientId = invoice.PatientId,
                    Description = invoice.Description
                };

                return PartialView(model);
            }
            else
            {
                var (person, _) = await GetPersonAndServiceSupplyIdAsync(appointmentId, patientId);

                if (person == null) throw new AwroNoreException("Person Not Found");

                ViewBag.PersonInfo = CollectPersonInfo(person);

                var model = new InvoiceViewModel
                {
                    AppointmentId = appointmentId,
                    PatientId = patientId,
                    VisitDate = DateTime.Now.ToShortDateString()
                };

                return PartialView(model);
            }
        }

        public async Task<IActionResult> ListInvoiceGridItemRows(int? id = null)
        {
            var list = new List<InvoiceItemsGridViewModel>();

            if (id != null)
            {
                var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id.Value);

                if (invoice == null || invoice.Patient.ServiceSupply.ShiftCenterId != CurrentBeautyCenter.Id) throw new AwroNoreException("Treatment Not Found");

                list = invoice.InvoiceItems.Select(x => new InvoiceItemsGridViewModel
                {
                    Id = x.Id,
                    ShiftCenterServiceId = x.ShiftCenterCerviceId,
                    CustomServiceName = x.CustomServiceName,
                    Price = x.Price,
                    Note = x.Note
                }).ToList();
            }

            return new AwroJGrid2Builder<InvoiceItemsGridViewModel>(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel model, InvoiceItemsGridViewModel[] items)
        {
            if (model.Id == null && model.AppointmentId != null && model.PatientId != null) throw new AwroNoreException("Can not create invoice for appointment & patient");

            if (items == null || !items.Any()) throw new AwroNoreException("Please enter at least one item");

            if (items.Any(x => (x.ShiftCenterServiceId == null || x.ShiftCenterServiceId <= 0) && string.IsNullOrEmpty(x.CustomServiceName))) throw new AwroNoreException("Please select service for all items");

            bool success = false;
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.Id != null)
                        {
                            var invoice = await _dbContext.Invoices.FindAsync(model.Id);

                            if (invoice == null || invoice.Patient.ServiceSupply.ShiftCenterId != CurrentBeautyCenter.Id) throw new AwroNoreException("Invoice Not Found");

                            var invoiceItems = await _dbContext.InvoiceItems.Where(x => x.InvoiceId == invoice.Id).ToListAsync();

                            if (invoiceItems.Any())
                            {
                                _dbContext.InvoiceItems.RemoveRange(invoiceItems);

                                await _dbContext.SaveChangesAsync();
                            }

                            if (items != null && items.Any())
                            {
                                var treats = items.Where(x => !x.IsDeleted && (x.ShiftCenterServiceId != null && x.ShiftCenterServiceId > 0) || !string.IsNullOrEmpty(x.CustomServiceName)).Select(x => new InvoiceItem
                                {
                                    InvoiceId = invoice.Id,
                                    ShiftCenterCerviceId = x.ShiftCenterServiceId,
                                    CustomServiceName = x.CustomServiceName,
                                    Price = x.Price,
                                    Note = x.Note,
                                    CreatedAt = DateTime.Now,
                                }).ToList();

                                _dbContext.InvoiceItems.AddRange(treats);

                                await _dbContext.SaveChangesAsync();
                            }

                            invoice.VisitDate = DateTime.Parse(model.VisitDate);
                            invoice.Description = model.Description ?? "";

                            _dbContext.Invoices.Attach(invoice);

                            _dbContext.Entry(invoice).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            Appointment appointment = null;
                            Patient patient = null;
                            if (model.AppointmentId != null)
                            {
                                appointment = await _dbContext.Appointments.FindAsync(model.AppointmentId);

                                if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                                patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.ServiceSupplyId == appointment.ServiceSupplyId && x.PersonId == appointment.PersonId);

                                if (patient == null)
                                {
                                    patient = new Patient
                                    {
                                        ServiceSupplyId = appointment.ServiceSupplyId,
                                        PersonId = appointment.PersonId,
                                        CreatedAt = DateTime.Now
                                    };

                                    await _dbContext.Patients.AddAsync(patient);

                                    await _dbContext.SaveChangesAsync();
                                }
                            }
                            else if (model.PatientId != null)
                            {
                                patient = await _dbContext.Patients.FindAsync(model.PatientId.Value) ?? throw new AwroNoreException("Patient Not Found");
                            }

                            var invoice = new Invoice
                            {
                                PatientId = patient.Id,
                                AppointmentId = model.AppointmentId,
                                CreatedAt = DateTime.Now,
                                Description = model.Description ?? "",
                                VisitDate = DateTime.Parse(model.VisitDate)
                            };

                            _dbContext.Invoices.Add(invoice);

                            await _dbContext.SaveChangesAsync();

                            if (items != null && items.Any())
                            {
                                var treats = items.Where(x => !x.IsDeleted && (x.ShiftCenterServiceId != null && x.ShiftCenterServiceId > 0) || !string.IsNullOrEmpty(x.CustomServiceName)).Select(x => new InvoiceItem
                                {
                                    InvoiceId = invoice.Id,
                                    ShiftCenterCerviceId = x.ShiftCenterServiceId,
                                    CustomServiceName = x.CustomServiceName,
                                    Price = x.Price,
                                    Note = x.Note,
                                    CreatedAt = DateTime.Now,
                                }).ToList();

                                var oldItems = await _dbContext.InvoiceItems.Where(x => x.InvoiceId == invoice.Id).ToListAsync();

                                if (oldItems.Any()) _dbContext.InvoiceItems.RemoveRange(oldItems);

                                _dbContext.InvoiceItems.AddRange(treats);

                                await _dbContext.SaveChangesAsync();
                            }

                            if (appointment != null)
                            {
                                _dbContext.Entry(appointment).State = EntityState.Modified;
                                appointment.Status = AppointmentStatus.Done;
                                await _dbContext.SaveChangesAsync();
                                await SendDoneAppointmentNotificationAsync(appointment, patient);
                            }
                        }

                        transaction.Commit();

                        success = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            });

            return Json(new { success, message = success ? Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully : Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileDoneAction });
        }

        [HttpGet]
        public async Task<List<SelectListItem>> GetCenterServicesSelectList()
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Text = "..."
                }
            };

            var data = await _dbContext.CenterServices.Where(x => x.ShiftCenterId == CurrentBeautyCenter.Id).Select(x => new SelectListItem
            {
                Text = Lng == Lang.KU ? x.Service.Name_Ku : Lng == Lang.AR ? x.Service.Name_Ar : x.Service.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            result.AddRange(data);

            return result;
        }

        private async Task<(Person, int)> GetPersonAndServiceSupplyIdAsync(int? appointmentId, int? patientId)
        {
            Person person = null;
            int serviceSupplyId = 0;
            if (appointmentId != null)
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(appointmentId.Value);

                if (appointment == null) throw new AwroNoreException("Appointment Not Found");

                serviceSupplyId = appointment.ServiceSupplyId;

                person = appointment.Person;
            }
            else if (patientId != null)
            {
                var patient = await _patientService.GetByIdAsync(patientId.Value);

                if (patient == null || patient.ServiceSupply.ShiftCenterId != CurrentBeautyCenter.Id) throw new AwroNoreException("Patient Not Found");

                serviceSupplyId = patient.ServiceSupplyId.Value;

                person = patient.Person;
            }

            return (person, serviceSupplyId);
        }

        private PersonInfoViewModel CollectPersonInfo(Person person)
        {
            var personInfo = new PersonInfoViewModel
            {
                Id = person.Id,
                UniqueId = person.UniqueId,
                FirstName = Lng == Lang.KU ? person.FirstName_Ku : Lng == Lang.AR ? person.FirstName_Ar : person.FirstName,
                SecondName = Lng == Lang.KU ? person.SecondName_Ku : Lng == Lang.AR ? person.SecondName_Ar : person.SecondName,
                ThirdName = Lng == Lang.KU ? person.ThirdName_Ku : Lng == Lang.AR ? person.ThirdName_Ar : person.ThirdName,
                Address = person.Address,
                Age = person.Age ?? 0,
                Birthdate = person.Birthdate != null ? person.Birthdate.Value.ToString("yyyy-MM-dd") : "",
                Height = person.Height ?? 0,
                IdNumber = person.IdNumber,
                Language = person.Language != null ? person.Language.GetLocalizedDisplayName() : "",
                MarriageStatus = person.MarriageStatus != null ? person.MarriageStatus.GetLocalizedDisplayName() : "",
                MobileNumber = person.Mobile,
                Sex = person.Gender.GetLocalizedDisplayName(),
                Weight = person.Weight ?? 0,
                Avatar = person.RealAvatar
            };
            return personInfo;
        }

        private async Task SendDoneAppointmentNotificationAsync(Appointment appointment, Patient patient)
        {
            if (appointment.Person.FcmInstanceIds != null && appointment.Person.FcmInstanceIds.Any())
            {
                var donePayload = new DoneAppointmentNotificationPayload
                {
                    AppointmentId = appointment.Id,
                    NotificationType = NotificationType.AppointmentDone,
                    UserTurnItem = new Core.DTO.Turn.UserTurnItemDTO
                    {
                        Id = appointment.Id,
                        ServiceSupplyId = appointment.ServiceSupplyId,
                        Date = appointment.Start_DateTime.ToShortDateString(),
                        StartTime = appointment.Start_DateTime.ToShortTimeString(),
                        EndTime = appointment.End_DateTime.ToShortTimeString(),
                        Status = appointment.Status,
                        DoctorName = Lng == Lang.KU ? appointment.ServiceSupply.Person.FullName_Ku : Lng == Lang.AR ? appointment.ServiceSupply.Person.FullName_Ar : appointment.ServiceSupply.Person.FullName,
                        DayOfWeek = Utils.ConvertDayOfWeek(appointment.Start_DateTime.DayOfWeek.ToString()),
                        IsRated = appointment.Rate != null,
                        AverageRating = (appointment.Rate != null) ? appointment.Rate.Rating : 5,
                        TrackingCode = appointment.UniqueTrackingCode,
                        CenterServiceId = appointment.ShiftCenterServiceId,
                        Service = Lng == Lang.KU ? appointment.ShiftCenterService.Service.Name_Ku : Lng == Lang.AR ? appointment.ShiftCenterService.Service.Name_Ar : appointment.ShiftCenterService.Service.Name
                    }
                };

                var enCulture = new CultureInfo(SupportedLangs.EN);
                var arCulture = new CultureInfo(SupportedLangs.AR);
                var kuCulture = new CultureInfo(SupportedLangs.KU);
                var basePayload = new BaseNotificationPayload
                {
                    Title = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", enCulture),
                    TitleKu = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", kuCulture),
                    TitleAr = Messages.ResourceManager.GetString("AppointmentDoneNotificationTitle", arCulture),
                    Body = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", enCulture),
                    BodyKu = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", kuCulture),
                    BodyAr = Messages.ResourceManager.GetString("AppointmentDoneNotificationBody", arCulture)
                };
                foreach (var item in patient.Person.FcmInstanceIds)
                {

                    await _notificationService.SendDoneAppointmentNotificationAsync(item.InstanceId, basePayload, donePayload);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            if (invoice != null && invoice.Patient.ServiceSupply.ShiftCenterId == CurrentBeautyCenter.Id)
            {
                var invoiceItems = await _dbContext.InvoiceItems.Where(x => x.InvoiceId == id).ToListAsync();
                if (invoiceItems.Any())
                {
                    _dbContext.InvoiceItems.RemoveRange(invoiceItems);
                }

                _dbContext.Invoices.Remove(invoice);

                await _dbContext.SaveChangesAsync();
            }

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });
        }
    }
}