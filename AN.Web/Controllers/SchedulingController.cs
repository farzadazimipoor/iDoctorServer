using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository.ActivityLog;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Insurances;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.Schedules;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.MyComparers;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.Resources.Global;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    [Authorize(Roles = "admin,hospitalmanager,clinicmanager,polyclinicmanager,doctor,secretary,beautycentermanager")]
    public class SchedulingController : CpanelBaseController
    {
        #region Fields      
        private readonly IWorkContext _workContext;
        private readonly IShiftCenterService _polyclinicService;
        private readonly IScheduleInsuranceService _scheduleInsuranceService;
        private readonly IInsuranceService _insuranceService;
        private readonly IUsualScheduleService _usualScheduleService;
        private readonly IPlivoService _plivoService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyManager _serviceSupplyManager;
        private readonly IScheduleManager _scheduleManager;
        private readonly ICommonUtils _commonUtils;
        private readonly IScheduleService _scheduleService;
        private readonly IActivityLogService _activityService;
        private readonly IShiftCenterMessageService _polyclinicMessageService;
        private readonly IServicesService _healthServiceService;
        private readonly IIPAsManager _iPAsManager;
        private static Logger _logger;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public SchedulingController(IWorkContext workContext,
                                    IShiftCenterService polyclinicService,
                                    IScheduleInsuranceService scheduleInsuranceService,
                                    IInsuranceService insuranceService,
                                    IUsualScheduleService usualScheduleService,
                                    IServiceSupplyService serviceSupplyService,
                                    IAppointmentService appointmentService,
                                    IPlivoService plivoService,
                                    IDoctorServiceManager doctorServiceManager,
                                    IServiceSupplyManager serviceSupplyManager,
                                    IScheduleManager scheduleManager,
                                    ICommonUtils commonUtils,
                                    IScheduleService scheduleService,
                                    IActivityLogService activityLogService,
                                    IShiftCenterMessageService polyclinicMessageService,
                                    IServicesService healthServiceService, IIPAsManager iPAsManager,
                                    BanobatDbContext dbContext) : base(workContext)
        {
            _workContext = workContext;
            _polyclinicService = polyclinicService;
            _scheduleInsuranceService = scheduleInsuranceService;
            _insuranceService = insuranceService;
            _usualScheduleService = usualScheduleService;
            _plivoService = plivoService;
            _doctorServiceManager = doctorServiceManager;
            _serviceSupplyManager = serviceSupplyManager;
            _scheduleManager = scheduleManager;
            _commonUtils = commonUtils;
            _serviceSupplyService = serviceSupplyService;
            _appointmentService = appointmentService;
            _scheduleService = scheduleService;
            _activityService = activityLogService;
            _polyclinicMessageService = polyclinicMessageService;
            _healthServiceService = healthServiceService;
            _iPAsManager = iPAsManager;
            _dbContext = dbContext;

            _logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index(int serviceSupplyId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }

            var serviceSupply = await _serviceSupplyService.GetServiceSupplyForAreaAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Messages.DoctorNotFound);

            ViewBag.Lang = Lng;

            ViewBag.Area = LoginAs.ToString();

            return View(new SchedulingViewModel
            {
                PolyclinicId = serviceSupply.ShiftCenterId,
                ServiceSupplyId = serviceSupply.Id,
                DoctorName = serviceSupply.Person.FullName
            });
        }       

        [HttpPost]
        //[NoDirectAccess]
        public async Task<IActionResult> GetDoctorScheduleEvents(int serviceSupplyId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }

            var serviceSupply = await _serviceSupplyService.GetServiceSupplyForAreaAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Messages.DoctorNotFound);

            var disableEventColor = "#FF0000";
            var morningEventColor = "";
            var eveningEventColor = "#817878";

            var events = (from s in serviceSupply.Schedules
                          where s.End_DateTime > DateTime.Now
                          let shift = Utils.GetScheduleShift(s.Start_DateTime, s.End_DateTime)
                          let color = !s.IsAvailable ? disableEventColor : (shift == ScheduleShift.Morning ? morningEventColor : eveningEventColor)
                          let title = s.IsAvailable ? $"{Messages.Reception}: {s.MaxCount.ToString()} {Messages.Person} {(Lng == Lang.KU ? s.ShiftCenterService?.Service?.Name_Ku : s.ShiftCenterService?.Service?.Name_Ar)}" : Messages.DoctorNotAvailable
                          select new
                          {
                              // Event Data
                              id = s.Id,
                              isAvailable = s.IsAvailable,
                              healthService = Lng == Lang.KU ? s.ShiftCenterService?.Service?.Name_Ku : s.ShiftCenterService?.Service?.Name_Ar,
                              healthServiceId = s.ShiftCenterServiceId,
                              prerequisite = s.Prerequisite != null ? s.Prerequisite.ToString() : "",
                              prerequisiteId = s.Prerequisite != null ? (int)s.Prerequisite : 0,
                              maxCount = s.MaxCount,
                              serviceSupplyId = s.ServiceSupplyId,
                              // Event Settings
                              title,
                              start = s.Start_DateTime.ToString("s"),
                              end = s.End_DateTime.ToString("s"),
                              color,
                              textColor = "green",
                              className = "",
                              someKey = "",
                              allDay = false,
                          }).ToArray();

            return Json(events);
        }

        [HttpGet]
        //[NoDirectAccess]
        public async Task<IActionResult> EventCrud(int serviceSupplyId, string date, string startTime, string endTime, int? scheduleId = null)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }

            var serviceSupply = await _serviceSupplyService.GetServiceSupplyForAreaAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Messages.DoctorNotFound);

            ViewBag.Prerequisites = MyEnumExtensions.EnumToSelectList<PrerequisiteType>().ToList();

            ViewBag.HealthServices = _healthServiceService.GetShiftCenterServicesListItems(serviceSupply.ShiftCenterId, Lng).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();

            var model = new ScheduleEventViewModel
            {
                Action = ActionType.Insert,
                ServiceSupplyId = serviceSupplyId,
                Date = date,
                StartTime = startTime,
                EndTime = endTime,
                IsAvailable = true
            };

            if (scheduleId != null)
            {
                var schedule = serviceSupply.Schedules.FirstOrDefault(x => x.Id == scheduleId);

                if (schedule == null) throw new AwroNoreException("Schedule Not Found");

                model.Id = schedule.Id;
                model.Action = ActionType.Update;
                model.Date = schedule.Start_DateTime.ToShortDateString();
                model.StartTime = schedule.Start_DateTime.ToShortTimeString();
                model.EndTime = schedule.End_DateTime.ToShortTimeString();
                model.HealthServiceId = schedule.ShiftCenterServiceId;
                model.IsAvailable = schedule.IsAvailable;
                model.MaxCount = schedule.MaxCount;
                model.Prerequisite = schedule.Prerequisite;
                model.ServiceSupplyId = schedule.ServiceSupplyId;
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[NoDirectAccess]
        public async Task<IActionResult> ScheduleEventCrud(ScheduleEventViewModel model)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(model.ServiceSupplyId)) throw new AccessDeniedException();
            }

            if (!ModelState.IsValid)
            {                
                throw new Exception("Model Data Not Valid");
            }

            var serviceSupply = await _serviceSupplyService.GetServiceSupplyForAreaAsync(model.ServiceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Messages.DoctorNotFound);

            var scheduleObject = new ManualScheduleModel
            {
                Id = model.Id,
                StartDateTime = model.StartDateTime ?? DateTime.MinValue,
                EndDateTime = model.EndDateTime ?? DateTime.MinValue,
                HealthServiceId = model.HealthServiceId,
                Prerequisite = model.Prerequisite,
                MaxCount = model.MaxCount,
                IsAvailable = model.IsAvailable || model.Action == ActionType.Insert
            };

            if (model.Id == null) model.Action = ActionType.Insert;

            var message = string.Empty;

            switch (model.Action)
            {
                case ActionType.Insert:
                    _scheduleManager.SetManualSchedule(serviceSupply, scheduleObject, out List<Appointment> pending);
                    if (pending.Any())
                    {
                        return Json(new
                        {
                            Status = 0,
                            Message = pending.Count,
                            Appointments = pending.Select(x => new
                            {
                                x.Id,
                                Time = x.Start_DateTime.ToShortTimeString(),
                                PatientName = x.Person.FullName,
                                PatientMobile = x.Person.Mobile
                            }),
                            Date = model.StartDateTime.Value.ToShortDateString(),
                            StartTime = model.StartDateTime.Value.ToShortTimeString(),
                            EndTime = model.EndDateTime.Value.ToShortTimeString()
                        });
                    }
                    message = Messages.ItemAddedSuccessFully;
                    break;
                case ActionType.Update:
                    _scheduleManager.UpdateManualSchedule(scheduleObject, out List<Appointment> pendingAppoints);
                    message = pendingAppoints.Count == 0 ? Messages.ItemAddedSuccessFully : Messages.DoctorHasPendingTurns;
                    break;
                case ActionType.Delete:
                    _scheduleManager.RemoveSchedule((int)model.Id, out List<Appointment> pendingList);
                    message = pendingList.Count == 0 ? Messages.ItemDeletedSuccessFully : Messages.DoctorHasPendingTurns;
                    break;
            }

            return Json(new SaveScheduleResultModel { IsSucceed = true, Message = message });

        }

        [HttpGet]
        public async Task<IActionResult> SetAvailability(int? id)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(id.Value)) throw new AccessDeniedException();
            }

            var serviceSupply = _serviceSupplyService.GetServiceSupplyForArea((int)id);

            if (serviceSupply == null) throw new Exception(Messages.DoctorNotFound);

            TempData["area"] = LoginAs.ToString();

            ViewBag.polyclinicId = serviceSupply.ShiftCenterId;

            IList<Appointment> pendingAppointments = new List<Appointment>();

            if (serviceSupply.IsAvailable)
            {
                pendingAppointments = await _appointmentService.GetAllPendingAppointmentsForServiceSupply(serviceSupply.Id);
            }

            return View(new DoctorAvailabilityModel
            {
                ServiceSupplyId = serviceSupply.Id,
                doctorName = serviceSupply.Person.FullName,
                IsAvailable = serviceSupply.IsAvailable,
                PendingAppointments = pendingAppointments,
                CancelAllAppointments = false
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetAvailability(DoctorAvailabilityModel model)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(model.ServiceSupplyId)) throw new AccessDeniedException();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var serviceSupply = _serviceSupplyService.GetServiceSupplyForArea(model.ServiceSupplyId);

                    if (serviceSupply == null) throw new Exception(Messages.DoctorNotFound);

                    if (model.IsAvailable)
                    {
                        if (model.CancelAllAppointments)
                        {
                            var pendingAppoints = await _appointmentService.GetAllPendingAppointmentsForServiceSupply(serviceSupply.Id);
                            if (pendingAppoints.Count > 0)
                            {
                                foreach (var appointment in pendingAppoints)
                                {
                                    appointment.Status = AppointmentStatus.Canceled;
                                    appointment.IsDeleted = true;
                                    _appointmentService.UpdateAppointment(appointment);

                                    try
                                    {
                                        string[] recepient = { $"964{appointment.Person.Mobile}" };
                                        var statuses = new byte[recepient.Length];
                                        var recId = new long[recepient.Length];

                                        var _date = appointment.Start_DateTime.ToShortDateString();
                                        var doctorName = appointment.ServiceSupply.Person.FullName;
                                        var centerName = appointment.ServiceSupply.ShiftCenter.IsIndependent ? Global.PolyclinicPrefix + " " + (Lng == Lang.KU ? appointment.ServiceSupply.ShiftCenter.Name_Ku : appointment.ServiceSupply.ShiftCenter.Name_Ar) : Global.ClinicPrefix + " " + (Lng == Lang.KU ? appointment.ServiceSupply.ShiftCenter.Clinic.Name_Ku : appointment.ServiceSupply.ShiftCenter.Clinic.Name_Ar);

                                        //var smsBody = "با احترام به استحضار می رساند با توجه به عدم حضور دکتر " + doctorName + " در " + centerName + " در مورخ " + _date + " نوبت شما لغو می گرد ";
                                        var smsBody = $"{Messages.AccordingToDoctorAbsense} {doctorName} {Messages.InDate} {_date} {Messages.YourTurnWillBeCanceled}";

                                        _plivoService.SendMessage(recepient.ToList(), smsBody);
                                        if (0 == 0)
                                        {
                                            if (statuses.FirstOrDefault() == 0)
                                            {
                                                _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                                                {
                                                    Type = MessageType.SMS,
                                                    Category = MessageCategory.Announcement,
                                                    About = MessageActionAbout.CancelAppointment,
                                                    SendingDate = DateTime.Now,
                                                    Recipient = recepient.FirstOrDefault(),
                                                    MessageBody = smsBody,
                                                    MessageId = recId.FirstOrDefault(),
                                                    MessageStatus = 100, //وضعیت دلیوری نامشخص
                                                    ShiftCenterId = appointment.ServiceSupply.ShiftCenterId,
                                                    ReceiverPersonId = appointment.PersonId,
                                                    SenderUserName = CurrentUserName,
                                                    AppointmentId = appointment.Id,
                                                    CreatedAt = DateTime.Now
                                                });
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }

                        }
                    }

                    serviceSupply.IsAvailable = !model.IsAvailable;

                    _serviceSupplyService.UpdateServiceSupply(serviceSupply);

                    if (model.IsAvailable)
                        _activityService.InsertActivityLog(new DoctorActivityLog
                        {
                            Date = DateTime.Now,
                            Action = DoctorActivityAction.Disabled,
                            ServiceSupplyId = serviceSupply.Id
                        });
                    else
                        _activityService.InsertActivityLog(new DoctorActivityLog
                        {
                            Date = DateTime.Now,
                            Action = DoctorActivityAction.Enabled,
                            ServiceSupplyId = serviceSupply.Id
                        });

                    var status = model.IsAvailable ? Global.InActive : Global.Active;

                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ActionDoneSuccesfully });

                    var action = model.IsAvailable ? "Disabled" : "Enabled";

                    _logger.Info(HttpContext.User.Identity.Name + " " + action + " doctor with id: " + serviceSupply.Id + " and name: " + serviceSupply.Person.FullName + " in " + DateTime.Now);

                    return RedirectToAction("SettingDoctor", "Polyclinic", new { area = "", polyclinicId = serviceSupply.ShiftCenterId });
                }
            }
            catch (Exception ex)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = ex.Message });
            }
            return View(model);
        }

        #region Setting Usual Plan
        [HttpGet]
        public async Task<IActionResult> SettingUsualPlan(int? polyclinicId, string userMessage = "", MVCResultStatus resultStatus = MVCResultStatus.success)
        {
            if (LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER || LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
            {
                polyclinicId = _polyclinicService.GetCurrentShiftCenter()?.Id;
            }

            if (polyclinicId == null) throw new ArgumentNullException(nameof(polyclinicId));

            var polyclinic = _polyclinicService.GetShiftCenterForArea((int)polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

            var serviceSupplies = await _serviceSupplyService.GetSelectListAsync(polyclinic.Id, _workContext.WorkingArea.ServiceSupplyIds);

            var medicalServices = _healthServiceService.GetShiftCenterServicesListItems(polyclinic.Id, Lng);

            var daysOfWeek = _commonUtils.PopulateDaysOfWeekListForUsualPlan();

            var serviceSupply = polyclinic.ServiceSupplies.FirstOrDefault(x => x.Id == int.Parse(serviceSupplies.FirstOrDefault().Value));
            var medicalService = medicalServices.FirstOrDefault();
            var dayOfWeek = daysOfWeek.FirstOrDefault();

            var remainedCounts = 0;
            if (!string.IsNullOrEmpty(userMessage))
            {
                TempData.Put("message", new MVCResultModel { status =resultStatus, message = userMessage });
            }
            ViewBag.Lang = Lng;
            TempData["area"] = LoginAs.ToString();
            ViewBag.Prerequisites = MyEnumExtensions.EnumToSelectList<PrerequisiteType>().ToList();
            var model = new SetUsualPlanViewModel
            {
                ListDaysOfWeek = daysOfWeek,
                ListMedicalServices = medicalServices,
                ListServiceSupplies = serviceSupplies,
                PolyclinicId = polyclinic.Id,
                MaxCount = remainedCounts
            };
            return View(model);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetUsualPlan(SetUsualPlanViewModel model)
        {
            var userMessage = string.Empty;
            var resultStatus = MVCResultStatus.success;
            try
            {
                if (ModelState.IsValid)
                {
                    #region validation
                    if (model.Shift == 0)
                    {
                        var morningFrom = DateTime.Parse(model.From);

                        var morningTo = DateTime.Parse(model.To);

                        if (!((morningFrom == Defaults.MorningStart || morningFrom > Defaults.MorningStart) && (morningFrom < Defaults.MorningEnd)))
                        {
                            throw new Exception(Messages.MorningShiftStartNotValid);

                        }

                        if (!((morningTo == Defaults.MorningEnd || morningTo < Defaults.MorningEnd) && (morningTo > Defaults.MorningStart)))
                        {
                            throw new Exception(Messages.MorningShiftEndNotValid);

                        }
                    }
                    else if (model.Shift == 1)
                    {
                        var eveningFrom = DateTime.Parse(model.From);
                        var eveningTo = DateTime.Parse(model.To);

                        if (!((eveningFrom == Defaults.EveningStart || eveningFrom > Defaults.EveningStart) && (eveningFrom < Defaults.EveningEnd)))
                        {
                            throw new Exception(Messages.EveningShitStartNotValid);

                        }

                        if (!((eveningTo == Defaults.EveningEnd || eveningTo < Defaults.EveningEnd) && (eveningTo > Defaults.EveningStart)))
                        {
                            throw new Exception(Messages.EveningShiftEndNotValid);

                        }
                    }
                    var dayOfWeek = Utils.ConvertStringToDayOfWeek(model.DayOfWeek);
                    var maxCapacity = _scheduleManager.CalculateRemainedReservaableAppointsCount(dayOfWeek, model.Shift, model.From, model.To, model.ServiceSupplyId, model.MedicalServiceId);
                    if (model.MaxCount < 1)
                    {
                        throw new Exception(Messages.CapacityIsSmallerThanRequested);
                    }
                    #endregion

                    #region init variables                   
                    var dayOfWeekPersian = Utils.ConvertDayOfWeek(model.DayOfWeek);
                    #endregion

                    var polyclinic = _polyclinicService.GetShiftCenterForArea(model.PolyclinicId);

                    if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

                    var tmpIpas = new List<IPAModel>();

                    #region get old plans                        
                    var oldPlansForDayOfWeek = (from p in _dbContext.UsualSchedulePlans
                                                where p.DayOfWeek == dayOfWeek &&
                                                      p.ServiceSupplyId == model.ServiceSupplyId &&
                                                      p.Shift == (ScheduleShift)model.Shift
                                                select p).ToList();
                    #endregion

                    #region get pending appointments for dayofweek
                    var shiftStartHour = (ScheduleShift)model.Shift == ScheduleShift.Morning ? Defaults.MorningStart.Hour : Defaults.EveningStart.Hour;
                    var shiftStartMinute = (ScheduleShift)model.Shift == ScheduleShift.Morning ? Defaults.MorningStart.Minute : Defaults.EveningStart.Minute;
                    var shiftEndHour = (ScheduleShift)model.Shift == ScheduleShift.Morning ? Defaults.MorningEnd.Hour : Defaults.EveningEnd.Hour;
                    var shiftEndMinute = (ScheduleShift)model.Shift == ScheduleShift.Morning ? Defaults.MorningEnd.Minute : Defaults.EveningEnd.Minute;

                    var shiftStartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shiftStartHour, shiftStartMinute, 0);
                    var shiftEndDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shiftEndHour, shiftEndMinute, 0);

                    var pendingAppoints = (from a in _dbContext.Appointments
                                           where a.ServiceSupplyId == model.ServiceSupplyId &&
                                                 a.ServiceSupply.ShiftCenterId == polyclinic.Id &&
                                                 a.Status == AppointmentStatus.Pending && 
                                                 a.Start_DateTime.TimeOfDay >= shiftStartDateTime.TimeOfDay &&
                                                 a.Start_DateTime.TimeOfDay <= shiftEndDateTime.TimeOfDay
                                           select a)
                                .AsEnumerable()
                                .Where(a => a.Start_DateTime.DayOfWeek.ToString() == model.DayOfWeek)
                                .OrderBy(a => a.Start_DateTime)
                                .Distinct(new AppointmentComprarer())
                                .ToList();
                    #endregion

                    #region get old plan for medical service
                    var oldPlanForMedicalService = oldPlansForDayOfWeek.FirstOrDefault(x => x.ShiftCenterServiceId == model.MedicalServiceId && x.Shift == (ScheduleShift)model.Shift);
                    #endregion

                    if (pendingAppoints.Count > 0)
                    {
                        var appointsForMedicalService = pendingAppoints.Where(pa => pa.ShiftCenterServiceId == model.MedicalServiceId || pa.ShiftCenterServiceId <= 0).ToList();

                        if (appointsForMedicalService.Count > 0)
                        {
                            //var smsService = new Send();

                            var appointsDates = appointsForMedicalService.Select(x => x.Start_DateTime.Date).Distinct().OrderBy(x => x).ToList();

                            foreach (var date in appointsDates)
                            {
                                var startTime = DateTime.Parse(date.ToShortDateString() + " " + model.From);
                                var endTime = DateTime.Parse(date.ToShortDateString() + " " + model.To);
                                var duration = (int)Math.Ceiling(((endTime - startTime).TotalMinutes) / model.MaxCount);
                                var periods = _doctorServiceManager.Calculate_Bookable_TimePeriods(startTime, endTime, duration);

                                var appointsInDate = appointsForMedicalService.Where(x => x.Start_DateTime.Date == date).OrderBy(x => x.Start_DateTime).ToList();

                                var appointsToRemain = appointsInDate.Take(model.MaxCount).ToList();
                                var overFlowedAppoints = appointsInDate.Skip(model.MaxCount).ToList();

                                foreach (var appointment in appointsToRemain)
                                {
                                    //var qNum = appointmentService.GetQueueNumberForAppointment(model.ServiceSupplyId, (int)appointment.Id, date.ToShortDateString());
                                    var qNum = appointsToRemain.FindIndex(x => x.Id == appointment.Id);

                                    //var newPeriodTime = periods.ElementAt(qNum - 1);
                                    var newPeriodTime = periods.ElementAt(qNum);

                                    _dbContext.Entry(appointment).State = EntityState.Modified;
                                    appointment.Start_DateTime = newPeriodTime.StartDateTime;
                                    appointment.End_DateTime = newPeriodTime.EndDateTime;

                                    //TODO: Send SMS notification that appointment time changed
                                }

                                if (overFlowedAppoints.Count > 0)
                                {
                                    var appointmentsToCancel = new List<Appointment>();

                                    foreach (var appointment in overFlowedAppoints)
                                    {
                                        var nextEmptyPeriod = _doctorServiceManager.Find_First_Empty_TimePeriod_From_DateTime(appointment.ServiceSupply, startTime.AddDays(1), appointment.ShiftCenterService);
                                        if (nextEmptyPeriod != null)
                                        {
                                            var ipa = new IPAModel
                                            {
                                                ServiceSupplyId = appointment.ServiceSupplyId,
                                                IsForSelectedDoctor = appointment.ServiceSupply.ShiftCenter.IsIndependent,
                                                AddedAt = DateTime.Now,
                                                PolyclinicHealthService = appointment.ShiftCenterService,
                                                StartDateTime = nextEmptyPeriod.StartDateTime,
                                                EndDateTime = nextEmptyPeriod.EndDateTime
                                            };
                                            if (_doctorServiceManager.IsAvailableEmptyTimePeriod(ipa.ServiceSupplyId, ipa.StartDateTime, ipa.EndDateTime, ipa.PolyclinicHealthService))
                                            {
                                                _iPAsManager.Insert(ipa);
                                                tmpIpas.Add(ipa);

                                                var oldDate = appointment.Start_DateTime.ToShortDateString();

                                                _dbContext.Entry(appointment).State = EntityState.Modified;
                                                appointment.Start_DateTime = nextEmptyPeriod.StartDateTime;
                                                appointment.End_DateTime = nextEmptyPeriod.EndDateTime;

                                                var doctorName = String.Format("{0} {1}", appointment.ServiceSupply.Person.FirstName, appointment.ServiceSupply.Person.FullName);
                                                var message = $"{Messages.AccordingToChangeDoctorSchedule} {doctorName} {Messages.YourTurnFromDate} {oldDate} {Messages.ToDate} {appointment.Start_DateTime.ToShortDateString()} {Messages.HasBeenTransmitted}";

                                                var status = new byte[1];
                                                var recId = new long[1];
                                                string[] recepient = { $"964{appointment.Person.Mobile}" };

                                                _plivoService.SendMessage(recepient.ToList(), message);
                                                if (0 == 0)
                                                {
                                                    if (status.FirstOrDefault() == 0)
                                                    {
                                                        _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                                                        {
                                                            Type = MessageType.SMS,
                                                            Category = MessageCategory.Announcement,
                                                            About = MessageActionAbout.CancelAppointment,
                                                            SendingDate = DateTime.Now,
                                                            Recipient = recepient.FirstOrDefault(),
                                                            MessageBody = message,
                                                            MessageId = recId.FirstOrDefault(),
                                                            MessageStatus = 100, //وضعیت دلیوری نامشخص
                                                            ShiftCenterId = appointment.ServiceSupply.ShiftCenterId,
                                                            ReceiverPersonId = appointment.PersonId,
                                                            SenderUserName = CurrentUserName,
                                                            AppointmentId = appointment.Id,
                                                            CreatedAt = DateTime.Now
                                                        });
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception(Messages.EmptyTimePeriodNotValid);
                                            }
                                        }
                                        else
                                        {
                                            appointmentsToCancel.Add(appointment);
                                        }
                                    }

                                    if (appointmentsToCancel.Count > 0)
                                    {
                                        var recipients = appointmentsToCancel.Select(a => "964" + a.Person.Mobile).ToArray();
                                        var userRecivers = appointmentsToCancel.Select(a => a.PersonId).ToArray();
                                        var appointmentIds = appointmentsToCancel.Select(a => a.Id).ToArray();

                                        var firstAppoint = appointmentsToCancel.FirstOrDefault();
                                        var doctorName = String.Format("{0} {1}", firstAppoint.ServiceSupply.Person.FirstName, firstAppoint.ServiceSupply.Person.FullName);
                                        var message = $"{Messages.AccordingToChangeDoctorSchedule} {doctorName} {Messages.YourTurnInDate} {firstAppoint.Start_DateTime.ToShortDateString()} {Messages.WillBeCanceled}";

                                        foreach (var item in appointmentsToCancel)
                                        {
                                            _dbContext.Entry(item).State = EntityState.Modified;
                                            item.Status = AppointmentStatus.Canceled;
                                            item.IsDeleted = true;
                                        }

                                        #region send sms notification
                                        var status = new byte[recipients.Length];
                                        var recId = new long[recipients.Length];

                                        _plivoService.SendMessage(recipients.ToList(), message);
                                        if (0 == 0)
                                        {
                                            for (var i = 0; i < recipients.Length; i++)
                                            {
                                                if (status[i] == 0)
                                                {
                                                    _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                                                    {
                                                        Type = MessageType.SMS,
                                                        Category = MessageCategory.Announcement,
                                                        About = MessageActionAbout.CancelAppointment,
                                                        SendingDate = DateTime.Now,
                                                        Recipient = recipients[i],
                                                        MessageBody = message,
                                                        MessageId = recId[i],
                                                        MessageStatus = 100, //وضعیت دلیوری نامشخص
                                                        ShiftCenterId = model.PolyclinicId,
                                                        ReceiverPersonId = userRecivers[i],
                                                        SenderUserName = CurrentUserName,
                                                        AppointmentId = appointmentIds[i],
                                                        CreatedAt = DateTime.Now
                                                    });
                                                }
                                            }
                                        }

                                        #endregion
                                    }
                                    //TODO : Move this appointment to next first available empty turn
                                }
                            }
                        }
                    }

                    #region add or edit usual schedule
                    if (oldPlanForMedicalService == null)
                    {
                        _dbContext.UsualSchedulePlans.Add(new UsualSchedulePlan
                        {
                            DayOfWeek = dayOfWeek,
                            Shift = (ScheduleShift)model.Shift,
                            StartTime = model.From,
                            EndTime = model.To,
                            Prerequisite = model.PrerequisiteType,
                            MaxCount = model.MaxCount,
                            ValidFromDate = DateTime.Now,
                            ExpireDate = DateTime.Now.AddMonths(3),
                            ServiceSupplyId = model.ServiceSupplyId,
                            ShiftCenterServiceId = model.MedicalServiceId,
                            CreatedAt = DateTime.Now,
                        });
                    }
                    else
                    {
                        _dbContext.Entry(oldPlanForMedicalService).State = EntityState.Modified;
                        oldPlanForMedicalService.Shift = (ScheduleShift)model.Shift;
                        oldPlanForMedicalService.StartTime = model.From;
                        oldPlanForMedicalService.EndTime = model.To;
                        oldPlanForMedicalService.ServiceSupplyId = model.ServiceSupplyId;
                        oldPlanForMedicalService.ShiftCenterServiceId = model.MedicalServiceId;
                        oldPlanForMedicalService.Prerequisite = model.PrerequisiteType;
                        oldPlanForMedicalService.MaxCount = model.MaxCount;
                    }
                    #endregion

                    _iPAsManager.DeleteRange(tmpIpas);
                    _dbContext.SaveChanges();

                    userMessage = Messages.ItemAddedSuccessFully;
                    resultStatus = MVCResultStatus.success;
                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemAddedSuccessFully });
                }
                else
                {
                    if (model.From == null || model.To == null)
                    {
                        throw new AwroNoreException(Messages.StartingAndEndTimeNotValid);
                    }
                    else if (model.ServiceSupplyId == 0)
                    {
                        throw new AwroNoreException(Messages.NoDoctorSelected);
                    }
                    else if (model.MedicalServiceId == 0)
                    {
                        throw new AwroNoreException(Messages.NoHealthServiceSelected);
                    }
                    else
                    {
                        throw new AwroNoreException(Messages.ErrorOccuredWhileDoneAction);
                    }
                }
            }
            catch (Exception ex)
            {
                userMessage = ex.Message;
                resultStatus = MVCResultStatus.danger;
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = ex.Message });
            }
            return RedirectToAction("SettingUsualPlan", "Scheduling", new { area = "", polyclinicId = model.PolyclinicId, userMessage, resultStatus });
        }        

        [HttpGet]
        public JsonResult GetPolyclinicDoctors(int? polyclinicId)
        {
            var polyclinic = _polyclinicService.GetShiftCenterForArea((int)polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

            var serviceSupplies = polyclinic.ServiceSupplies.ToList();

            var doctors = serviceSupplies.Where(x => x.IsAvailable).Select(x => new
            {
                x.Id,
                Name = x.Person.FullName
            }).ToList();

            return Json(doctors);
        }

        [HttpGet]
        public JsonResult GetPolyclinicHealthServices(int? polyclinicId)
        {
            var polyclinic = _polyclinicService.GetShiftCenterForArea((int)polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

            var healthServices = polyclinic.PolyclinicHealthServices.Select(x => new
            {
                x.Id,
                Name = Lng == Lang.KU ? x.Service.Name_Ku : x.Service.Name_Ar
            }).ToList();

            return Json(healthServices);
        }

        [HttpGet]
        public JsonResult GetUsualPlan(int? polyclinicId, int? serviceSupplyId, int? healthServiceId)
        {
            var polyclinic = _polyclinicService.GetShiftCenterForArea((int)polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

            var serviceSupply = _serviceSupplyService.GetServiceSupplyForArea((int)serviceSupplyId);

            if (serviceSupply == null) throw new Exception(Messages.DoctorNotFound);

            var plans = _dbContext.UsualSchedulePlans.Where(x => x.ServiceSupplyId == serviceSupply.Id && x.ShiftCenterServiceId == healthServiceId);

            #region Saturday
            var saturdayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Saturday);
            var saturdayMorning = saturdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var saturdayEvening = saturdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var saturday = new
            {
                Morning = new
                {
                    Id = saturdayMorning != null ? saturdayMorning.Id : 0,
                    Enabled = saturdayMorning != null,
                    StartTime = saturdayMorning != null ? saturdayMorning.StartTime : "08:00",
                    EndTime = saturdayMorning != null ? saturdayMorning.EndTime : "14:00",
                    MaxCount = saturdayMorning != null ? saturdayMorning.MaxCount : 0,
                    Prerequisite = saturdayMorning != null ? saturdayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = saturdayMorning != null ? saturdayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == saturdayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = saturdayEvening != null ? saturdayEvening.Id : 0,
                    Enabled = saturdayEvening != null,
                    StartTime = saturdayEvening != null ? saturdayEvening.StartTime : "14:00",
                    EndTime = saturdayEvening != null ? saturdayEvening.EndTime : "20:00",
                    MaxCount = saturdayEvening != null ? saturdayEvening.MaxCount : 0,
                    Prerequisite = saturdayEvening != null ? saturdayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = saturdayEvening != null ? saturdayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == saturdayEvening.Id) : 0
                },
            };
            #endregion

            #region Sunday
            var sundayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Sunday);
            var sundayMorning = sundayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var sundayEvening = sundayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var sunday = new
            {
                Morning = new
                {
                    Id = sundayMorning != null ? sundayMorning.Id : 0,
                    Enabled = sundayMorning != null,
                    StartTime = sundayMorning != null ? sundayMorning.StartTime : "08:00",
                    EndTime = sundayMorning != null ? sundayMorning.EndTime : "14:00",
                    MaxCount = sundayMorning != null ? sundayMorning.MaxCount : 0,
                    Prerequisite = sundayMorning != null ? sundayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = sundayMorning != null ? sundayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == sundayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = sundayEvening != null ? sundayEvening.Id : 0,
                    Enabled = sundayEvening != null,
                    StartTime = sundayEvening != null ? sundayEvening.StartTime : "14:00",
                    EndTime = sundayEvening != null ? sundayEvening.EndTime : "20:00",
                    MaxCount = sundayEvening != null ? sundayEvening.MaxCount : 0,
                    Prerequisite = sundayEvening != null ? sundayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = sundayEvening != null ? sundayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == sundayEvening.Id) : 0
                },
            };
            #endregion

            #region Monday
            var mondayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Monday);
            var mondayMorning = mondayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var mondayEvening = mondayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var monday = new
            {
                Morning = new
                {
                    Id = mondayMorning != null ? mondayMorning.Id : 0,
                    Enabled = mondayMorning != null,
                    StartTime = mondayMorning != null ? mondayMorning.StartTime : "08:00",
                    EndTime = mondayMorning != null ? mondayMorning.EndTime : "14:00",
                    MaxCount = mondayMorning != null ? mondayMorning.MaxCount : 0,
                    Prerequisite = mondayMorning != null ? mondayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = mondayMorning != null ? mondayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == mondayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = mondayEvening != null ? mondayEvening.Id : 0,
                    Enabled = mondayEvening != null,
                    StartTime = mondayEvening != null ? mondayEvening.StartTime : "14:00",
                    EndTime = mondayEvening != null ? mondayEvening.EndTime : "20:00",
                    MaxCount = mondayEvening != null ? mondayEvening.MaxCount : 0,
                    Prerequisite = mondayEvening != null ? mondayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = mondayEvening != null ? mondayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == mondayEvening.Id) : 0
                },
            };
            #endregion

            #region Tuesday
            var tuesdayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Tuesday);
            var tuesdayMorning = tuesdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var tuesdayEvening = tuesdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var tuesday = new
            {
                Morning = new
                {
                    Id = tuesdayMorning != null ? tuesdayMorning.Id : 0,
                    Enabled = tuesdayMorning != null,
                    StartTime = tuesdayMorning != null ? tuesdayMorning.StartTime : "08:00",
                    EndTime = tuesdayMorning != null ? tuesdayMorning.EndTime : "14:00",
                    MaxCount = tuesdayMorning != null ? tuesdayMorning.MaxCount : 0,
                    Prerequisite = tuesdayMorning != null ? tuesdayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = tuesdayMorning != null ? tuesdayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == tuesdayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = tuesdayEvening != null ? tuesdayEvening.Id : 0,
                    Enabled = tuesdayEvening != null,
                    StartTime = tuesdayEvening != null ? tuesdayEvening.StartTime : "14:00",
                    EndTime = tuesdayEvening != null ? tuesdayEvening.EndTime : "20:00",
                    MaxCount = tuesdayEvening != null ? tuesdayEvening.MaxCount : 0,
                    Prerequisite = tuesdayEvening != null ? tuesdayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = tuesdayEvening != null ? tuesdayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == tuesdayEvening.Id) : 0
                },
            };
            #endregion

            #region Wednesday
            var wednesdayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Wednesday);
            var wednesdayMorning = wednesdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var wednesdayEvening = wednesdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var wednesday = new
            {
                Morning = new
                {
                    Id = wednesdayMorning != null ? wednesdayMorning.Id : 0,
                    Enabled = wednesdayMorning != null,
                    StartTime = wednesdayMorning != null ? wednesdayMorning.StartTime : "08:00",
                    EndTime = wednesdayMorning != null ? wednesdayMorning.EndTime : "14:00",
                    MaxCount = wednesdayMorning != null ? wednesdayMorning.MaxCount : 0,
                    Prerequisite = wednesdayMorning != null ? wednesdayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = wednesdayMorning != null ? wednesdayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == wednesdayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = wednesdayEvening != null ? wednesdayEvening.Id : 0,
                    Enabled = wednesdayEvening != null,
                    StartTime = wednesdayEvening != null ? wednesdayEvening.StartTime : "14:00",
                    EndTime = wednesdayEvening != null ? wednesdayEvening.EndTime : "20:00",
                    MaxCount = wednesdayEvening != null ? wednesdayEvening.MaxCount : 0,
                    Prerequisite = wednesdayEvening != null ? wednesdayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = wednesdayEvening != null ? wednesdayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == wednesdayEvening.Id) : 0
                },
            };
            #endregion

            #region Thursday
            var thursdayPlans = plans.Where(x => x.DayOfWeek == DayOfWeek.Thursday);
            var thursdayMorning = thursdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Morning);
            var thursdayEvening = thursdayPlans.FirstOrDefault(x => x.Shift == ScheduleShift.Evening);
            var thursday = new
            {
                Morning = new
                {
                    Id = thursdayMorning != null ? thursdayMorning.Id : 0,
                    Enabled = thursdayMorning != null,
                    StartTime = thursdayMorning != null ? thursdayMorning.StartTime : "08:00",
                    EndTime = thursdayMorning != null ? thursdayMorning.EndTime : "14:00",
                    MaxCount = thursdayMorning != null ? thursdayMorning.MaxCount : 0,
                    Prerequisite = thursdayMorning != null ? thursdayMorning.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = thursdayMorning != null ? thursdayMorning.UsualScheduleInsurances.Count(x => x.ScheduleId == thursdayMorning.Id) : 0
                },
                Evening = new
                {
                    Id = thursdayEvening != null ? thursdayEvening.Id : 0,
                    Enabled = thursdayEvening != null,
                    StartTime = thursdayEvening != null ? thursdayEvening.StartTime : "14:00",
                    EndTime = thursdayEvening != null ? thursdayEvening.EndTime : "20:00",
                    MaxCount = thursdayEvening != null ? thursdayEvening.MaxCount : 0,
                    Prerequisite = thursdayEvening != null ? thursdayEvening.Prerequisite : PrerequisiteType.WithoutPrerequisite,
                    Insurances = thursdayEvening != null ? thursdayEvening.UsualScheduleInsurances.Count(x => x.ScheduleId == thursdayEvening.Id) : 0
                },
            };
            #endregion

            var prerequisiteTypes = Enum.GetValues(typeof(PrerequisiteType)).Cast<PrerequisiteType>().ToList();

            var listPrerequisites = from p in prerequisiteTypes
                                    select new
                                    {
                                        Id = prerequisiteTypes.IndexOf(p),
                                        Name = p.ToString()
                                    };

            var plan = new
            {
                Saturday = saturday,
                Sunday = sunday,
                Monday = monday,
                Tuesday = tuesday,
                Wednesday = wednesday,
                Thursday = thursday,
                Prerequisites = listPrerequisites
            };

            return Json(plan);
        }

        [HttpPost]
        public JsonResult SaveShift(ShiftSaveModel model)
        {
            var success = false;
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    #region validation
                    if (model.Enabled)
                    {
                        if (model.Shift == ScheduleShift.Morning)
                        {
                            var morningFrom = DateTime.Parse(model.StartTime);
                            var morningTo = DateTime.Parse(model.EndTime);

                            if (!((morningFrom == Defaults.MorningStart || morningFrom > Defaults.MorningStart) && (morningFrom < Defaults.MorningEnd)))
                            {
                                throw new Exception(Messages.MorningShiftStartNotValid);
                            }

                            if (!((morningTo == Defaults.MorningEnd || morningTo < Defaults.MorningEnd) && (morningTo > Defaults.MorningStart)))
                            {
                                throw new Exception(Messages.MorningShiftEndNotValid);
                            }
                        }
                        else if (model.Shift == ScheduleShift.Evening)
                        {
                            var eveningFrom = DateTime.Parse(model.StartTime);
                            var eveningTo = DateTime.Parse(model.EndTime);

                            if (!((eveningFrom == Defaults.EveningStart || eveningFrom > Defaults.EveningStart) && (eveningFrom < Defaults.EveningEnd)))
                            {
                                throw new Exception(Messages.EveningShitStartNotValid);
                            }

                            if (!((eveningTo == Defaults.EveningEnd || eveningTo < Defaults.EveningEnd) && (eveningTo > Defaults.EveningStart)))
                            {
                                throw new Exception(Messages.EveningShiftEndNotValid);

                            }
                        }
                        var maxCapacity = _scheduleManager.CalculateRemainedReservaableAppointsCount(model.DayOfWeek, (int)model.Shift, model.StartTime, model.EndTime, model.ServiceSupplyId, model.HealthServiceId);
                        if (model.MaxCount < 1)
                        {
                            throw new Exception(Messages.CapacityIsSmallerThanRequested);
                        }
                    }
                    #endregion

                    #region init variables                   
                    var dayOfWeekPersian = Utils.ConvertDayOfWeek(model.DayOfWeek.ToString());
                    #endregion

                    var polyclinic = _polyclinicService.GetShiftCenterForArea(model.PolyclinicId);

                    if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

                    var serviceSupply = _serviceSupplyService.GetServiceSupplyForArea(model.ServiceSupplyId);

                    if (serviceSupply == null) throw new Exception(Messages.DoctorNotFound);

                    var tmpIpas = new List<IPAModel>();

                    var oldPlanForDayOfWeek = (from p in _dbContext.UsualSchedulePlans
                                               where p.DayOfWeek == model.DayOfWeek &&
                                                     p.ServiceSupplyId == model.ServiceSupplyId &&
                                                     p.ShiftCenterServiceId == model.HealthServiceId &&
                                                     p.Shift == model.Shift
                                               select p).FirstOrDefault();

                    if (oldPlanForDayOfWeek == null)
                    {
                        //:: Save New Plan
                        if (model.Enabled)
                        {
                            var usualPlan = new UsualSchedulePlan
                            {
                                DayOfWeek = model.DayOfWeek,
                                Shift = model.Shift,
                                StartTime = model.StartTime,
                                EndTime = model.EndTime,
                                Prerequisite = model.Prerequisite,
                                MaxCount = model.MaxCount,
                                ValidFromDate = DateTime.Now,
                                ExpireDate = DateTime.Now.AddYears(3),
                                ServiceSupplyId = model.ServiceSupplyId,
                                ShiftCenterServiceId = model.HealthServiceId,
                                CreatedAt = DateTime.Now,
                            };
                            _dbContext.UsualSchedulePlans.Add(usualPlan);
                            _dbContext.SaveChanges();
                            success = true;
                            message = Messages.ItemAddedSuccessFully;
                        }
                    }

                    else
                    {
                        #region get pending appointments for dayofweek
                        var shiftStartHour = model.Shift == ScheduleShift.Morning ? Defaults.MorningStart.Hour : Defaults.EveningStart.Hour;
                        var shiftStartMinute = model.Shift == ScheduleShift.Morning ? Defaults.MorningStart.Minute : Defaults.EveningStart.Minute;
                        var shiftEndHour = model.Shift == ScheduleShift.Morning ? Defaults.MorningEnd.Hour : Defaults.EveningEnd.Hour;
                        var shiftEndMinute = model.Shift == ScheduleShift.Morning ? Defaults.MorningEnd.Minute : Defaults.EveningEnd.Minute;

                        var shiftStartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shiftStartHour, shiftStartMinute, 0);
                        var shiftEndDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shiftEndHour, shiftEndMinute, 0);

                        var pendingAppoints = (from a in _dbContext.Appointments
                                               where a.ServiceSupplyId == model.ServiceSupplyId &&
                                                     a.ServiceSupply.ShiftCenterId == polyclinic.Id &&
                                                     a.Status == AppointmentStatus.Pending &&
                                                     a.ShiftCenterServiceId == model.HealthServiceId &&
                                                     a.Start_DateTime.TimeOfDay >= shiftStartDateTime.TimeOfDay &&
                                                     a.Start_DateTime.TimeOfDay <= shiftEndDateTime.TimeOfDay
                                               select a)
                                    .AsEnumerable()
                                    .Where(x => x.Start_DateTime.DayOfWeek == model.DayOfWeek)
                                    .OrderBy(a => a.Start_DateTime)
                                    .Distinct(new AppointmentComprarer())
                                    .ToList();
                        #endregion

                        //:: Update Plan
                        if (model.Enabled)
                        {
                            if (pendingAppoints.Count > 0)
                            {
                                //var smsService = new Send();

                                var appointsDates = pendingAppoints.Select(x => x.Start_DateTime.Date).Distinct().OrderBy(x => x).ToList();

                                foreach (var date in appointsDates)
                                {
                                    var startTime = DateTime.Parse(date.ToShortDateString() + " " + model.StartTime);
                                    var endTime = DateTime.Parse(date.ToShortDateString() + " " + model.EndTime);
                                    var duration = (int)Math.Ceiling(((endTime - startTime).TotalMinutes) / model.MaxCount);
                                    var periods = _doctorServiceManager.Calculate_Bookable_TimePeriods(startTime, endTime, duration);

                                    var appointsInDate = pendingAppoints.Where(x => x.Start_DateTime.Date == date).OrderBy(x => x.Start_DateTime).ToList();

                                    var appointsToRemain = appointsInDate.Take(model.MaxCount).ToList();
                                    var overFlowedAppoints = appointsInDate.Skip(model.MaxCount).ToList();

                                    foreach (var appointment in appointsToRemain)
                                    {
                                        //var qNum = appointmentService.GetQueueNumberForAppointment(model.ServiceSupplyId, (int)appointment.Id, date.ToShortDateString());
                                        var qNum = appointsToRemain.FindIndex(x => x.Id == appointment.Id);

                                        //var newPeriodTime = periods.ElementAt(qNum - 1);
                                        var newPeriodTime = periods.ElementAt(qNum);

                                        _dbContext.Entry(appointment).State = EntityState.Modified;
                                        appointment.Start_DateTime = newPeriodTime.StartDateTime;
                                        appointment.End_DateTime = newPeriodTime.EndDateTime;

                                        //TODO: Send SMS notification that appointment time changed
                                    }

                                    if (overFlowedAppoints.Count > 0)
                                    {
                                        var appointmentsToCancel = new List<Appointment>();

                                        foreach (var appointment in overFlowedAppoints)
                                        {
                                            var nextEmptyPeriod = _doctorServiceManager.Find_First_Empty_TimePeriod_From_DateTime(appointment.ServiceSupply, startTime.AddDays(1), appointment.ShiftCenterService);
                                            if (nextEmptyPeriod != null)
                                            {
                                                var ipa = new IPAModel
                                                {
                                                    ServiceSupplyId = appointment.ServiceSupplyId,
                                                    IsForSelectedDoctor = appointment.ServiceSupply.ShiftCenter.IsIndependent,
                                                    AddedAt = DateTime.Now,
                                                    PolyclinicHealthService = appointment.ShiftCenterService,
                                                    StartDateTime = nextEmptyPeriod.StartDateTime,
                                                    EndDateTime = nextEmptyPeriod.EndDateTime
                                                };
                                                if (_doctorServiceManager.IsAvailableEmptyTimePeriod(ipa.ServiceSupplyId, ipa.StartDateTime, ipa.EndDateTime, ipa.PolyclinicHealthService))
                                                {
                                                    _iPAsManager.Insert(ipa);
                                                    tmpIpas.Add(ipa);

                                                    var oldDate = appointment.Start_DateTime.ToShortDateString();

                                                    _dbContext.Entry(appointment).State = EntityState.Modified;
                                                    appointment.Start_DateTime = nextEmptyPeriod.StartDateTime;
                                                    appointment.End_DateTime = nextEmptyPeriod.EndDateTime;

                                                    var doctorName = $"{appointment.ServiceSupply.Person.FullName}";
                                                    var smsBody = $"{Messages.AccordingToChangeDoctorSchedule} {doctorName} {Messages.YourTurnFromDate} {oldDate} {Messages.ToDate} {appointment.Start_DateTime.ToShortTimeString()} {Messages.HasBeenTransmitted}";

                                                    var status = new byte[1];
                                                    var recId = new long[1];
                                                    string[] recepient = { $"964{appointment.Person.Mobile}" };

                                                    _plivoService.SendMessage(recepient.ToList(), message);
                                                    if (0 == 0)
                                                    {
                                                        if (status.FirstOrDefault() == 0)
                                                        {
                                                            _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                                                            {
                                                                Type = MessageType.SMS,
                                                                Category = MessageCategory.Announcement,
                                                                About = MessageActionAbout.CancelAppointment,
                                                                SendingDate = DateTime.Now,
                                                                Recipient = recepient.FirstOrDefault(),
                                                                MessageBody = smsBody,
                                                                MessageId = recId.FirstOrDefault(),
                                                                MessageStatus = 100, //وضعیت دلیوری نامشخص
                                                                ShiftCenterId = appointment.ServiceSupply.ShiftCenterId,
                                                                ReceiverPersonId = appointment.PersonId,
                                                                SenderUserName = CurrentUserName,
                                                                AppointmentId = appointment.Id,
                                                                CreatedAt = DateTime.Now
                                                            });
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception(Messages.EmptyTimePeriodNotValid);
                                                }

                                            }
                                            else
                                            {
                                                appointmentsToCancel.Add(appointment);
                                            }
                                        }

                                        if (appointmentsToCancel.Count > 0)
                                        {
                                            var recipients = appointmentsToCancel.Select(a => "964" + a.Person.Mobile).ToArray();
                                            var userRecivers = appointmentsToCancel.Select(a => a.PersonId).ToArray();
                                            var appointmentIds = appointmentsToCancel.Select(a => a.Id).ToArray();

                                            var firstAppoint = appointmentsToCancel.FirstOrDefault();
                                            var doctorName = firstAppoint.ServiceSupply.Person.FullName;
                                            var smsBody = $"{Messages.AccordingToChangeDoctorSchedule} {doctorName} {Global.Turn} {firstAppoint.Start_DateTime.ToShortDateString()} {Messages.WillBeCanceled}";

                                            foreach (var item in appointmentsToCancel)
                                            {
                                                _dbContext.Entry(item).State = EntityState.Modified;
                                                item.Status = AppointmentStatus.Canceled;
                                                item.IsDeleted = true;
                                            }

                                            #region send sms notification
                                            var status = new byte[recipients.Length];
                                            var recId = new long[recipients.Length];

                                            _plivoService.SendMessage(recipients.ToList(), message);
                                            if (0 == 0)
                                            {
                                                for (var i = 0; i < recipients.Length; i++)
                                                {
                                                    if (status[i] == 0)
                                                    {
                                                        _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                                                        {
                                                            Type = MessageType.SMS,
                                                            Category = MessageCategory.Announcement,
                                                            About = MessageActionAbout.CancelAppointment,
                                                            SendingDate = DateTime.Now,
                                                            Recipient = recipients[i],
                                                            MessageBody = smsBody,
                                                            MessageId = recId[i],
                                                            MessageStatus = 100, //وضعیت دلیوری نامشخص
                                                            ShiftCenterId = model.PolyclinicId,
                                                            ReceiverPersonId = userRecivers[i],
                                                            SenderUserName = CurrentUserName,
                                                            AppointmentId = appointmentIds[i],
                                                            CreatedAt = DateTime.Now
                                                        });
                                                    }
                                                }
                                            }

                                            #endregion
                                        }
                                        //TODO : Move this appointment to next first available empty turn
                                    }
                                }
                            }

                            _dbContext.Entry(oldPlanForDayOfWeek).State = EntityState.Modified;
                            oldPlanForDayOfWeek.Shift = model.Shift;
                            oldPlanForDayOfWeek.StartTime = model.StartTime;
                            oldPlanForDayOfWeek.EndTime = model.EndTime;
                            oldPlanForDayOfWeek.ServiceSupplyId = model.ServiceSupplyId;
                            oldPlanForDayOfWeek.ShiftCenterServiceId = model.HealthServiceId;
                            oldPlanForDayOfWeek.Prerequisite = model.Prerequisite;
                            oldPlanForDayOfWeek.MaxCount = model.MaxCount;

                            _dbContext.SaveChanges();
                            success = true;
                            message = Messages.ItemUpdatedSuccessFully;
                        }

                        //:: Delete Plan
                        else
                        {
                            _dbContext.UsualSchedulePlans.Remove(oldPlanForDayOfWeek);

                            _dbContext.SaveChanges();
                            success = true;
                            message = Messages.ScheduleDeActiveSuccessfully;
                        }
                    }
                }

                else
                    throw new Exception(Messages.PleaseEnterAllRequestedData);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }

            return Json(new { Success = success, Message = message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUsualPlan(int? id, int? shift, int? polyclinicId)
        {
            if (id == null || shift == null || polyclinicId == null) throw new ArgumentNullException();

            try
            {
                var polyclinic = _polyclinicService.GetShiftCenterForArea((int)polyclinicId);

                if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

                var usualPlan = _scheduleService.GetUsualScheduleById((int)id, (int)polyclinicId);

                var serviceSupplyId = usualPlan.ServiceSupplyId;

                var pendingAppoints = _appointmentService.GetAllAppointmentsForPolyclinicInDayOfWeek((int)polyclinicId, serviceSupplyId, AppointmentStatus.Pending, usualPlan.DayOfWeek.ToString(), (ScheduleShift)shift);

                if (shift == 0)
                {
                    if (pendingAppoints.Count <= 0)
                    {
                        if (usualPlan.Shift == ScheduleShift.Morning)
                        {
                            _scheduleService.DeleteUsualSchedule(usualPlan);
                        }
                    }
                    else
                    {
                        //TODO: --------------------------------------------------------
                        //throw new Exception("برای این برنامه زمانی نوبت های منتظر انجام وجود دارد");

                        _scheduleService.DeleteUsualSchedule(usualPlan);
                    }

                }
                else
                {

                    if (pendingAppoints.Count <= 0)
                    {
                        if (usualPlan.Shift == ScheduleShift.Evening)
                        {
                            _scheduleService.DeleteUsualSchedule(usualPlan);
                        }
                    }
                    else
                    {
                        //TODO: --------------------------------------------------------
                        //throw new Exception("برای این برنامه زمانی نوبت های منتظر انجام وجود دارد");                       
                        _scheduleService.DeleteUsualSchedule(usualPlan);
                    }
                }

                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemDeletedSuccessFully });
            }
            catch
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
            };
            return RedirectToAction("SettingUsualPlan", "Scheduling", new { area = "", polyclinicId });
        }
        #endregion

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult GetRemainedAppointsCount(string dayOfWeek, int shift, string from, string to, int serviceSupplyId, int medicalServiceId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }

            try
            {
                var _dayOfWeek = Utils.ConvertStringToDayOfWeek(dayOfWeek);

                var count = _scheduleManager.CalculateRemainedReservaableAppointsCount(_dayOfWeek, shift, from, to, serviceSupplyId, medicalServiceId);

                var result = new
                {
                    Count = count
                };

                var javaScriptSerializer = new JavaScriptSerializer();

                var jsonResult = javaScriptSerializer.Serialize(result);

                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }

        [HttpGet]
        //[NoDirectAccess]
        public async Task<IActionResult> GetInsurances()
        {
            var insurances = await _insuranceService.GetAllInsurancesAsync();

            var result = insurances.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
            }).ToList();

            return Json(result);
        }

        [HttpGet]
        //[NoDirectAccess]
        public async Task<IActionResult> GetDoctorScheduleInsurances(int serviceSupplyId, DayOfWeek dayOfWeek, ScheduleShift shift)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }

            var result = new List<ScheduleInsurancesModel>();

            var plan = await _usualScheduleService.GetUsualSchedulePlanAsync(serviceSupplyId, dayOfWeek, shift);

            if (plan != null)
            {
                result = plan.UsualScheduleInsurances.Select(x => new ScheduleInsurancesModel
                {
                    Id = x.Id,
                    Name = Lng == Lang.KU ? x.Insurance.Insurance.Name_Ku : x.Insurance.Insurance.Name_Ar,
                    Capacity = x.AdmissionCapacity
                }).ToList();
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsualPlanInsurance(InsertScheduleInsurancesModel model)
        {            
            if (ModelState.IsValid)
            {
                var exist = await _scheduleInsuranceService.IsExistsAsync(model.ScheduleId, model.InsuranceId);

                if (exist) return Json(new { Success = false, Message = "Insurance Already Added" });

                var scheduleInsurance = new UsualScheduleInsurances
                {
                    ServiceSupplyInsuranceId = model.InsuranceId,
                    ScheduleId = model.ScheduleId,
                    AdmissionCapacity = model.Capacity,
                    CreatedAt = DateTime.Now,
                };
                await _scheduleInsuranceService.InsertUsualScheduleInsuranceAsync(scheduleInsurance);

                return Json(new { Success = true, Message = "Success" });
            }

            return Json(new { Success = false, Message = Messages.PleaseEnterAllRequestedData });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteScheduleInsurance(int id)
        {
            var result = false;
            var message = Messages.ItemDeletedSuccessFully;
            try
            {
                await _scheduleInsuranceService.DeleteUsualScheduleInsuranceAsync(id);

                result = true;
            }
            catch (EntityNotFoundException ex)
            {
                message = ex.Message;
            }
            catch
            {
                message = Messages.AnErrorOccuredWhileDeleteItem;
            }

            return Json(new { Success = result, Message = message });
        }
    }
}