using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.Persons;
using AN.Core.Models;
using AN.Core.MyExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.HospitalManager.Controllers
{
    public class HomeController : HospitalManagerController
    {
        #region Fields       
        private readonly IClinicService _clinicService;
        private readonly IShiftCenterService _polyclinicService;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IPersonService _userService;
        #endregion

        #region Ctor
        public HomeController(IHospitalService hospitalService,
                             IClinicService clinicService,
                             IShiftCenterService polyclinicService,
                             IAppointmentService appointmentService,
                             IServiceSupplyService serviceSupplyService,
                             IPersonService userService) : base(hospitalService)
        {
            _clinicService = clinicService;
            _polyclinicService = polyclinicService;
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
            _userService = userService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ClinicsCount = await _clinicService.GetAllCountForHospitalAsync(CurrentHospital.Id);
            ViewBag.PolyClinicsCount = await _polyclinicService.GetAllCountForHospitalAsync(CurrentHospital.Id);
            ViewBag.TurnsCountCount = await _appointmentService.GetAllForHospital(CurrentHospital.Id).LongCountAsync();
            ViewBag.DoctorsCountCount = await _serviceSupplyService.GetAllCountForHospitalAsync(CurrentHospital.Id);

            return View();
        }

        [HttpGet]
        public IActionResult ChangeHospital(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var currentUser = _userService.GetByUserName(CurrentUserName);

            if (currentUser == null) throw new EntityNotFoundException();

            var hospital = currentUser.HospitalPersons
                            .Where(hm => hm.IsManager == true)
                            .Select(x => x.Hospital)
                            .FirstOrDefault(h => h.Id == id);

            if (hospital == null) throw new EntityNotFoundException();

            var CurrentHospital = new WorkingAreaModel
            {
                Id = hospital.Id,
                Name = Lng == Core.Enums.Lang.KU ? hospital.Name_Ku : hospital.Name_Ar
            };

            HttpContext.Session.SetString("", JsonConvert.SerializeObject(CurrentHospital));

            return RedirectToAction("Index", "Home", new { area = "HospitalManager" });
        }
    }
}