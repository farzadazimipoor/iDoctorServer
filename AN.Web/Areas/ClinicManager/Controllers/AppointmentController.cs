using AN.BLL.Core.Appointments;
using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.Persons;
using AN.BLL.Helpers;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.Global;
using AN.DAL;
using AN.Web.Areas.ClinicManager.Models;
using AN.Web.Areas.Public.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using NLog;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AN.Web.AppCode.Extensions;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class AppointmentController : ClinicManagerController
    {
        #region Fields
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IScheduleManager _scheduleManager;
        private readonly IIPAsManager _iPAsManager;
        private readonly IServiceSupplyManager _serviceSupplyManager;
        private readonly IAppointmentsManager _appointmentsManager;
        private readonly IPlivoService _plivoService;
        private readonly IClinicService _clinicService;
        private readonly IShiftCenterMessageService _polyclinicMessageService;
        private readonly IPersonService _userService;
        private readonly JavaScriptSerializer javaScriptSerializer;
        private static Logger logger;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public AppointmentController(IServiceSupplyService serviceSupplyService,
                                    IAppointmentsManager appointmentsManager,
                                    IPlivoService plivoService,
                                    IDoctorServiceManager doctorServiceManager,
                                    IScheduleManager scheduleManager,
                                    IIPAsManager iPAsManager,
                                    IServiceSupplyManager serviceSupplyManager,
                                    IClinicService clinicService,
                                    IShiftCenterMessageService polyclinicMessageService,
                                    IPersonService userService,
                                    BanobatDbContext dbContext) : base(clinicService)
        {
            _serviceSupplyService = serviceSupplyService;
            _appointmentsManager = appointmentsManager;
            _plivoService = plivoService;
            _doctorServiceManager = doctorServiceManager;
            _scheduleManager = scheduleManager;
            _iPAsManager = iPAsManager;
            _serviceSupplyManager = serviceSupplyManager;
            _clinicService = clinicService;
            _polyclinicMessageService = polyclinicMessageService;
            _userService = userService;
            logger = LogManager.GetCurrentClassLogger();
            javaScriptSerializer = new JavaScriptSerializer();
            _dbContext = dbContext;
        }
        #endregion

        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DoctorNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var appointments = from a in _dbContext.Appointments
                               where a.ServiceSupply.ShiftCenter.ClinicId == CurrentClinic.Id && !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed
                               select new CMAppointmentsViewModel
                               {
                                   Id = a.Id,
                                   Status = a.Status,
                                   ReservationChannel = a.ReservationChannel,
                                   StartDateTime = a.Start_DateTime,
                                   PatientName = a.Person.FirstName + " " + a.Person.SecondName + " " + a.Person.ThirdName,
                                   PatientMobile = a.Person.Mobile,
                                   DoctorName = a.ServiceSupply.Person.FirstName + " " + a.ServiceSupply.Person.SecondName + " " + a.ServiceSupply.Person.ThirdName,
                                   HealthServiceName = a.ShiftCenterService != null ? (Lng == Core.Enums.Lang.KU ? a.ShiftCenterService.Service.Name_Ku : a.ShiftCenterService.Service.Name_Ar) : "",
                                   ServiceSupplyId = a.ServiceSupplyId
                               };

            if (!string.IsNullOrEmpty(searchString))
            {
                appointments = appointments.Where(a =>
                a.PatientName.Contains(searchString) ||
                a.PatientNationaCode.Contains(searchString) ||
                a.DoctorName.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appointments = appointments.OrderByDescending(a => a.DoctorName);
                    break;
                case "Date":
                    appointments = appointments.OrderBy(a => a.StartDateTime);
                    break;
                case "date_desc":
                    appointments = appointments.OrderByDescending(a => a.StartDateTime);
                    break;
                default:
                    appointments = appointments.OrderByDescending(a => a.StartDateTime);
                    break;
            }

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(appointments.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Today(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DoctorNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TurnSortParam = sortOrder == "Turn" ? "turn_desc" : "Turn";
            ViewBag.PatientNameSortParam = sortOrder == "PatientName" ? "pname_desc" : "PatientName";
            ViewBag.HealthServiceSortParam = sortOrder == "HealthService" ? "healthservice_desc" : "HealthService";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var appointments = from a in _dbContext.Appointments
                               where a.ServiceSupply.ShiftCenter.ClinicId == CurrentClinic.Id &&
                                     !a.IsDeleted &&
                                     a.Paymentstatus != PaymentStatus.NotPayed &&
                                     a.Start_DateTime.Date == DateTime.Now.Date
                               select new CMAppointmentsViewModel
                               {
                                   Status = a.Status,
                                   StartDateTime = a.Start_DateTime,
                                   PatientName = a.Person.FirstName + " " + a.Person.SecondName + " " + a.Person.ThirdName,
                                   PatientMobile = a.Person.Mobile,
                                   DoctorName = a.ServiceSupply.Person.FirstName + " " + a.ServiceSupply.Person.SecondName + " " + a.ServiceSupply.Person.ThirdName,
                                   HealthServiceName = a.ShiftCenterService != null ? (Lng == Core.Enums.Lang.KU ? a.ShiftCenterService.Service.Name_Ku : a.ShiftCenterService.Service.Name_Ar) : ""
                               };

            if (!string.IsNullOrEmpty(searchString))
            {
                appointments = appointments.Where(a =>
                a.PatientName.Contains(searchString) ||
                a.PatientNationaCode.Contains(searchString) ||
                a.DoctorName.Contains(searchString) ||
                (a.HealthServiceName != "" && a.HealthServiceName.Contains(searchString))
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appointments = appointments.OrderByDescending(a => a.DoctorName);
                    break;
                case "Turn":
                    appointments = appointments.OrderBy(a => a.StartDateTime);
                    break;
                case "turn_desc":
                    appointments = appointments.OrderByDescending(a => a.StartDateTime);
                    break;
                case "PatientName":
                    appointments = appointments.OrderBy(a => a.PatientName);
                    break;
                case "pname_desc":
                    appointments = appointments.OrderByDescending(a => a.PatientName);
                    break;
                case "HealthService":
                    appointments = appointments.OrderBy(a => a.HealthServiceName);
                    break;
                case "healthservice_desc":
                    appointments = appointments.OrderByDescending(a => a.HealthServiceName);
                    break;
                default:
                    appointments = appointments.OrderBy(a => a.DoctorName);
                    break;
            }

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(appointments.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(int? id, AppointmentStatus status, bool isReservable)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            try
            {
                //باید فقط از میان نوبت های مطب جاری به دنبال نوبت با شماره موردنظر بگردیم
                //چون اگر جست و جو از میان همه نوبت ها باشد 
                var appointment = await _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id && x.ServiceSupply.ShiftCenter.ClinicId == CurrentClinic.Id && x.Status != status && !x.IsDeleted);

                if (appointment == null) throw new EntityNotFoundException();

                //keep this id before appointment removed
                var userReciverId = appointment.PersonId;
                var smsBody = "";
                string[] recepient = { $"964{appointment.Person.Mobile}" };
                var statuses = new byte[recepient.Length];
                var recId = new long[recepient.Length];

                var action = status == AppointmentStatus.Done ? Core.Resources.EntitiesResources.Messages.HasDone : Core.Resources.EntitiesResources.Messages.HasCanceled;

                smsBody = Global.Turn + " " + appointment.Start_DateTime.ToShortDateString() + Global.PolyclinicPrefix + " " + (Lng == Core.Enums.Lang.KU ? appointment.ServiceSupply.ShiftCenter.Name_Ku : appointment.ServiceSupply.ShiftCenter.Name_Ar) + " " + action;

                _dbContext.Entry(appointment).State = EntityState.Modified;
                appointment.Status = status;
                if (status == AppointmentStatus.Canceled && isReservable)
                {
                    appointment.IsDeleted = true;
                }

                try
                {
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
                await _dbContext.SaveChangesAsync();

                //var message = "نوبت مورخ " + appointment.Start_DateTime.ToShortDateString() + " ساعت " + appointment.Start_DateTime.ToShortTimeString() + " با موفقیت " + action;
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception)
            {
                var message = Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileDoneAction;
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = message });
                return Redirect(Request.Headers["Referer"].ToString());
                //return RedirectToAction("List", "Users", new { area = "Admin" });
            }
        }

        public IActionResult Reservation()
        {
            if (!IsHaveReserveAppointPermission()) throw new AwroNoreException(Core.Resources.EntitiesResources.Messages.YouDontHavePermission);

            return View();
        }

        public JsonResult GetServiceSuppliesForDateAndShift(string date, int? shift)
        {
            try
            {
                if (string.IsNullOrEmpty(date) || shift == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    return Json("Bad Request");
                }

                var _date = DateTime.Parse(date);

                var clinicDoctors = _serviceSupplyService.GetAllAvailableServiceSuppliesForClinic(CurrentClinic.Id);

                var doctors = (from d in clinicDoctors.AsEnumerable()
                               where _serviceSupplyManager.HaveWorkingSchedules(d, _date, (int)shift)
                               select new { d.Id, Name = $"{d.Person.FullName} - {(Lng == Core.Enums.Lang.KU ? d.ShiftCenter.Name_Ku : d.ShiftCenter.Name_Ar)}" }).ToList();

                var jsonResult = javaScriptSerializer.Serialize(doctors);

                return Json(jsonResult);

            }
            catch (Exception ex)
            {
                return Json(new { Error = true, ex.Message });
            }
        }

        public JsonResult GetAppointmentsForDateAndShift(int? serviceSupplyId, string date, int? shift, int? polyclinicHealthServiceId)
        {
            try
            {
                if (serviceSupplyId == null || string.IsNullOrEmpty(date) || shift == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Bad Request");
                }

                var serviceSupply = _serviceSupplyService.GetAllAvailableServiceSuppliesForClinic(CurrentClinic.Id).FirstOrDefault(s => s.Id == serviceSupplyId);
                if (serviceSupply == null)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.DoctorNotFound);

                ShiftCenterService polyclinicHealthService = null;
                if (polyclinicHealthServiceId == null || polyclinicHealthServiceId == 0)
                    polyclinicHealthService = serviceSupply.ShiftCenter.PolyclinicHealthServices.FirstOrDefault();
                else
                    serviceSupply.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(phs => phs.Id == polyclinicHealthServiceId);
                if (polyclinicHealthService == null)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.NoHealthServiceSelected);

                var _date = DateTime.Parse(date);

                var appointments = serviceSupply.Appointments.Where(a => a.Start_DateTime.Date == _date.Date && !a.IsDeleted);
                switch (shift)
                {
                    case 0:
                        appointments = appointments.Where(x => _scheduleManager.getScheduleShift(x.Start_DateTime, x.End_DateTime) == ScheduleShift.Morning).ToList();
                        break;
                    case 1:
                        appointments = appointments.Where(x => _scheduleManager.getScheduleShift(x.Start_DateTime, x.End_DateTime) == ScheduleShift.Evening).ToList();
                        break;
                }

                var allTimePeriods = Calculate_All_TimePeriods_Without_Limitation(serviceSupply, _date, polyclinicHealthService, (int)shift).Where(t => t.StartDateTime > DateTime.Now);
                if (allTimePeriods != null && allTimePeriods.Count() > 0)
                {
                    var _periods = allTimePeriods.Select(x => new ReservationAppointmentModel
                    {
                        Type = x.Type,
                        Time = x.StartDateTime.ToShortTimeString().Remove(2, 1) + x.EndDateTime.ToShortTimeString().Remove(2, 1),
                        PatientMobile = appointments.Where(a => a.Start_DateTime == x.StartDateTime && x.Type == TimePeriodType.Appointment).FirstOrDefault()?.Person.Mobile,
                        IsOutOfSchedule = false
                    }).ToList();
                    var outOfScheduleAppointments = from aa in appointments
                                                    where aa.Start_DateTime >= allTimePeriods.LastOrDefault().EndDateTime
                                                    select aa;
                    if (outOfScheduleAppointments.Count() > 0)
                    {
                        foreach (var item in outOfScheduleAppointments)
                        {
                            _periods.Add(new ReservationAppointmentModel
                            {
                                Type = TimePeriodType.Appointment,
                                Time = item.Start_DateTime.ToShortTimeString().Remove(2, 1) + item.End_DateTime.ToShortTimeString().Remove(2, 1),
                                PatientMobile = item.Person.Mobile,
                                IsOutOfSchedule = true
                            });
                        }
                    }
                    var result = new
                    {
                        Periods = _periods,
                        EmptiesCount = allTimePeriods.Count(e => e.Type == TimePeriodType.Empty),
                        PolyclinicHealthServices = serviceSupply.ShiftCenter.PolyclinicHealthServices.Select(x => new
                        {
                            Id = x.Id,
                            Name = x.Service.Name_Ku
                        })
                    };

                    return Json(javaScriptSerializer.Serialize(result));
                }
                else
                    throw new Exception(Core.Resources.EntitiesResources.Messages.ValidEmptyTimePeriodNotFound);

            }
            catch (Exception ex)
            {
                return Json(new { Error = true, ex.Message });
            }
        }

        [HttpPost]
        //[ValidateCustomAntiForgeryToken]
        //[NoDirectAccess]
        public JsonResult ReserveAppointment(int serviceSupplyId, string date, string time, int? polyclinicHealthServiceId)
        {
            try
            {
                if (!IsHaveReserveAppointPermission())
                    throw new Exception(Core.Resources.EntitiesResources.Messages.YouDontHavePermission);

                if (time.Length < 8)
                    time = "0" + time;

                var startTime = time.Substring(0, 4).Insert(2, ":");
                var endTime = time.Substring(4, 4).Insert(2, ":");

                if (serviceSupplyId == 0 || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(time))
                    throw new Exception("Bad Request");

                var startDateTime = DateTime.Parse(date + " " + startTime);
                var endDateTime = DateTime.Parse(date + " " + endTime);

                var _userHostAgent = Request.Headers["User-Agent"].ToString();

                if (startDateTime < DateTime.Now)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.TurnTimePassed);

                var serviceSupply = _serviceSupplyService.GetAllAvailableServiceSuppliesForClinic(CurrentClinic.Id).FirstOrDefault(x => x.Id == serviceSupplyId);
                if (serviceSupply == null || !serviceSupply.IsAvailable)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.DoctorIsNotActive);

                ShiftCenterService polyclinicHealthService = null;
                if (polyclinicHealthServiceId != null)
                {
                    polyclinicHealthService = serviceSupply.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(x => x.Id == polyclinicHealthServiceId);
                }
                if (polyclinicHealthService == null)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.PolyclinicDontHasHelathService);

                Schedule schedule = null;
                var schedules = _serviceSupplyManager.GetSchedulesByDateWithoutFilter(serviceSupply, startDateTime.Date, polyclinicHealthService);
                if (schedules != null && schedules.Count > 0)
                {
                    schedule = schedules.Where(s => s.Start_DateTime <= startDateTime && s.End_DateTime >= endDateTime).FirstOrDefault();
                }

                if (schedule != null && schedule.IsAvailable)
                {
                    var timePeriod = new TimePeriodModel
                    {
                        StartDateTime = startDateTime,
                        EndDateTime = endDateTime,
                        Duration = serviceSupply.Duration,
                        Type = TimePeriodType.Empty
                    };

                    var shift = (int)_scheduleManager.getScheduleShift(startDateTime, endDateTime);

                    if (IsEmptyTimePeriod(serviceSupply, timePeriod, polyclinicHealthService, shift))
                    {
                        var ipa = new IPAModel
                        {
                            AddedAt = DateTime.Now,
                            ServiceSupplyId = serviceSupplyId,
                            StartDateTime = startDateTime,
                            EndDateTime = endDateTime,
                            UserHostAgent = _userHostAgent,
                            IsForSelectedDoctor = false,
                            PolyclinicHealthService = polyclinicHealthService
                        };

                        _iPAsManager.Insert(ipa);

                        return Json(new
                        {
                            ReturnedData = ipa.AddedAt.ToString(),
                            Result = MyIActionResult.Success.ToString(),
                            Message = Core.Resources.EntitiesResources.Messages.TurnReservedSuccessfully
                        });
                    }
                    else
                    {
                        throw new Exception(Core.Resources.EntitiesResources.Messages.TurnIsInProgressNow);
                    }
                }

                throw new Exception(Core.Resources.EntitiesResources.Messages.ScheduleNotSpecifiedForDate);
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Message = ex.Message });
            }
        }

        [HttpPost]
        //[ValidateCustomAntiForgeryToken]
        //[NoDirectAccess]
        public JsonResult FinalBookAppointment(int serviceSupplyId, int healthServiceId, string date, string time, string mobile, string name, string family, bool reserveOutside, bool sendSms)
        {
            try
            {
                if (!IsHaveReserveAppointPermission())
                    throw new Exception(Core.Resources.EntitiesResources.Messages.YouDontHavePermission);

                #region initialize
                if (serviceSupplyId == 0 || healthServiceId == 0 || string.IsNullOrEmpty(date) || (!reserveOutside && string.IsNullOrEmpty(time)) || string.IsNullOrEmpty(mobile))
                {
                    throw new Exception(Core.Resources.EntitiesResources.Messages.PleaseEnterAllRequestedData);
                }

                var serviceSupply = _serviceSupplyService.GetAllAvailableServiceSuppliesForClinic(CurrentClinic.Id).FirstOrDefault(x => x.Id == serviceSupplyId);
                if (serviceSupply == null || !serviceSupply.IsAvailable)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.DoctorIsNotActive);

                var polyclinicHealthService = serviceSupply.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(x => x.Id == healthServiceId);
                if (polyclinicHealthService == null)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.PolyclinicDontHasHelathService);

                // Check if this patient has reserved appointment today or not?
                if (_appointmentsManager.HaveAppointmentForDate(date, mobile, serviceSupplyId, polyclinicHealthService.Id))
                {
                    throw new Exception(Core.Resources.EntitiesResources.Messages.MobileHasTurnForDate);
                }

                var _existUser = _userService.GetAll().FirstOrDefault(u => u.Mobile == mobile) != null;

                //Generate random password
                var RandomPassword = "Ap@123456"; //System.Web.Security.Membership.GeneratePassword(8, 0);

                var _patientModel = new PatientModel
                {
                    FirstName = " ",
                    SecondName = " ",
                    Mobile = mobile,
                    Email = mobile + "@awronore.krd",
                    Password = RandomPassword
                };

                //Needed data to send sms notification
                var doctor_name = serviceSupply.Person.FullName;
                var persian_dayOfWeek = "";
                var day_number = "";
                var persian_month = "";
                var year_number = "";
                string[] recepient = { $"964{_patientModel.Mobile}" };
                #endregion

                if (reserveOutside)
                {
                    #region reserve outside of schedule
                    var _date = DateTime.Parse(date);
                    var emptyPeriod = _doctorServiceManager.FindFirstEmptyTimePeriodInDate(serviceSupply, DateTime.Parse(date), polyclinicHealthService);
                    var appointment = serviceSupply.Appointments.Where(x => x.Start_DateTime.Date == _date.Date).OrderBy(x => x.Start_DateTime).LastOrDefault();

                    if (emptyPeriod == null && appointment == null)
                        throw new Exception(Core.Resources.EntitiesResources.Messages.DoctorNotPresentInPolyclinic);

                    else if (emptyPeriod == null && appointment != null)
                    {
                        //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                        //var userManager = new UserManager<User>(new UserStore<User>(context));

                        #region book appointment for new user
                        if (!_existUser)
                        {
                            var patientUser = new Person
                            {
                                NamePrefix = _patientModel.NamePrefix,
                                FirstName = _patientModel.FirstName,
                                Age = _patientModel.Age,
                                Gender = _patientModel.Gender,
                                Mobile = _patientModel.Mobile,
                                ZipCode = _patientModel.ZipCode,
                                Address = _patientModel.Address,
                                Description = _patientModel.Description,
                                //Email = _patientModel.Email,
                                CreatedAt = DateTime.Now,
                                //UserName = _patientModel.Mobile,
                                IsApproved = true,
                                IsDeleted = false,
                                CreatorRole = Shared.Enums.LoginAs.CLINICMANAGER,
                                CreationPlaceId = CurrentClinic.Id,
                                //ParentId = User.Identity.GetUserId()
                            };

                            _userService.InsertNewPerson(patientUser);

                            //var assignPatientRole = userManager.AddToRole(patientUser.Id, UsersRoleName.Patient.ToString());
                            //if (!assignPatientRole.Succeeded)
                            //{
                            //    throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                            //}
                            _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                            {
                                PersonId = patientUser.Id,
                                CreatedAt = DateTime.Now
                            });

                            var appointToReserve = new Appointment
                            {
                                Book_DateTime = DateTime.Now,
                                Start_DateTime = appointment.End_DateTime,
                                End_DateTime = appointment.End_DateTime.AddMinutes((appointment.End_DateTime - appointment.Start_DateTime).TotalMinutes),
                                Description = "Turn Out Of Schedule",
                                Status = AppointmentStatus.Pending,
                                ServiceSupplyId = serviceSupply.Id,
                                PersonId = patientUser.Id,
                                PatientInsuranceId = null,
                                IsAnnounced = false,
                                Paymentstatus = PaymentStatus.Free,
                                IsDeleted = false,
                                ShiftCenterServiceId = polyclinicHealthService.Id,
                                ReservationChannel = ReservationChannel.ClinicManagerSection,
                                CreatedAt = DateTime.Now
                            };
                            _dbContext.Appointments.Add(appointToReserve);
                            _dbContext.SaveChanges();

                            #region Send SMS notification    
                            if (sendSms)
                            {
                                try
                                {
                                    persian_dayOfWeek = Utils.ConvertDayOfWeek(appointToReserve.Start_DateTime.DayOfWeek.ToString());
                                    day_number = appointToReserve.Start_DateTime.ToShortDateString().Split('/')[2];
                                    persian_month = Utils.GetMonthName(appointToReserve.Start_DateTime);
                                    year_number = appointToReserve.Start_DateTime.ToShortDateString().Split('/')[0];

                                    var smsBody = "Your turn" + persian_dayOfWeek + " " + day_number + " " + persian_month + " " + year_number + " at " + appointToReserve.Start_DateTime.ToShortTimeString() + "has been reserved: " + doctor_name;

                                    if (serviceSupply.ShiftCenter.IsIndependent && serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                    }
                                    else if (serviceSupply.ShiftCenter.Clinic.IsIndependent && serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                    }
                                    else if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                    }

                                    _plivoService.SendMessage(recepient.ToList(), smsBody);

                                    _dbContext.Entry(appointment).State = EntityState.Modified;
                                    appointment.IsAnnounced = true;
                                    _dbContext.SaveChanges();
                                }
                                catch
                                {

                                }
                            }
                            #endregion

                            var response = new
                            {
                                Date = date,
                                Time = appointToReserve.Start_DateTime.ToShortTimeString(),
                                DayOfWeek = Utils.ConvertDayOfWeek(DateTime.Parse(date).DayOfWeek.ToString()),
                                Doctor = serviceSupply.Person.FullName,
                                Polyclinic = serviceSupply.ShiftCenter.Name_Ku
                            };

                            return Json(new { IsSucceed = true, Response = response });
                        }
                        #endregion

                        #region book appointment for existing user 
                        else if (_existUser == true)
                        {
                            var user = _dbContext.Persons.FirstOrDefault(u => u.Mobile == mobile);
                            if (user == null) throw new Exception(Core.Resources.EntitiesResources.Messages.ItemNotFound);
                            //if (!userManager.IsInRole(user.Id, UsersRoleName.Patient.ToString()))
                            //{
                            //    var assignPatientRole = userManager.AddToRole(user.Id, UsersRoleName.Patient.ToString());
                            //    if (!assignPatientRole.Succeeded)
                            //    {
                            //        throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                            //    }
                            //}

                            if (user.PatientPersonInfo == null)
                            {
                                _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                                {
                                    PersonId = user.Id,
                                    CreatedAt = DateTime.Now
                                });
                            }

                            var appointToReserve = new Appointment
                            {
                                Book_DateTime = DateTime.Now,
                                Start_DateTime = appointment.End_DateTime,
                                End_DateTime = appointment.End_DateTime.AddMinutes((appointment.End_DateTime - appointment.Start_DateTime).TotalMinutes),
                                Description = "Turn out of schedule",
                                Status = AppointmentStatus.Pending,
                                ServiceSupplyId = serviceSupply.Id,
                                PersonId = user.Id,
                                PatientInsuranceId = null,
                                IsAnnounced = false,
                                Paymentstatus = PaymentStatus.Free,
                                IsDeleted = false,
                                ShiftCenterServiceId = polyclinicHealthService.Id,
                                ReservationChannel = ReservationChannel.ClinicManagerSection,
                                CreatedAt = DateTime.Now
                            };
                            _dbContext.Appointments.Add(appointToReserve);
                            _dbContext.SaveChanges();

                            #region Send SMS notification    
                            if (sendSms)
                            {
                                try
                                {
                                    persian_dayOfWeek = Utils.ConvertDayOfWeek(appointToReserve.Start_DateTime.DayOfWeek.ToString());
                                    day_number = appointToReserve.Start_DateTime.ToShortDateString().Split('/')[2];
                                    persian_month = Utils.GetMonthName(appointToReserve.Start_DateTime);
                                    year_number = appointToReserve.Start_DateTime.ToShortDateString().Split('/')[0];

                                    var smsBody = "Your turn " + day_number + " " + persian_month + " " + year_number + " at " + appointToReserve.Start_DateTime.ToShortTimeString() + "has been reserved: " + doctor_name;

                                    if (serviceSupply.ShiftCenter.IsIndependent && serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                    }
                                    else if (serviceSupply.ShiftCenter.Clinic.IsIndependent && serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                    }
                                    else if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null)
                                    {
                                        smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                    }

                                    _plivoService.SendMessage(recepient.ToList(), smsBody);

                                    _dbContext.Entry(appointment).State = EntityState.Modified;
                                    appointment.IsAnnounced = true;
                                    _dbContext.SaveChanges();
                                }
                                catch
                                {

                                }
                            }
                            #endregion

                            var response = new
                            {
                                Date = date,
                                Time = appointToReserve.Start_DateTime.ToShortTimeString(),
                                DayOfWeek = Utils.ConvertDayOfWeek(DateTime.Parse(date).DayOfWeek.ToString()),
                                Doctor = serviceSupply.Person.FullName,
                                Polyclinic = serviceSupply.ShiftCenter.Name_Ku
                            };

                            return Json(new { IsSucceed = true, Response = response });
                        }
                        #endregion

                    }
                    throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileDoneAction);
                    #endregion
                }

                else if (!reserveOutside)
                {
                    #region reserve in schedule
                    if (time.Length < 8) time = "0" + time;

                    var startTime = time.Substring(0, 4).Insert(2, ":");
                    var endTime = time.Substring(4, 4).Insert(2, ":");

                    var startDateTime = DateTime.Parse(date + " " + startTime);
                    var endDateTime = DateTime.Parse(date + " " + endTime);
                    var _date = DateTime.Parse(date).Date;

                    persian_dayOfWeek = Utils.ConvertDayOfWeek(startDateTime.DayOfWeek.ToString());
                    day_number = startDateTime.ToShortDateString().Split('/')[2];
                    persian_month = Utils.GetMonthName(startDateTime);
                    year_number = startDateTime.ToShortDateString().Split('/')[0];

                    var shift = (int)_scheduleManager.getScheduleShift(startDateTime, endDateTime);

                    //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    //var userManager = new UserManager<User>(new UserStore<User>(context));

                    using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            #region book appointment for new user
                            if (!_existUser)
                            {
                                var patientUser = new Person
                                {
                                    NamePrefix = _patientModel.NamePrefix,
                                    FirstName = _patientModel.FirstName,
                                    Age = _patientModel.Age,
                                    Gender = _patientModel.Gender,
                                    Mobile = _patientModel.Mobile,
                                    ZipCode = _patientModel.ZipCode,
                                    Address = _patientModel.Address,
                                    Description = _patientModel.Description,
                                    //Email = _patientModel.Email,
                                    CreatedAt = DateTime.Now,
                                    //UserName = _patientModel.Mobile,
                                    IsApproved = true,
                                    IsDeleted = false,
                                    CreatorRole = Shared.Enums.LoginAs.CLINICMANAGER,
                                    CreationPlaceId = CurrentClinic.Id,
                                    //ParentId = User.Identity.GetUserId()
                                };

                                _userService.InsertNewPerson(patientUser);

                                //var assignPatientRole = userManager.AddToRole(patientUser.Id, UsersRoleName.Patient.ToString());
                                //if (!assignPatientRole.Succeeded)
                                //{
                                //    throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                                //}
                                _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                                {
                                    PersonId = patientUser.Id,
                                    CreatedAt = DateTime.Now
                                });

                                var finalBookabeTimePeriods = CalculateFinalBookableTimePeriods_Without_Limitation(serviceSupply, startDateTime, polyclinicHealthService, shift);

                                if (finalBookabeTimePeriods == null || finalBookabeTimePeriods.Count() <= 0)
                                    throw new Exception(Core.Resources.EntitiesResources.Messages.ValidEmptyTimePeriodNotFound);

                                var ipaTimePeriod = (from f in finalBookabeTimePeriods
                                                     where f.StartDateTime == startDateTime && f.EndDateTime == endDateTime && f.Type == TimePeriodType.InProgressAppointment
                                                     select f).FirstOrDefault();

                                if (ipaTimePeriod == null)
                                    throw new Exception(Core.Resources.EntitiesResources.Messages.ValidEmptyTimePeriodNotFound);

                                var appointment = new Appointment
                                {
                                    Book_DateTime = DateTime.Now,
                                    Start_DateTime = startDateTime,
                                    End_DateTime = endDateTime,
                                    Description = " ",
                                    Status = AppointmentStatus.Pending,
                                    ServiceSupplyId = serviceSupply.Id,
                                    PersonId = patientUser.Id,
                                    PatientInsuranceId = null,
                                    IsAnnounced = false,
                                    Paymentstatus = PaymentStatus.Free,
                                    IsDeleted = false,
                                    ShiftCenterServiceId = polyclinicHealthService.Id,
                                    ReservationChannel = ReservationChannel.ClinicManagerSection,
                                    CreatedAt = DateTime.Now
                                };
                                _dbContext.Appointments.Add(appointment);
                                _dbContext.SaveChanges();

                                #region Send SMS notification    
                                if (sendSms)
                                {
                                    try
                                    {
                                        var smsBody = "Your turn" + persian_dayOfWeek + " " + day_number + " " + persian_month + " " + year_number + " at " + startTime + "reserved: " + doctor_name;
                                        if (serviceSupply.ShiftCenter.IsIndependent && serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic.IsIndependent && serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                        }

                                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                                        _dbContext.Entry(appointment).State = EntityState.Modified;
                                        appointment.IsAnnounced = true;
                                    }
                                    catch
                                    {

                                    }
                                }
                                #endregion

                                _iPAsManager.Delete(serviceSupply.Id, startDateTime);

                                _dbContext.SaveChanges();
                                transaction.Commit();

                                var response = new
                                {
                                    Date = date,
                                    Time = appointment.Start_DateTime.ToShortTimeString(),
                                    DayOfWeek = Utils.ConvertDayOfWeek(appointment.Start_DateTime.DayOfWeek.ToString()),
                                    Doctor = serviceSupply.Person.FullName,
                                    Polyclinic = serviceSupply.ShiftCenter.Name_Ku
                                };

                                return Json(new { IsSucceed = true, Response = response });
                            }
                            #endregion

                            #region book appointment for existing user 
                            else if (_existUser == true)
                            {
                                var user = _dbContext.Persons.FirstOrDefault(u => u.Mobile == _patientModel.Mobile);
                                if (user == null) throw new Exception(Core.Resources.EntitiesResources.Messages.ItemNotFound);
                                //if (!userManager.IsInRole(user.Id, UsersRoleName.Patient.ToString()))
                                //{
                                //    var assignPatientRole = userManager.AddToRole(user.Id, UsersRoleName.Patient.ToString());
                                //    if (!assignPatientRole.Succeeded)
                                //    {
                                //        throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                                //    }
                                //}

                                if (user.PatientPersonInfo == null)
                                {
                                    _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                                    {
                                        PersonId = user.Id,
                                        CreatedAt = DateTime.Now
                                    });
                                }

                                var finalBookabeTimePeriods = CalculateFinalBookableTimePeriods_Without_Limitation(serviceSupply, startDateTime, polyclinicHealthService, shift);

                                if (finalBookabeTimePeriods == null || finalBookabeTimePeriods.Count() <= 0)
                                    throw new Exception(Core.Resources.EntitiesResources.Messages.ValidEmptyTimePeriodNotFound);

                                var ipaTimePeriod = (from f in finalBookabeTimePeriods
                                                     where f.StartDateTime == startDateTime && f.EndDateTime == endDateTime && f.Type == TimePeriodType.InProgressAppointment
                                                     select f).FirstOrDefault();

                                if (ipaTimePeriod == null)
                                    throw new Exception(Core.Resources.EntitiesResources.Messages.ValidEmptyTimePeriodNotFound);

                                var appointment = new Appointment
                                {
                                    Book_DateTime = DateTime.Now,
                                    Start_DateTime = startDateTime,
                                    End_DateTime = endDateTime,
                                    Description = " ",
                                    Status = AppointmentStatus.Pending,
                                    ServiceSupplyId = serviceSupply.Id,
                                    PersonId = user.Id,
                                    PatientInsuranceId = null,
                                    IsAnnounced = false,
                                    Paymentstatus = PaymentStatus.Free,
                                    IsDeleted = false,
                                    ShiftCenterServiceId = polyclinicHealthService.Id,
                                    ReservationChannel = ReservationChannel.ClinicManagerSection,
                                    CreatedAt = DateTime.Now
                                };

                                _dbContext.Appointments.Add(appointment);
                                _dbContext.SaveChanges();

                                #region Send SMS notification  
                                if (sendSms)
                                {
                                    try
                                    {
                                        var smsBody = "Your turn" + persian_dayOfWeek + " " + day_number + " " + persian_month + " " + year_number + " at " + startTime + "reserved: " + doctor_name;
                                        if (serviceSupply.ShiftCenter.IsIndependent && serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic.IsIndependent && serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null)
                                        {
                                            smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                        }

                                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                                        _dbContext.Entry(appointment).State = EntityState.Modified;
                                        appointment.IsAnnounced = true;
                                    }
                                    catch
                                    {

                                    }
                                }
                                #endregion

                                _iPAsManager.Delete(serviceSupply.Id, startDateTime);

                                _dbContext.SaveChanges();
                                transaction.Commit();

                                var response = new
                                {
                                    Date = date,
                                    Time = appointment.Start_DateTime.ToShortTimeString(),
                                    DayOfWeek = Utils.ConvertDayOfWeek(appointment.Start_DateTime.DayOfWeek.ToString()),
                                    Doctor = serviceSupply.Person.FullName,
                                    Polyclinic = serviceSupply.ShiftCenter.Name_Ku
                                };

                                return Json(new { IsSucceed = true, Response = response });
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                    #endregion
                }

                throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileDoneAction);
            }
            catch (Exception e)
            {
                return Json(new { IsSucceed = false, Message = e.Message });
            }
        }

        /// <summary>
        /// این متد برای محاسبه زمان های کاری هر روز بخصوصی می باشد و محدودیتی روی ان اعمال نمی شود
        /// بیشتر برای مدیر کلینیک استفاده می شود که باید خارج از محدوده نوبت دهی کلینیک بتواند نوبت رزرو کند
        /// </summary>
        /// <param name="supply"></param>
        /// <param name="Date"></param>
        /// <param name="polyclinicHealthService"></param>
        /// <returns></returns>
        private IEnumerable<TimePeriodModel> Get_Non_Break_Times_Without_Limitation(ServiceSupply supply, DateTime Date, ShiftCenterService polyclinicHealthService, int shift)
        {
            var schedules = _serviceSupplyManager.GetSchedulesByDateWithoutFilter(supply, Date, polyclinicHealthService);
            if (schedules != null && schedules.Count > 0)
            {
                var nonBreaks = new List<TimePeriodModel>();
                var _duration = supply.Duration;

                foreach (var item in schedules)
                {
                    if (_scheduleManager.getScheduleShift(item.Start_DateTime, item.End_DateTime) == (ScheduleShift)shift)
                    {
                        if (item.MaxCount > 0)
                        {
                            var appointsForSchedule = supply.Appointments.Where(a => a.Start_DateTime.Date == item.Start_DateTime.Date && a.Start_DateTime >= item.Start_DateTime && a.End_DateTime <= item.End_DateTime && (a.ShiftCenterService == null || a.ShiftCenterServiceId == polyclinicHealthService.Id) && !a.IsDeleted).ToList();
                            if (appointsForSchedule.Count > 0)
                            {
                                var firstAppoint = appointsForSchedule.FirstOrDefault();
                                _duration = (int)(firstAppoint.End_DateTime - firstAppoint.Start_DateTime).TotalMinutes;
                            }
                            else
                            {
                                var _maxCount = item.MaxCount;
                                var manualSchedulesForOtherHealthServices = (from ms in supply.Schedules
                                                                             where ms.Start_DateTime == item.Start_DateTime &&
                                                                                  ms.End_DateTime == item.End_DateTime &&
                                                                                  ms.ShiftCenterServiceId != item.ShiftCenterServiceId
                                                                             select ms).ToList();
                                if (manualSchedulesForOtherHealthServices.Count > 0)
                                {
                                    foreach (var ms in manualSchedulesForOtherHealthServices)
                                    {
                                        _maxCount += ms.MaxCount;
                                    }
                                }
                                else
                                {
                                    var usualSchedulesForOtherHelathServices = (from us in supply.UsualSchedulePlans
                                                                                where us.Shift == (ScheduleShift)shift &&
                                                                                      us.DayOfWeek == item.Start_DateTime.DayOfWeek &&
                                                                                      us.StartTime == item.Start_DateTime.ToShortTimeString() &&
                                                                                      us.EndTime == item.End_DateTime.ToShortTimeString() &&
                                                                                      us.ShiftCenterServiceId != item.ShiftCenterServiceId
                                                                                select us).ToList();

                                    foreach (var us in usualSchedulesForOtherHelathServices)
                                    {
                                        _maxCount += us.MaxCount;
                                    }
                                }
                                _duration = (int)Math.Ceiling(((item.End_DateTime - item.Start_DateTime).TotalMinutes) / _maxCount);
                            }
                        }

                        nonBreaks.Add(new TimePeriodModel
                        {
                            StartDateTime = item.Start_DateTime,
                            EndDateTime = item.End_DateTime,
                            Duration = _duration,
                            Type = TimePeriodType.Empty
                        });
                    }
                }

                return nonBreaks.OrderBy(x => x.StartDateTime);
            }
            return null;
        }

        /// <summary>
        /// این متد بدون اعمال هیچ محدودیتی بازه های زمانی قابل رزرو را برای هر روزی محاسبه میکند
        /// بیشتر برای مدیر کلینیک کاربرد دارد که میخواهد خارج از بازه نوبت دهی نوبتی رزرو کند
        /// </summary>
        /// <param name="serviceSupply"></param>
        /// <param name="Date"></param>
        /// <param name="polyclinicHealthService"></param>
        /// <returns></returns>
        private IList<TimePeriodModel> Calculate_Bookable_TimePeriods_Without_Limitation(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService, int shift)
        {
            var BookableTimes = new List<TimePeriodModel>();

            var nonBreakTimes = Get_Non_Break_Times_Without_Limitation(serviceSupply, Date, polyclinicHealthService, shift);

            if (nonBreakTimes != null && nonBreakTimes.Count() >= 1)
            {
                foreach (var item in nonBreakTimes)
                {
                    for (var dt = item.StartDateTime; dt <= item.EndDateTime; dt = dt.AddMinutes(item.Duration))
                    {
                        var tpEndTime = dt.AddMinutes(item.Duration);
                        if (tpEndTime <= item.EndDateTime)
                        {
                            BookableTimes.Add(new TimePeriodModel
                            {
                                StartDateTime = dt,
                                EndDateTime = tpEndTime,
                                Duration = item.Duration,
                                Type = TimePeriodType.Empty
                            });
                        }
                        else
                        {
                            var tpStartTime = tpEndTime.AddMinutes(-item.Duration);

                            if (tpStartTime > item.StartDateTime && tpStartTime < item.EndDateTime)
                            {
                                BookableTimes.Add(new TimePeriodModel
                                {
                                    StartDateTime = tpStartTime,
                                    EndDateTime = item.EndDateTime,
                                    Duration = item.Duration,
                                    Type = TimePeriodType.Empty
                                });
                            }
                        }
                    }
                }
                return BookableTimes.OrderBy(x => x.StartDateTime).ToList();
            }

            return null;
        }

        /// <summary>
        /// لیست همه بازه های زمانی قابل رزرو و رزرو شده و یا در حال رزرو را بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ - روز</param>
        /// <returns></returns>
        private IEnumerable<TimePeriodModel> Calculate_All_TimePeriods_Without_Limitation(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService, int shift)
        {
            var BookableTimePeriods = Calculate_Bookable_TimePeriods_Without_Limitation(serviceSupply, Date, polyclinicHealthService, shift);

            if (BookableTimePeriods != null && BookableTimePeriods.Count() >= 1)
            {
                BookableTimePeriods = BookableTimePeriods.ToList();

                var appointments = _doctorServiceManager.Get_All_Appointments(serviceSupply, Date).ToList();
                var inProgressAppointments = _doctorServiceManager.Calculate_InProgressAppointments_TimePriods(serviceSupply, Date).ToList();

                if ((appointments == null || appointments.Count <= 0) &&
                    (inProgressAppointments == null || inProgressAppointments.Count <= 0))
                    return BookableTimePeriods;

                if (appointments != null && appointments.Count >= 1)
                {
                    foreach (var pa in appointments)
                    {
                        foreach (var bookable in BookableTimePeriods)
                        {
                            if (bookable.StartDateTime == pa.Start_DateTime && bookable.Type != TimePeriodType.InProgressAppointment)
                            {
                                BookableTimePeriods.ElementAt(BookableTimePeriods.IndexOf(bookable)).Type = TimePeriodType.Appointment;
                                break;
                            }
                        }
                    }
                }

                if (inProgressAppointments != null && inProgressAppointments.Count >= 1)
                {
                    foreach (var ipa in inProgressAppointments)
                    {
                        foreach (var bookable in BookableTimePeriods)
                        {
                            if (bookable.StartDateTime == ipa.StartDateTime && bookable.Type != TimePeriodType.Appointment)
                            {
                                BookableTimePeriods.ElementAt(BookableTimePeriods.IndexOf(bookable)).Type = TimePeriodType.InProgressAppointment;
                            }
                        }
                    }
                }
                return BookableTimePeriods.OrderBy(x => x.StartDateTime);
            }

            return null;
        }

        private bool IsEmptyTimePeriod(ServiceSupply serviceSupply, TimePeriodModel timePeriod, ShiftCenterService polyclinicHealth, int shift)
        {
            var query = (from e in Calculate_All_TimePeriods_Without_Limitation(serviceSupply, timePeriod.StartDateTime, polyclinicHealth, shift)
                         where e.Type == TimePeriodType.Empty && e.StartDateTime == timePeriod.StartDateTime && e.EndDateTime == timePeriod.EndDateTime
                         select e).FirstOrDefault();

            return query != null;
        }

        private IEnumerable<TimePeriodModel> CalculateFinalBookableTimePeriods_Without_Limitation(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService, int shift)
        {
            var allTimePeriods = Calculate_All_TimePeriods_Without_Limitation(serviceSupply, Date, polyclinicHealthService, shift);

            if (allTimePeriods != null && allTimePeriods.Count() > 0)
            {
                var finalBookables = allTimePeriods.Where(x => x.Type == TimePeriodType.InProgressAppointment && x.StartDateTime >= DateTime.Now).OrderBy(x => x.StartDateTime);

                return finalBookables;
            }

            return null;
        }

        private bool IsHaveReserveAppointPermission()
        {
            //var currentUser = HttpContext.User.Identity.GetUserName();
            //var parveh = "3329421797";
            //var alavi = "4968975279";
            //var ImamReza = 3;
            //var ImamAli = 4;

            //var result = true;

            //if (CurrentClinic == null) return false;

            //if (!CurrentClinic.IsIndependent)
            //{
            //    result = (CurrentClinic.HospitalId == ImamReza && currentUser == parveh) || (CurrentClinic.HospitalId == ImamAli && currentUser == alavi);
            //}
            //return result;

            return true;
        }
    }
}