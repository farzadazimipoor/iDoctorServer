using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.ContactUsRepo;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.StatisticsRepo;
using AN.Core.Enums;
using AN.DAL;
using AN.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        private readonly BanobatDbContext _dbContext;
        #region Fields
        private readonly IHospitalService _hospitalService;
        private readonly IClinicService _clinicService;
        private readonly IShiftCenterService _polyclinicService;
        private readonly IAppointmentService _appointmentService;
        private readonly IStatisticsService _statisticsService;
        private readonly IIPAsManager _iPAsManager;
        private readonly IPersonService _userService;
        private readonly IContactUsService _contactUsService;
        private static Logger logger;
        #endregion

        #region Ctor
        public HomeController(BanobatDbContext dbContext,
                             IHospitalService hospitalService,
                             IClinicService clinicService,
                             IShiftCenterService polyclinicService,
                             IAppointmentService appointmentService,
                             IStatisticsService statisticsService,
                             IIPAsManager iPAsManager,
                             IPersonService userService,
                             IContactUsService contactUsService)
        {
            _dbContext = dbContext;
            _hospitalService = hospitalService;
            _clinicService = clinicService;
            _polyclinicService = polyclinicService;
            _appointmentService = appointmentService;
            _statisticsService = statisticsService;
            _iPAsManager = iPAsManager;
            _userService = userService;
            _contactUsService = contactUsService;

            logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        // GET: Admin/Home
        //[OutputCache(NoStore =true, Duration = 0 , Location = System.Web.UI.OutputCacheLocation.None)]               
        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            try
            {
                (int site, int app, int kiosk, int sms, int ussd, int voip, int outOfSchedule) = await _appointmentService.GetReservationChannelStatisticsAsync();

                var channelReservationModel = new ChannelReservationStatisticsViewModel
                {
                    KioskAppointmentsCount = kiosk,
                    WebsiteAppointmentsCount = site,
                    AndroidAppAppointmentsCount = app,
                    ReserveOutsideAppointmentsCount = outOfSchedule,
                    SMSAppointmentsCount = sms,
                    VoipAppointmentsCount = voip,
                    USSDAppointmentsCount = ussd
                };

                var dashboard_model = new IndexViewModel
                {
                    OnlineUsers = 0, //(int)HttpContext.Application["OnlineUsersCount"],
                    TodayVisits = await _statisticsService.GetTodayVisitsCountAsync(),
                    //UniquVisitors = await context.Statisticses.GroupBy(ta => ta.IpAddress).Select(ta => ta.Key).CountAsync(),
                    UniquVisitors = 0,
                    TotallVisits = await _statisticsService.GetTotalVisitsCountAsync(),

                    HospitalsCount = await _hospitalService.GetHospitalsCountAsync(),
                    ClinicsCount = await _clinicService.GetAllClinicsCountAsync(),
                    PoliClinicsCount = await _polyclinicService.GetAllApprovedShiftCentersCountAsync(),
                    AllAppointmentsCount = await _appointmentService.GetAllAppointmentsCountAsync(),
                    InProgressAppointmentsCount = _iPAsManager.GetAll().Count(),
                    PendingAppointmentsCount = await _appointmentService.GetAllAppointmentsCountByStatusAsync(AppointmentStatus.Pending),
                    DoneAppointmentsountCount = await _appointmentService.GetAllAppointmentsCountByStatusAsync(AppointmentStatus.Done),
                    CanceledAppointmentsCount = await _appointmentService.GetAllAppointmentsCountByStatusAsync(AppointmentStatus.Canceled),
                    AllUsersCount = await _userService.GetAllPersonsCountAsync(),
                    ChannelReservationStatistics = channelReservationModel
                };

                ViewData["NewPoliclinicRequests"] = await _polyclinicService.GetAllUnApprovedIndependentShiftCentersCountAsync();
                ViewData["AdminContactUsCount"] = await _contactUsService.GetAllUnreadMessagesCountAsync();

                return View(dashboard_model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.InnerException);
                throw;
            }
        }      
    }
}