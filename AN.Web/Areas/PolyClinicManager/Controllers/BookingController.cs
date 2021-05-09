using AN.BLL.Core.Appointments;
using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Patients;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.Global;
using AN.Core.Resources.New;
using AN.Core.ViewModels;
using AN.Web.Areas.PolyClinicManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.PolyClinicManager.Controllers
{
    public class BookingController : PolyclinicManagerController
    {
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IServicesService _healthServiceService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IPatientService _patientService;
        private readonly IAppointmentsManager _appointmentsManager;
        private readonly IIPAsManager _iPAsManager;
        public BookingController(IServiceSupplyService serviceSupplyService,
                                 IWorkContext workContext,
                                 IServicesService servicesService,
                                 IPatientService patientService,
                                 IAppointmentsManager appointmentsManager,
                                 IIPAsManager iPAsManager,
                                 IDoctorServiceManager doctorServiceManager) : base(workContext)
        {
            _serviceSupplyService = serviceSupplyService;
            _healthServiceService = servicesService;
            _patientService = patientService;
            _doctorServiceManager = doctorServiceManager;
            _appointmentsManager = appointmentsManager;
            _iPAsManager = iPAsManager;
        }

        [Authorize(Roles = "polyclinicmanager,doctor,secretary")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            ViewBag.HealthServices = await _healthServiceService.GetSelectListItemsAsync(CurrentPolyclinic.Id, Lng);

            ViewBag.Patients = await _patientService.GetSelectListItemsAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds, Lng);

            var model = new PolyclinicBookingViewModel { Date = DateTime.Now };

            return View(model);
        }

        [Authorize(Roles = "polyclinicmanager,doctor,secretary")]
        public async Task<IActionResult> BookingTiems(PolyclinicBookingViewModel bookingModel)
        {
            if (CurrentPolyclinic.ServiceSupplyIds.Any() && !CurrentPolyclinic.ServiceSupplyIds.Contains(bookingModel.ServiceSupplyId))
            {
                throw new AccessDeniedException();
            }

            var servicesSupply = await _serviceSupplyService.GetForShiftCenterAsync(bookingModel.ServiceSupplyId, CurrentPolyclinic.Id);

            if (servicesSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var centerService = await _healthServiceService.GetShiftCenterServiceByIdAsync(bookingModel.CenterServiceId);

            if (centerService == null) throw new AwroNoreException(Global.Err_HealthServiceNotFound);

            var resultModel = new PolyclinicBookableTimesViewModel
            {
                BookingModel = bookingModel
            };

            var allTimePeriods = _doctorServiceManager.Calculate_All_TimePeriods(servicesSupply, bookingModel.Date, centerService);

            if (allTimePeriods != null && allTimePeriods.Any())
            {
                resultModel.BokkableTimes = allTimePeriods.Select(x => new BookableTimesListModel
                {
                    Type = x.Type,
                    StartTime = x.StartDateTime,
                    EndTime = x.EndDateTime,
                    IsOutOfSchedule = false,
                }).ToList();
            }

            return PartialView(resultModel);
        }

        [HttpGet]
        public async Task<IActionResult> FinalBookConfirm(int serviceSupplyId, int centerServiceId, int patientId, DateTime start, DateTime end)
        {
            EnsureAllowAccess(serviceSupplyId);

            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var centerService = _healthServiceService.GetShiftCenterServiceById(centerServiceId);

            if (centerService == null) throw new AwroNoreException(NewResource.NotAnyServiceDefinedForThisCenter);

            var patient = await _patientService.GetByIdAsync(patientId);

            if (patient == null) throw new AwroNoreException("Patient Not Found");

            var person = patient.Person ?? throw new AwroNoreException("Person Not Found");

            var doctorPerson = serviceSupply.Person ?? throw new AwroNoreException("Doctor Not Found");

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

            var doctorPersonInfo = new PersonInfoViewModel
            {
                Id = doctorPerson.Id,               
                FirstName = Lng == Lang.KU ? doctorPerson.FirstName_Ku : Lng == Lang.AR ? doctorPerson.FirstName_Ar : doctorPerson.FirstName,
                SecondName = Lng == Lang.KU ? doctorPerson.SecondName_Ku : Lng == Lang.AR ? doctorPerson.SecondName_Ar : doctorPerson.SecondName,
                ThirdName = Lng == Lang.KU ? doctorPerson.ThirdName_Ku : Lng == Lang.AR ? doctorPerson.ThirdName_Ar : doctorPerson.ThirdName,
                Address = doctorPerson.Address,               
                Sex = doctorPerson.Gender.GetLocalizedDisplayName(),               
                Avatar = doctorPerson.RealAvatar
            };

            var firstExpertise = serviceSupply?.DoctorExpertises.FirstOrDefault();

            var model = new PolyclinicConfirmBookingViewModel
            {
                BookingData = new PolyclinicBookingViewModel
                {
                    ServiceSupplyId = serviceSupplyId,
                    CenterServiceId = centerServiceId,
                    PatientId = patientId
                },
                DoctorPersonInfo = doctorPersonInfo,
                PatientPersonInfo = personInfo,
                Service = Lng == Lang.KU ? centerService.Service.Name_Ku : Lng == Lang.AR ? centerService.Service.Name_Ar : centerService.Service.Name,
                StartTime = start,
                EndTime = end,
                DoctorExpertiseCategory = firstExpertise != null ? Lng == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : Lng == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "",
            };            

            ViewBag.Lang = Lng;

            return PartialView(model);
        }

        public async Task<IActionResult> FinalBookTurn(int serviceSupplyId, int centerServiceId, int patientId, DateTime start, DateTime end)
        {
            EnsureAllowAccess(serviceSupplyId);

            try
            {
                var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

                var centerService = _healthServiceService.GetShiftCenterServiceById(centerServiceId);

                if (centerService == null) throw new AwroNoreException(NewResource.NotAnyServiceDefinedForThisCenter);

                if (!serviceSupply.IsAvailable) throw new AwroNoreException(serviceSupply.ShiftCenter.Type == ShiftCenterType.BeautyCenter ? Global.BeautyCenterNotActive : Global.DoctorNotActive);

                var patient = await _patientService.GetByIdAsync(patientId);

                if (patient == null) throw new AwroNoreException("Patient Not Found");

                var person = patient.Person ?? throw new AwroNoreException("Person Not Found");

                // Check if this patient has reserved appointment today or not?
                if (_appointmentsManager.HaveAppointmentForDate(start.ToShortDateString(), person.Mobile, serviceSupplyId, centerServiceId))
                {
                    throw new AwroNoreException(Global.Err_UserHaveTurnForDate);
                }

                // Reserve Turn In In-Progress Appointments
                var emptyPeriods = _doctorServiceManager.Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, start, centerService);
                if (emptyPeriods == null || !emptyPeriods.Any()) throw new AwroNoreException(NewResource.TurnReservedBeforeByAnotherPerson);
                var emptyTurn = emptyPeriods.FirstOrDefault(x => x.StartDateTime == start && x.EndDateTime == end);
                if (emptyTurn == null) throw new AwroNoreException(NewResource.TurnReservedBeforeByAnotherPerson);
                var ipa = new IPAModel
                {
                    AddedAt = DateTime.Now,
                    ServiceSupplyId = serviceSupplyId,
                    StartDateTime = emptyTurn.StartDateTime,
                    EndDateTime = emptyTurn.EndDateTime,
                    UserHostAgent = "Stand-WPF",
                    IsForSelectedDoctor = false,
                    PolyclinicHealthService = centerService,
                    OfferId = null
                };
                if (_doctorServiceManager.IsAvailableEmptyTimePeriod(ipa.ServiceSupplyId, ipa.StartDateTime, ipa.EndDateTime, ipa.PolyclinicHealthService))
                {                    
                    _iPAsManager.Insert(ipa);
                }
                else
                    throw new Exception(Global.Err_ValidTimePeriodNotFound);
                
                var patientModel = new PatientModel
                {
                    Mobile = person.Mobile,
                };
             
                var bookAppoint = await _appointmentsManager.BookAppointmentAsync(serviceSupply, patientModel, start.ToShortDateString(), start.ToString("HH:mm"), end.ToString("HH:mm"), true, PaymentStatus.Free, centerService, ReservationChannel.ClinicManagerSection, requestLang: Lng, offerId: null);

                return Json(new { success = bookAppoint.Status == BookingAppointmentStatus.Success, message = bookAppoint.Message });
            }
            catch (Exception e)
            {
                try
                {
                    _iPAsManager.Delete(serviceSupplyId, start);
                }
                catch
                {
                    // IGNORED
                }               
                throw e;
            }           
        }
    }
}