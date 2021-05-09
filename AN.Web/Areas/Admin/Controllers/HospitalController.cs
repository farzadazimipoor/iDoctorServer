using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Persons;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.Admin.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class HospitalController : AdminController
    {
        #region Fields
        private readonly IPersonService _userService;
        private readonly IHospitalService _hospitalService;
        private readonly IAppointmentService _appointmentService;
        private readonly ICommonUtils _commonUtils;
        #endregion

        #region Ctor
        public HospitalController(IPersonService userService, IHospitalService hospitalService, IAppointmentService appointmentService, ICommonUtils commonUtils)
        {
            _userService = userService;
            _hospitalService = hospitalService;
            _appointmentService = appointmentService;
            _commonUtils = commonUtils;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            var hospitals = await (from h in _hospitalService.GetAll()
                                   select new ListHospitalsViewModel
                                   {
                                       HospitalId = h.Id,
                                       HospitalName = Lng == Lang.AR ? h.Name_Ar : Lng == Lang.KU ? h.Name_Ku : h.Name,
                                       HospitalDescription = Lng == Lang.AR ? h.Description_Ar : Lng == Lang.KU ? h.Description_Ku : h.Description,
                                       Address = Lng == Lang.AR ? h.Address_Ar : Lng == Lang.KU ? h.Address_Ku : h.Address,  
                                       City = Lng == Lang.AR ? h.City.Name_Ar : Lng == Lang.KU ? h.City.Name_Ku : h.City.Name,                                         
                                   }).ToListAsync();

            return View(hospitals);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id)
        {
            ViewBag.Lang = Lng;

            var places = _commonUtils.PopulateCitiesList();

            if (id == null) return View(new HospitalViewModel { listPlaces = places });

            var hospital = await _hospitalService.GetHospitalByIdAsync((int)id);

            if (hospital == null) throw new EntityNotFoundException("Hospital");

            var hospitalViewModel = new HospitalViewModel
            {
                Id = hospital.Id,
                Name = hospital.Name,
                Name_Ku = hospital.Name_Ku,
                Name_Ar = hospital.Name_Ar,
                Description = hospital.Description,
                Description_Ku = hospital.Description_Ku,
                Description_Ar = hospital.Description_Ar,
                CityId = hospital.CityId,
                Address = hospital.Address,
                Address_Ku = hospital.Address_Ku,
                Address_Ar = hospital.Address_Ar,
                FinalBookMessage = hospital.FinalBookMessage,
                FinalBookMessage_Ku = hospital.FinalBookMessage_Ku,
                FinalBookMessage_Ar = hospital.FinalBookMessage_Ar,
                FinalBookSMSMessage = hospital.FinalBookSMSMessage,
                FinalBookSMSMessage_Ku = hospital.FinalBookSMSMessage_Ku,
                FinalBookSMSMessage_Ar = hospital.FinalBookSMSMessage_Ar,
                GoogleMap_lat = hospital.Location?.Y.ToString(),
                GoogleMap_lng = hospital.Location?.X.ToString(),
                listPlaces = places,
                Logo = hospital.Logo
            };

            if (!string.IsNullOrEmpty(hospitalViewModel.Logo))
            {
                ViewBag.LogoPreview = "<img src=" + hospitalViewModel.Logo + " alt=\"Logo\">";
            }

            return View(hospitalViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(HospitalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string message = string.Empty;

                    if (model.Id == null)
                    {
                        var hospital = new Hospital
                        {
                            Name = model.Name,
                            Name_Ku = model.Name_Ku,
                            Name_Ar = model.Name_Ar,
                            Description = model.Description,
                            Description_Ku = model.Description_Ku,
                            Description_Ar = model.Description_Ar,
                            CityId = model.CityId,
                            Address = model.Address,
                            Address_Ku = model.Address_Ku,
                            Address_Ar = model.Address_Ar,
                            FinalBookMessage = model.FinalBookMessage,
                            FinalBookMessage_Ku = model.FinalBookMessage_Ku,
                            FinalBookMessage_Ar = model.FinalBookMessage_Ar,
                            FinalBookSMSMessage = model.FinalBookSMSMessage,
                            FinalBookSMSMessage_Ku = model.FinalBookSMSMessage_Ku,
                            FinalBookSMSMessage_Ar = model.FinalBookSMSMessage_Ar,
                            CreatedAt = DateTime.Now
                        };

                        await _hospitalService.InsertHospitalAsync(hospital);

                        message = Messages.ItemAddedSuccessFully;
                    }
                    else
                    {
                        var hospital = await _hospitalService.GetHospitalByIdAsync(model.Id.Value);

                        hospital.Name = model.Name;
                        hospital.Name_Ku = model.Name_Ku;
                        hospital.Name_Ar = model.Name_Ar;
                        hospital.Description = model.Description;
                        hospital.Description_Ku = model.Description_Ku;
                        hospital.Description_Ar = model.Description_Ar;
                        hospital.CityId = model.CityId;
                        hospital.Address = model.Address;
                        hospital.Address_Ku = model.Address_Ku;
                        hospital.Address_Ar = model.Address_Ar;
                        hospital.FinalBookMessage = model.FinalBookMessage;
                        hospital.FinalBookMessage_Ku = model.FinalBookMessage_Ku;
                        hospital.FinalBookMessage_Ar = model.FinalBookMessage_Ar;
                        hospital.FinalBookSMSMessage = model.FinalBookSMSMessage;
                        hospital.FinalBookSMSMessage_Ku = model.FinalBookSMSMessage_Ku;
                        hospital.FinalBookSMSMessage_Ar = model.FinalBookSMSMessage_Ar;
                        hospital.UpdatedAt = DateTime.Now;

                        double.TryParse(model.GoogleMap_lng, out double x_longitude);
                        double.TryParse(model.GoogleMap_lat, out double y_latitude);
                        hospital.Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                        {
                            SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                        };

                        _hospitalService.UpdateHospital(hospital);

                        message = Messages.ItemUpdatedSuccessFully;
                    }

                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = message });

                    return RedirectToAction("Index", "Hospital", new { area = "Admin" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("HospitalCrud", e.Message);
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = e.Message });
            }

            model.listPlaces = _commonUtils.PopulateCitiesList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            try
            {
                var hospital = _hospitalService.GetHospitalById((int)id);

                if (hospital == null) throw new Exception("Hospital Not Found");

                var pendingAppointments = _appointmentService.GetAllForHospital((int)id).Any(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now);

                if (pendingAppointments) throw new Exception("This Hospital Has Pending Turns");

                _hospitalService.DeleteHospital(hospital);

                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemDeletedSuccessFully });
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Core.Resources.UI.AdminPanel.PanelResource.ItemIsUsedYouCannotDeleteIt });
                    }
                }
            }
            catch (Exception e)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = e.Message });
            }

            return RedirectToAction("Index", "Hospital", new { area = "Admin" });
        }

        [HttpGet]
        //[NoDirectAccess]
        public IActionResult Details(int id)
        {
            var hospital = _hospitalService.GetHospitalById(id);

            if (hospital == null) throw new EntityNotFoundException();

            var details = new HospitalDetailsViewModel
            {
                Id = hospital.Id,
                Name = Lng == Lang.KU ? hospital.Name_Ku : hospital.Name_Ar,
                Description = Lng == Lang.KU ? hospital.Description_Ku : hospital.Description_Ar,
                Place = Lng == Lang.KU ? (hospital.City.Province.Name_Ku + ", " + hospital.City.Name_Ku) : hospital.City.Province.Name_Ar + ", " + hospital.City.Name_Ar,
                Address = Lng == Lang.KU ? hospital.Address_Ku : hospital.Address_Ar
            };

            return PartialView(details);
        }
    }
}