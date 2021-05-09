using AN.BLL.Core.Services;
using AN.BLL.DataRepository.Expertises;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Places;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{   
    public class DoctorsController : AwroNoreController
    {
        private readonly IHospitalService _hospitalService;
        private readonly IExpertiseService _expertiseService;
        private readonly IPlaceService _placeService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IWorkContext _workContext;
        public DoctorsController(IHospitalService hospitalService,
                                 IExpertiseService expertiseService,
                                 IPlaceService placeService,
                                 IServiceSupplyService serviceSupplyService,
                                 IDoctorServiceManager doctorServiceManager,
                                 IWorkContext workContext)
        {
            _hospitalService = hospitalService;
            _expertiseService = expertiseService;
            _placeService = placeService;
            _serviceSupplyService = serviceSupplyService;
            _doctorServiceManager = doctorServiceManager;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index(DoctorsFilterDTO filterModel)
        {
            var cities = await _placeService.GetAllCities().Select(x => new SelectListItem
            {
                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar,
                Value = x.Id.ToString(),
                Selected = filterModel.City != null && filterModel.City == x.Id
            }).ToListAsync();

            var hospitals = await _hospitalService.GetAll().Select(x => new SelectListItem
            {
                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar,
                Value = x.Id.ToString(),
                Selected = filterModel.Hospital != null && filterModel.Hospital == x.Id
            }).ToListAsync();

            var expertises = await _expertiseService.AllExpertisesTable().Select(x => new SelectListItem
            {
                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar,
                Value = x.Id.ToString(),
                Selected = filterModel.Expertise != null && filterModel.Expertise == x.Id
            }).ToListAsync();

            var clinicTypes = Enum.GetValues(typeof(ClinicType)).Cast<ClinicType>().ToList();
            var clinicTypesSelectList = clinicTypes.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = clinicTypes.IndexOf(x).ToString(),
                Selected = filterModel.Clinic != null && filterModel.Clinic == clinicTypes.IndexOf(x)
            }).ToList();

            ViewBag.Cities = cities;
            ViewBag.Hospitals = hospitals;
            ViewBag.Expertises = expertises;
            ViewBag.ClinicTypes = clinicTypesSelectList;
            ViewBag.Lng = _workContext.Locale;

            return View(filterModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var serviceSuppply = await _serviceSupplyService.GetServiceSupplyByIdAsync(id);

            if (serviceSuppply == null) throw new AwroNoreException("Doctor Not Found");

            var details = new DoctorDetailsViewModel
            {
                Avatar = (!string.IsNullOrEmpty(serviceSuppply.Person.Avatar) && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\avatars\\{serviceSuppply.Person.Mobile}", serviceSuppply.Person.Avatar))) ? $"{serviceSuppply.Person.Mobile}/{serviceSuppply.Person.Avatar}" : (serviceSuppply.Person.Gender == Gender.Female ? "NoAvatar_Female.jpg" : "NoAvatar.jpg"),
                FullName = serviceSuppply.Person.FullName,
                MedicalCouncilNumber = serviceSuppply.ServiceSupplyInfo?.MedicalCouncilNumber,
                Phones = serviceSuppply.ShiftCenter.PhoneNumbers.Select(x => x.PhoneNumber).ToList(),
                Address = Lng == Lang.KU ? serviceSuppply.ShiftCenter.Address_Ku : serviceSuppply.ShiftCenter.Address_Ar,
                Expertises = serviceSuppply?.DoctorExpertises.Select(x => Lng == Lang.KU ? x.Expertise.Name_Ku : x.Expertise.Name_Ar).ToList(),
            };

            return PartialView(details);
        }
    }
}