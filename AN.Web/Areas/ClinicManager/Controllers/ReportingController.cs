//using AN.BLL.Core.Services;
//using AN.BLL.DataRepository.Clinics;
//using AN.BLL.DataRepository.Schedules;
//using AN.BLL.DataRepository.ServiceSupplies;
//using AN.BLL.Helpers;
//using AN.Core;
//using AN.Core.Domain;
//using AN.Core.Enums;
//using AN.Core.Models;
//using AN.Core.Models.Reporting;
//using AN.Core.Resources.Global;
//using AN.DAL;
//using AN.Web.App_Code;
//using AN.Web.Areas.ClinicManager.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using NLog;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AN.Web.Areas.ClinicManager.Controllers
//{
//    public class ReportingController : ClinicManagerController
//    {
//        #region Fields
//        private static Logger logger;
//        private readonly IServiceSupplyService _serviceSupplyService;
//        private readonly IServiceSupplyManager _serviceSupplyManager;
//        private readonly IScheduleManager _scheduleManager;
//        private readonly IScheduleService _scheduleService;
//        private readonly IClinicService _clinicService;
//        private readonly ICommonUtils _commonUtils;
//        private readonly BanobatDbContext _dbContext;
//        #endregion

//        #region Ctor
//        public ReportingController(IServiceSupplyService serviceSupplyService,
//                                  IServiceSupplyManager serviceSupplyManager,
//                                  IScheduleManager scheduleManager,
//                                  IScheduleService scheduleService,
//                                  IClinicService clinicService,
//                                  ICommonUtils commonUtils,
//                                  BanobatDbContext dbContext) : base(clinicService)
//        {
//            _serviceSupplyService = serviceSupplyService;
//            _serviceSupplyManager = serviceSupplyManager;
//            _scheduleManager = scheduleManager;
//            _scheduleService = scheduleService;
//            _clinicService = clinicService;
//            _commonUtils = commonUtils;
//            _dbContext = dbContext;

//            logger = LogManager.GetCurrentClassLogger();
//        }
//        #endregion

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult AppointmentsReport(int? polyclinicId,
//                                               int? serviceSupplyId,
//                                               string fromDate,
//                                               string toDate,
//                                               int? polyclinicHealthServiceId,
//                                               AppointmentStatus? status,
//                                               PaymentStatus? paymentStatus,
//                                               bool? isForPrint)
//        {
//            try
//            {
//                var doctorName = "";
//                var _fromDate = (fromDate == "" || fromDate == null) ? DateTime.Now.ToShortDateString() : fromDate;
//                var _toDate = (toDate == "" || toDate == null) ? DateTime.Now.ToShortDateString() : toDate;

//                var appointments = new List<AppointmentReportModel>();

//                if (polyclinicId != null && serviceSupplyId != null && fromDate != "" && fromDate != null && toDate != "" && toDate != null)
//                {
//                    var _from = DateTime.Parse(fromDate);
//                    var _to = DateTime.Parse(toDate).AddDays(1);

//                    var query = (from a in _dbContext.Appointments
//                                 where
//                                 a.ServiceSupply.PoliClinic.ClinicId == CurrentClinic.Id &&
//                                 a.ServiceSupply.PoliClinicId == polyclinicId &&
//                                 a.ServiceSupplyId == serviceSupplyId &&
//                                 (a.PolyclinicHealthService == null || a.PolyClinicHealthServiceId == polyclinicHealthServiceId) &&
//                                 a.Start_DateTime >= _from && a.Start_DateTime <= _to &&
//                                 a.Status == status &&
//                                 a.Paymentstatus == paymentStatus
//                                 select a)
//                                .ToList()
//                                .Select(x => new AppointmentReportModel
//                                {
//                                    DayOfWeek = Utils.ConvertDayOfWeek(x.Start_DateTime.DayOfWeek.ToString()),
//                                    StartTime = x.Start_DateTime.ToShortTimeString(),
//                                    PatientName = x.User.FirstName + " " + x.User.SecondName + " " + x.User.ThirdName,
//                                    PatientMobile = x.User.Mobile
//                                });

//                    appointments = query.ToList();

//                    if (isForPrint != null && (bool)isForPrint)
//                    {
//                        var polyclinic = CurrentClinic.PoliClinics.FirstOrDefault(x => x.Id == polyclinicId);
//                        var serviceSupply = polyclinic.ServiceSupplies.FirstOrDefault(x => x.Id == serviceSupplyId);
//                        var printModel = new ClinicAppointsReportModel
//                        {
//                            ClinicId = CurrentClinic.Id,
//                            ClinicName = Lng == Lang.KU ? CurrentClinic.Name_Ku : CurrentClinic.Name_Ar,
//                            DoctorName = serviceSupply.User.FullName,
//                            PolyclinicName = Lng == Lang.KU ? polyclinic.Name_Ku : polyclinic.Name_Ar,
//                            PolyclinicId = polyclinic.Id,
//                            FromToDate = $"{Global.From} {fromDate} {Global.To} {toDate}",
//                            Rows = appointments.Select(x => new ClinicReportModel
//                            {
//                                DayOfWeek = x.DayOfWeek,
//                                StartTime = x.StartTime,
//                                PatientName = x.PatientName,
//                                Mobile = x.PatientMobile
//                            }).ToList()
//                        };

//                        var report = new ClinicAppointsPdfReport(printModel).CreatePdfReport();
//                        return RedirectToAction("DownloadPdf", "Reporting", new { area = "ClinicManager", filePath = report.FileName });
//                    }
//                }
//                var _polyclinicId = 0;
//                IEnumerable<SelectListItem> serviceSupplies = new List<SelectListItem>();
//                IEnumerable<SelectListItem> healthServices = new List<SelectListItem>();
//                if (polyclinicId != null)
//                {
//                    _polyclinicId = (int)polyclinicId;
//                    var polyclinic = CurrentClinic.PoliClinics.FirstOrDefault(x => x.Id == polyclinicId);
//                    serviceSupplies = polyclinic.ServiceSupplies.Select(x => new SelectListItem
//                    {
//                        Value = x.Id.ToString(),
//                        Text = x.User.FullName
//                    });
//                    healthServices = polyclinic.PolyclinicHealthServices.Select(x => new SelectListItem
//                    {
//                        Value = x.Id.ToString(),
//                        Text = Lng == Lang.KU ? x.HealthService.Name_Ku : x.HealthService.Name_Ar
//                    });
//                }
//                else
//                {
//                    var firstPolyclinic = CurrentClinic.PoliClinics.FirstOrDefault();
//                    if (firstPolyclinic != null)
//                    {
//                        _polyclinicId = firstPolyclinic.Id;
//                        serviceSupplies = firstPolyclinic.ServiceSupplies.Select(x => new SelectListItem
//                        {
//                            Value = x.Id.ToString(),
//                            Text = x.User.FullName
//                        });
//                        healthServices = firstPolyclinic.PolyclinicHealthServices.Select(x => new SelectListItem
//                        {
//                            Value = x.Id.ToString(),
//                            Text = Lng == Lang.KU ? x.HealthService.Name_Ku : x.HealthService.Name_Ar
//                        });
//                    }
//                }

//                var result = new CMReportingViewModel
//                {
//                    ListPolyclinics = CurrentClinic.PoliClinics.Select(x => new SelectListItem
//                    {
//                        Value = x.Id.ToString(),
//                        Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
//                    }),
//                    ListServiceSupplies = serviceSupplies,
//                    ListPaymentStatuses = _commonUtils.PopulatePaymentStatuses(),
//                    ListHealthServices = healthServices,
//                    polyclinicId = _polyclinicId,
//                    serviceSupplyId = serviceSupplyId != null ? (int)serviceSupplyId : 0,
//                    DoctorName = doctorName,
//                    FromDate = _fromDate,
//                    ToDate = _toDate,
//                    ListAppointments = appointments
//                };
//                ViewBag.StatusList = MyEnumExtensions.EnumToSelectList<AppointmentStatus>().ToList();
//                return View(result);
//            }
//            catch (Exception ex)
//            {
//                logger.Error("Error in Reporting...");
//                logger.Error(ex.Message);
//                logger.Error(ex.InnerException.Message);
//                logger.Error(ex.InnerException);
//                return View("UsersError", new HandleErrorInfo(ex, "AppointmentsReport", "Reporting"));
//            }

//        }

//        public FileResult DownloadPdf(string filePath)
//        {
//            return File(filePath, "application/pdf");
//        }

//        public IActionResult ReportAll()
//        {
//            var _listPolyclinics = new List<SelectListItem>
//            {
//                new SelectListItem
//                {
//                    Value = "0",
//                    Text = Global.All
//                }
//            };

//            var query = CurrentClinic.PoliClinics.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
//            }).ToList();

//            _listPolyclinics.AddRange(query);

//            var model = new ReportAllViewModel
//            {
//                ListPolyclinics = _listPolyclinics
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult ReportAllOld(ReportAllViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var _from = DateTime.Parse(model.FromDate);
//                var _to = DateTime.Parse(model.ToDate).AddDays(1);
//                var appointments = new List<AppoinemetsToReportModel>();
//                switch (model.PolyclinicId)
//                {
//                    case 0: //For all polyclinics
//                        appointments = (from a in _dbContext.Appointments
//                                        where
//                                        a.ServiceSupply.PoliClinic.ClinicId == CurrentClinic.Id &&
//                                        a.Start_DateTime >= _from && a.Start_DateTime <= _to &&
//                                        a.Status == AppointmentStatus.Pending &&
//                                        a.Paymentstatus != PaymentStatus.NotPayed &&
//                                        !a.IsDeleted
//                                        select new AppoinemetsToReportModel
//                                        {
//                                            StartDateTime = a.Start_DateTime,
//                                            PatientName = a.ReservationChannel != ReservationChannel.Kiosk ? a.User.FirstName + " " + a.User.SecondName + " " + a.User.ThirdName : "",
//                                            PatientMobile = a.User.Mobile,
//                                            PolyclinicName = Lng == Lang.KU ? a.ServiceSupply.PoliClinic.Name_Ku : a.ServiceSupply.PoliClinic.Name_Ar,
//                                            DoctorName = a.ServiceSupply.User.FirstName + " " + a.ServiceSupply.User.FirstName + " " + a.ServiceSupply.User.SecondName + " " + a.ServiceSupply.User.ThirdName
//                                        }).OrderBy(x => x.PolyclinicName).ThenBy(x => x.DoctorName).ThenBy(x => x.StartDateTime).ToList();
//                        break;
//                    default:
//                        appointments = (from a in _dbContext.Appointments
//                                        where
//                                        a.ServiceSupply.PoliClinic.ClinicId == CurrentClinic.Id &&
//                                        a.ServiceSupply.PoliClinicId == model.PolyclinicId &&
//                                        a.Start_DateTime >= _from && a.Start_DateTime <= _to &&
//                                        a.Status == AppointmentStatus.Pending &&
//                                        a.Paymentstatus != PaymentStatus.NotPayed &&
//                                        !a.IsDeleted
//                                        select new AppoinemetsToReportModel
//                                        {
//                                            StartDateTime = a.Start_DateTime,
//                                            PatientName = a.ReservationChannel != ReservationChannel.Kiosk ? a.User.FirstName + " " + a.User.SecondName + " " + a.User.ThirdName : "",
//                                            PatientMobile = a.User.Mobile,
//                                            PolyclinicName = Lng == Lang.KU ? a.ServiceSupply.PoliClinic.Name_Ku : a.ServiceSupply.PoliClinic.Name_Ar,
//                                            DoctorName = a.ServiceSupply.User.FirstName + " " + a.ServiceSupply.User.FirstName + " " + a.ServiceSupply.User.SecondName + " " + a.ServiceSupply.User.ThirdName
//                                        }).OrderBy(x => x.PolyclinicName).ThenBy(x => x.DoctorName).ThenBy(x => x.StartDateTime).ToList();
//                        break;
//                }

//                switch (model.Shift)
//                {
//                    case 0:
//                        appointments = appointments.Where(x => x.StartDateTime.Hour >= Defaults.MorningStart.Hour && x.StartDateTime.Hour <= Defaults.MorningEnd.Hour).ToList();
//                        break;
//                    default:
//                        appointments = appointments.Where(x => x.StartDateTime.Hour >= Defaults.EveningStart.Hour && x.StartDateTime.Hour <= Defaults.EveningEnd.Hour).ToList();
//                        break;
//                }

//                var printModel = new ClinicReportAllModel
//                {
//                    ClinicId = CurrentClinic.Id,
//                    ClinicName = Lng == Lang.KU ? CurrentClinic.Name_Ku : CurrentClinic.Name_Ar,
//                    Rows = appointments.Select(x => new ReportAllRowModel
//                    {
//                        Date = x.StartDateTime.ToShortDateString(),
//                        DoctorName = x.DoctorName,
//                        Mobile = x.PatientMobile,
//                        PatientName = x.PatientName,
//                        PolyclinicName = x.PolyclinicName,
//                        StartTime = x.StartDateTime.ToShortTimeString()
//                    }).ToList()
//                };

//                var report = new ClinicAppointsPdfReportAll(printModel).CreatePdfReport();
//                return RedirectToAction("DownloadPdf", "Reporting", new { area = "ClinicManager", filePath = report.FileName });
//            }

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult ReportAll(ReportAllViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var _from = DateTime.Parse(model.FromDate);
//                var _to = DateTime.Parse(model.ToDate);
//                var appointments = new List<AppoinemetsToReportModel>();
//                var serviceSupplies = new List<ServiceSupply>();

//                var clinicServiceSupplies = _serviceSupplyService.GetAllAvailableServiceSuppliesForClinic(CurrentClinic.Id);

//                if (model.PolyclinicId == 0) //For All Polyclinics
//                {
//                    serviceSupplies.Clear();
//                    for (var dt = _from.Date; dt <= _to.Date; dt = dt.AddDays(1))
//                    {
//                        var serviceSuppliesInDate = (from d in clinicServiceSupplies.AsEnumerable()
//                                                     where _serviceSupplyManager.HaveWorkingSchedules(d, dt, model.Shift)
//                                                     select d).Distinct().ToList();

//                        serviceSupplies.AddRange(serviceSuppliesInDate);
//                    }
//                }
//                else
//                {
//                    serviceSupplies.Clear();
//                    for (var dt = _from.Date; dt <= _to.Date; dt = dt.AddDays(1))
//                    {
//                        var serviceSuppliesInDate = (from d in clinicServiceSupplies.AsEnumerable()
//                                                     where _serviceSupplyManager.HaveWorkingSchedules(d, dt, model.Shift) &&
//                                                           d.PoliClinicId == model.PolyclinicId
//                                                     select d).Distinct().ToList();

//                        serviceSupplies.AddRange(serviceSuppliesInDate);
//                    }
//                }

//                foreach (var item in serviceSupplies)
//                {
//                    for (var dt = _from; dt <= _to; dt = dt.AddDays(1))
//                    {
//                        var row = 1;

//                        var sortedAppointments =
//                            item.Appointments
//                            .Where(a => a.Start_DateTime.Date == dt.Date && a.Status == AppointmentStatus.Pending && a.Paymentstatus != PaymentStatus.NotPayed && !a.IsDeleted)
//                            .Select(a => a).OrderBy(x => Lng == Lang.KU ? x.ServiceSupply.PoliClinic.Name_Ku : x.ServiceSupply.PoliClinic.Name_Ar).ThenBy(x => x.Start_DateTime).ToList();

//                        var appointsInDate = (from a in sortedAppointments
//                                              let Rank = row++
//                                              select new AppoinemetsToReportModel
//                                              {
//                                                  RowNumber = Rank.ToString(),
//                                                  StartDateTime = a.Start_DateTime,
//                                                  PatientName = a.ReservationChannel != ReservationChannel.Kiosk ? a.User.FullName : "",
//                                                  PatientMobile = a.User.Mobile,
//                                                  PolyclinicName = Lng == Lang.KU ? a.ServiceSupply.PoliClinic.Name_Ku : a.ServiceSupply.PoliClinic.Name_Ar,
//                                                  DoctorName = a.ServiceSupply.User.FullName
//                                              }).ToList();

//                        switch (model.Shift)
//                        {
//                            case 0:
//                                appointsInDate = appointsInDate.Where(x => x.StartDateTime.Hour >= Defaults.MorningStart.Hour && x.StartDateTime.Hour <= Defaults.MorningEnd.Hour).ToList();
//                                break;
//                            default:
//                                appointsInDate = appointsInDate.Where(x => x.StartDateTime.Hour >= Defaults.EveningStart.Hour && x.StartDateTime.Hour <= Defaults.EveningEnd.Hour).ToList();
//                                break;
//                        }

//                        var count = appointsInDate.Count;
//                        var rowsPerPage = Defaults.RowsPerPage;
//                        var diff = 0;

//                        if (count > 0 && count < rowsPerPage)
//                        {
//                            diff = rowsPerPage - count;
//                        }
//                        else if (count > rowsPerPage)
//                        {
//                            var rem = count % rowsPerPage;
//                            diff = rowsPerPage - rem;
//                        }
//                        for (var i = 1; i <= diff; i++)
//                        {
//                            appointsInDate.Add(new AppoinemetsToReportModel
//                            {
//                                DoctorName = "",
//                                PatientName = "",
//                                PatientMobile = "",
//                                PolyclinicName = "",
//                                StartDateTime = DateTime.Now
//                            });
//                        }

//                        appointments.AddRange(appointsInDate);
//                    }
//                }

//                var printModel = new ClinicReportAllModel
//                {
//                    ClinicId = CurrentClinic.Id,
//                    ClinicName = Lng == Lang.KU ? CurrentClinic.Name_Ku : CurrentClinic.Name_Ar,
//                    Rows = appointments.Select(x => new ReportAllRowModel
//                    {
//                        RowNumber = x.RowNumber,
//                        Date = string.IsNullOrEmpty(x.DoctorName) ? "" : x.StartDateTime.ToShortDateString(),
//                        DoctorName = x.DoctorName,
//                        Mobile = x.PatientMobile,
//                        PatientName = x.PatientName,
//                        PolyclinicName = x.PolyclinicName,
//                        StartTime = string.IsNullOrEmpty(x.DoctorName) ? "" : x.StartDateTime.ToShortTimeString()
//                    }).ToList()
//                };

//                var report = new ClinicAppointsPdfReportAll(printModel).CreatePdfReport();

//                return RedirectToAction("DownloadPdf", "Reporting", new { area = "ClinicManager", filePath = report.FileName });
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult ReportWorkingTimes()
//        {
//            var _listPolyclinics = new List<SelectListItem>
//                {
//                    new SelectListItem
//                    {
//                        Value = "0",
//                        Text = Global.All
//                    }
//                };

//            var query = CurrentClinic.PoliClinics.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
//            }).ToList();

//            _listPolyclinics.AddRange(query);

//            var model = new WorkingHoursReportViewModel
//            {
//                ListPolyclinics = _listPolyclinics
//            };

//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult ReportWorkingTimes(WorkingHoursReportViewModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var _from = DateTime.Parse(model.FromDate);
//                    var _to = DateTime.Parse(model.ToDate);
//                    var serviceSupplies = new List<ServiceSupply>();
//                    var rowModel = new List<WorkingHoursModel>();

//                    if (model.PolyclinicId == 0)
//                    {
//                        serviceSupplies = _serviceSupplyService.GetAllServiceSuppliesForClinic(CurrentClinic.Id).ToList();
//                    }
//                    else
//                    {
//                        serviceSupplies = _serviceSupplyService.GetAllServiceSupplies(CurrentClinic.Id, model.PolyclinicId);
//                    }

//                    foreach (var serviceSupply in serviceSupplies)
//                    {
//                        for (var dt = _from; dt <= _to; dt = dt.AddDays(1))
//                        {
//                            var doneAppoints = serviceSupply.Appointments.Where(a => a.Start_DateTime.Date == dt.Date && a.Status == AppointmentStatus.Done && !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed).ToList();

//                            if (serviceSupply.IsAvailable || (!serviceSupply.IsAvailable && doneAppoints.Count() > 0))
//                            {
//                                var manualSchedules = _scheduleService.GetManualSchedulesForServiceSupplyInDate(serviceSupply.Id, dt).Distinct();
//                                var activeSchedules = manualSchedules.Where(x => x.IsAvailable == true).ToList();
//                                if (activeSchedules.Count > 0)
//                                {
//                                    foreach (var schedule in activeSchedules)
//                                    {
//                                        var shift = _scheduleManager.getScheduleShift(schedule.Start_DateTime, schedule.End_DateTime);

//                                        rowModel.Add(new WorkingHoursModel
//                                        {
//                                            DoctorName = schedule.ServiceSupply.User.FullName,
//                                            Date = dt.ToShortDateString(),
//                                            DayOfWeek = Utils.ConvertDayOfWeek(dt.DayOfWeek.ToString()),
//                                            FromTime = schedule.Start_DateTime.ToShortTimeString(),
//                                            ToTime = schedule.End_DateTime.ToShortTimeString(),
//                                            Shift = shift == ScheduleShift.Morning ? Global.Mobile : Global.Evening
//                                        });
//                                    }
//                                }
//                                else if (manualSchedules.Count() <= 0 && activeSchedules.Count <= 0)
//                                {
//                                    if (!_serviceSupplyManager.IsSystemVocationDay(dt))
//                                    {
//                                        var usualPlans = _scheduleService.GetUsualPlansForServiceSupplyInDayOfWeek(model.PolyclinicId, serviceSupply.Id, dt.DayOfWeek);
//                                        var result = usualPlans.Select(schedule => new WorkingHoursModel
//                                        {
//                                            DoctorName = serviceSupply.User.FullName,
//                                            Date = dt.ToShortDateString(),
//                                            DayOfWeek = Utils.ConvertDayOfWeek(schedule.DayOfWeek.ToString()),
//                                            FromTime = schedule.StartTime,
//                                            ToTime = schedule.EndTime,
//                                            Shift = schedule.Shift == ScheduleShift.Morning ? Global.Mobile : Global.Evening
//                                        });

//                                        rowModel.AddRange(result);
//                                    }
//                                }
//                            }
//                        }
//                    }

//                    var reportModel = new ClinicWorkingHoursReportModel
//                    {
//                        ClinicId = CurrentClinic.Id,
//                        ClinicName = Lng == Lang.KU ? CurrentClinic.Name_Ku : CurrentClinic.Name_Ar,
//                        Rows = rowModel.OrderBy(x => x.DoctorName).ThenBy(x => x.Date).ToList()
//                    };
//                    var report = new ClinicDoctorsWorkingHoursPdfReport(reportModel).CreatePdfReport();
//                    return RedirectToAction("DownloadPdf", "Reporting", new { area = "ClinicManager", filePath = report.FileName });
//                }
//            }
//            catch
//            {

//            }

//            var _listPolyclinics = new List<SelectListItem>();
//            _listPolyclinics.Add(new SelectListItem
//            {
//                Value = "0",
//                Text = Global.All
//            });
//            var query = CurrentClinic.PoliClinics.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
//            }).ToList();

//            _listPolyclinics.AddRange(query);

//            model.ListPolyclinics = _listPolyclinics;

//            return View(model);
//        }
//    }
//}