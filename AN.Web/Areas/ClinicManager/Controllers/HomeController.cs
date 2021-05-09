using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Persons;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.DAL;
using AN.Web.Areas.ClinicManager.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class HomeController : ClinicManagerController
    {
        #region Fields
        private static Logger logger;
        private readonly IPersonService _userService;
        private readonly IWorkContext _workContext;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public HomeController(IPersonService userService,
                             IClinicService clinicService,
                             IWorkContext workContext, BanobatDbContext dbContext) : base(clinicService)
        {
            _userService = userService;
            _workContext = workContext;
            logger = LogManager.GetCurrentClassLogger();
            _dbContext = dbContext;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var pastDaysAppoints = new List<DayAppointsStatistics>();

                IQueryable<Appointment> _appointments = _dbContext.Set<Appointment>();

                _appointments = _dbContext.Appointments.Where(a => a.ServiceSupply.ShiftCenter.ClinicId == CurrentClinic.Id && a.Paymentstatus != PaymentStatus.NotPayed);

                var canceledAppoints = await _appointments.CountAsync(a => a.Status == AppointmentStatus.Canceled);

                _appointments = _appointments.Where(a => !a.IsDeleted);

                var allAppoints = await _appointments.CountAsync();
                var pendingAppoints = await _appointments.CountAsync(a => a.Status == AppointmentStatus.Pending);
                var doneAppoints = await _appointments.CountAsync(a => a.Status == AppointmentStatus.Done);

                var pendingPercent = 0;
                var donePercent = 0;
                var canceledPercent = 0;
                if (allAppoints > 0)
                {
                    pendingPercent = (pendingAppoints * 100) / allAppoints;
                    donePercent = (doneAppoints * 100) / allAppoints;
                    canceledPercent = (canceledAppoints * 100) / allAppoints;
                }

                for (var date = DateTime.Now.AddDays(-7); date <= DateTime.Now; date = date.AddDays(1))
                {
                    var _date = date.ToShortDateString();
                    if (date.Date == DateTime.Now.Date)
                        _date = Core.Resources.Global.Global.Today;
                    else
                        _date = Utils.ConvertDayOfWeek(date.DayOfWeek.ToString());

                    var count = await _appointments.CountAsync(a => a.Start_DateTime.Date == date.Date);
                    pastDaysAppoints.Add(new DayAppointsStatistics
                    {
                        Date = _date,
                        Counts = count
                    });
                }
                var model = new CMIndexViewModel
                {
                    PoliClinicsCount = await _dbContext.ShiftCenters.CountAsync(p => p.ClinicId == CurrentClinic.Id),
                    DoctorsCount = await _dbContext.ServiceSupplies.CountAsync(x => x.ShiftCenter.ClinicId == CurrentClinic.Id && x.IsAvailable),
                    TodayAppointsCount = await _appointments.CountAsync(a => a.Start_DateTime.Date == DateTime.Now.Date),
                    AppointmentsCount = allAppoints,
                    PendingAppointsCount = pendingAppoints,
                    DoneAppointsCount = doneAppoints,
                    CanceledAppointsCount = canceledAppoints,
                    PendingAppointsPercent = pendingPercent,
                    DoneAppointsPercent = donePercent,
                    CanceledAppointsPercent = canceledPercent,
                    DaysAppoints = pastDaysAppoints,
                    KioskAppointmentsCount = await _appointments.CountAsync(a => a.ReservationChannel == ReservationChannel.Kiosk),
                    WebsiteAppointmentsCount = await _appointments.CountAsync(a => a.ReservationChannel == ReservationChannel.Website),
                    AndroidAppAppointmentsCount = await _appointments.CountAsync(a => a.ReservationChannel == ReservationChannel.MobileApplication),
                    ReserveOutsideAppointmentsCount = await _appointments.CountAsync(a => a.ReservationChannel == ReservationChannel.ClinicManagerSection),
                    SMSAppointmentsCount = await _appointments.CountAsync(a => a.ReservationChannel == ReservationChannel.SMS),
                };

                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ChangeClinic(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var currentUser = _userService.GetByUserName(_workContext.CurrentUserName);

            var currentUserClinics = from c in currentUser.ClinicPersons.Where(cm => cm.IsManager == true) select c.Clinic;

            var clinic = currentUserClinics.FirstOrDefault(c => c.Id == id);

            if (clinic == null) throw new EntityNotFoundException();

            var CurrentClinic = new WorkingAreaModel
            {
                Id = clinic.Id,
                Name = clinic.Name_Ku
            };

            HttpContext.Session.SetString("CurrentClinic", JsonConvert.SerializeObject(CurrentClinic));

            return RedirectToAction("Index", "Home", new { area = "ClinicManager" });
        }
    }
}