using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Persons;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.Global;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.Web.Controllers
{
    public class CommonClinicController : CpanelBaseController
    {
        #region Ctor
        private static Logger logger;
        private readonly IAppointmentService _appointmentService;
        private readonly ICommonUtils _commonUtils;
        private readonly IHospitalService _hospitalService;
        private readonly IClinicService _clinicService;
        private readonly IWorkContext _workContext;
        private readonly IPersonService _userService;
        private readonly IClinicPersonsService _clinicUsersService;
        private readonly BanobatDbContext _dbContext;
        public CommonClinicController(IAppointmentService appointmentService,
                                      ICommonUtils commonUtils,
                                      IHospitalService hospitalService,
                                      IClinicService clinicService,
                                      IWorkContext workContext,
                                      IPersonService userService,
                                      IClinicPersonsService clinicUsersService,
                                      BanobatDbContext dbContext) : base(workContext)
        {
            _appointmentService = appointmentService;
            _commonUtils = commonUtils;
            _hospitalService = hospitalService;
            _clinicService = clinicService;
            _workContext = workContext;
            _userService = userService;
            _clinicUsersService = clinicUsersService;
            logger = LogManager.GetCurrentClassLogger();
            _dbContext = dbContext;
        }
        #endregion       

        #region List
        [HttpGet]
        [CheckLoginAs(RequestedAreas = "admin,hospitalmanager")]
        [Authorize(Roles = "admin,hospitalmanager")]
        public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int? hospitalId = null)
        {
            ViewBag.Lang = Lng;

            ViewBag.LoginAs = LoginAs.ToString();

            if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
            {
                hospitalId = _hospitalService.GetCurrentHospital()?.Id;
            }
            else
            {
                ViewBag.Hospitals = await GetHospitalsSelectListAsync();
            }

            ViewBag.HospitalId = hospitalId;

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";

            if (!string.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var queryModel = new QueryModel<Clinic>
            {
                SearchString = searchString,
                SearchStringFilterProperties = new List<Expression<Func<Clinic, string>>>
                {
                    x => x.Name,
                    y => y.Name_Ar,
                    z => z.Name_Ku
                },
                OrderBy = x => Lng == Lang.KU ? x.Name_Ku : x.Name_Ar,
                IsOrderByDesc = sortOrder == "name_desc" ? true : false
            };

            if (hospitalId != null)
            {
                queryModel.Predicates.Add(x => x.HospitalId == hospitalId);
            }

            var query = _clinicService.DynamicQuery(queryModel);

            var clinics = query.Select(x => new List
            {
                Id = x.Id,
                Description = Lng == Lang.AR ? x.Description_Ar : Lng == Lang.KU ? x.Description_Ku : x.Description,
                Name = Lng == Lang.AR ? x.Name_Ar : Lng == Lang.KU ? x.Name_Ku : x.Name,
                Hospital = x.HospitalId != null ? Lng == Lang.AR ? x.Hospital.Name_Ar : Lng == Lang.KU ? x.Hospital.Name_Ku : x.Hospital.Name : "",
                Managers = x.ClinicUsers.Where(c => c.IsManager).Select(m => m.Person.FirstName + " " + m.Person.SecondName + " " + m.Person.ThirdName).ToList()
            });

            var pageSize = 10;

            var pageNumber = (page ?? 1);

            var result = clinics.ToPagedList(pageNumber, pageSize);

            return View(result);
        }
        #endregion

        #region CRUD
        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager")]
        public async Task<IActionResult> Create()
        {
            ViewBag.LoginAs = LoginAs.ToString();

            if (LoginAs == Shared.Enums.LoginAs.ADMIN)
            {
                ViewBag.Hospitals = await GetHospitalsSelectListAsync();
            }

            var model = new ClinicViewModel { listCities = _commonUtils.PopulateCitiesList() };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(ClinicViewModel Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
                    {
                        Model.HospitalId = _hospitalService.GetCurrentHospital()?.Id;
                    }
                    
                    var clinic = new Clinic();

                    //Set New Phones To clinic
                    // :: First:> Delete all pre phones
                    var clinicPhones = new List<ShiftCenterPhoneModel>
                    {
                        new ShiftCenterPhoneModel
                        {
                            PhoneNumber = Model.Phone1,
                            IsForReserve = Model.Phone1IsForReserve,
                        }
                    };

                    if (Model.Phone2 != null)
                    {
                        clinicPhones.Add(new ShiftCenterPhoneModel
                        {
                            PhoneNumber = Model.Phone2,
                            IsForReserve = Model.Phone2IsForReserve,
                        });
                    }
                    if (Model.Phone3 != null)
                    {
                        clinicPhones.Add(new ShiftCenterPhoneModel
                        {
                            PhoneNumber = Model.Phone3,
                            IsForReserve = Model.Phone3IsForReserve,
                        });
                    }

                    if (Model.Id.HasValue)
                    {
                        #region Edit clinic
                        clinic = await _dbContext.Clinics.FindAsync(Model.Id);

                        if (clinic == null) throw new EntityNotFoundException();

                        _dbContext.Entry(clinic).State = EntityState.Modified;
                        if (LoginAs == Shared.Enums.LoginAs.ADMIN)
                        {
                            clinic.HospitalId = Model.HospitalId;
                            clinic.IsIndependent = Model.HospitalId == null;
                        }
                        clinic.Name = Model.Name;
                        clinic.Name_Ku = Model.Name_Ku;
                        clinic.Name_Ar = Model.Name_Ar;
                        clinic.Description = Model.Description;
                        clinic.Description_Ku = Model.Description_Ku;
                        clinic.Description_Ar = Model.Description_Ar;
                        clinic.CityId = Model.CityId;
                        clinic.Address = Model.Address;
                        clinic.Address_Ku = Model.Address_Ku;
                        clinic.Address_Ar = Model.Address_Ar;
                        clinic.FinalBookMessage = Model.FinalBookMessage;
                        clinic.FinalBookMessage_Ku = Model.FinalBookMessage_Ku;
                        clinic.FinalBookMessage_Ar = Model.FinalBookMessage_Ar;
                        clinic.FinalBookSMSMessage = Model.FinalBookSMSMessage;
                        clinic.FinalBookSMSMessage_Ku = Model.FinalBookSMSMessage_Ku;
                        clinic.FinalBookSMSMessage_Ar = Model.FinalBookSMSMessage_Ar;                      
                        clinic.Notification = Model.Notification;
                        clinic.Notification_Ku = Model.Notification_Ku;
                        clinic.Notification_Ar = Model.Notification_Ar;
                        clinic.IsGovernmental = Model.IsGovernmental;
                        clinic.IsHostelry = Model.IsHostelry;
                        clinic.Type = Model.Type;
                        clinic.UpdatedAt = DateTime.Now;
                        clinic.PhoneNumbers = clinicPhones;

                        double.TryParse(Model.GoogleMap_lng, out double x_longitude);
                        double.TryParse(Model.GoogleMap_lat, out double y_latitude);
                        clinic.Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                        {
                            SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                        };                       
                        logger.Info("Clinic with name " + clinic.Name_Ku + " edited by " + CurrentUserName);
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Core.Resources.EntitiesResources.Messages.ItemUpdatedSuccessFully });
                        #endregion
                    }
                    else
                    {
                        if (LoginAs ==  Shared.Enums.LoginAs.CLINICMANAGER)
                        {
                            throw new Exception("You can not create clinic from here");
                        }

                        double.TryParse(Model.GoogleMap_lng, out double x_longitude);
                        double.TryParse(Model.GoogleMap_lat, out double y_latitude);

                        #region Add New clinic
                        clinic = new Clinic
                        {
                            Name = Model.Name,
                            Name_Ku = Model.Name_Ku,
                            Name_Ar = Model.Name_Ar,
                            Description = Model.Description,
                            Description_Ku = Model.Description_Ku,
                            Description_Ar = Model.Description_Ar,
                            CityId = Model.CityId,
                            Address = Model.Address,
                            Address_Ku = Model.Address_Ku,
                            Address_Ar = Model.Address_Ar,
                            IsIndependent = Model.HospitalId == null,
                            IsApproved = true,
                            IsDeleted = false,
                            HospitalId = Model.HospitalId,
                            FinalBookMessage = Model.FinalBookMessage,
                            FinalBookMessage_Ku = Model.FinalBookMessage_Ku,
                            FinalBookMessage_Ar = Model.FinalBookMessage_Ar,
                            FinalBookSMSMessage = Model.FinalBookSMSMessage,
                            FinalBookSMSMessage_Ku = Model.FinalBookSMSMessage_Ku,
                            FinalBookSMSMessage_Ar = Model.FinalBookSMSMessage_Ar,                           
                            Notification_Ku = Model.Notification_Ku,
                            Notification = Model.Notification,
                            Notification_Ar = Model.Notification_Ar,
                            IsGovernmental = Model.IsGovernmental,
                            IsHostelry = Model.IsHostelry,
                            Type = Model.Type,
                            PhoneNumbers = clinicPhones,
                            CreatedAt = DateTime.Now,
                            Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                            {
                                SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                            }
                        };
                        _dbContext.Clinics.Add(clinic);
                        await _dbContext.SaveChangesAsync();
                        _dbContext.Entry(clinic).State = EntityState.Modified;
                        logger.Info("Clinic with name " + clinic.Name_Ku + " created by " + HttpContext.User.Identity.Name);
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully });
                        #endregion

                    }                   

                    await _dbContext.SaveChangesAsync();                    

                    if (LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
                    {
                        return RedirectToAction("Index", "Home", new { area = "ClinicManager" });
                    }
                    return RedirectToAction("Index", "CommonClinic", new { area = "" });
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Model.Id.HasValue ? Core.Resources.EntitiesResources.Messages.AnErrorOccuredWhileUpdateItem : Core.Resources.EntitiesResources.Messages.AnErrorOccuredWhileAddingItem });
            if (LoginAs != Shared.Enums.LoginAs.HOSPITALMANAGER)
            {
                ViewBag.Hospitals = await GetHospitalsSelectListAsync();
            }
            Model.listCities = _commonUtils.PopulateCitiesList();
            return View(Model);

        }

        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.LoginAs = LoginAs.ToString();

            if (LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
            {
                id = _clinicService.GetCurrentClinic()?.Id;
            }
            else
            {
                if (LoginAs == Shared.Enums.LoginAs.ADMIN)
                {
                    ViewBag.Hospitals = await GetHospitalsSelectListAsync();
                }
            }

            if (id == null) throw new ArgumentNullException(nameof(id));

            var clinic = _clinicService.GetClinicById((int)id);

            if (clinic == null) throw new EntityNotFoundException();

            var phonesCount = clinic.PhoneNumbers?.Count ?? 0;

            var phonesArray = clinic.PhoneNumbers != null ? clinic.PhoneNumbers.ToArray() : new ShiftCenterPhoneModel[3];

            var model = new ClinicViewModel
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Name_Ku = clinic.Name_Ku,
                Name_Ar = clinic.Name_Ar,
                Description = clinic.Description,
                Description_Ku = clinic.Description_Ku,
                Description_Ar = clinic.Description_Ar,
                CityId = clinic.IsIndependent == true ? (int)clinic.CityId : clinic.Hospital.CityId,
                listCities = _commonUtils.PopulateCitiesList(),
                Address = clinic.IsIndependent == true ? clinic.Address : clinic.Hospital.Address,
                Address_Ku = clinic.IsIndependent == true ? clinic.Address_Ku : clinic.Hospital.Address_Ku,
                Address_Ar = clinic.IsIndependent == true ? clinic.Address_Ar : clinic.Hospital.Address_Ar,
                Phone1 = phonesCount >= 1 ? phonesArray[0].PhoneNumber : null,
                Phone2 = phonesCount >= 2 ? phonesArray[1].PhoneNumber : null,
                Phone3 = phonesCount >= 3 ? phonesArray[2].PhoneNumber : null,
                Phone1IsForReserve = phonesCount >= 1 && phonesArray[0].IsForReserve,
                Phone2IsForReserve = phonesCount >= 2 && phonesArray[1].IsForReserve,
                Phone3IsForReserve = phonesCount >= 3 && phonesArray[2].IsForReserve,
                GoogleMap_lat = clinic.Location != null && clinic.Location?.Y > 0 ? clinic.Location?.Y.ToString() : "",
                GoogleMap_lng = clinic.Location != null && clinic.Location?.X > 0 ? clinic.Location?.X.ToString() : "",
                FinalBookMessage = clinic.FinalBookMessage,
                FinalBookMessage_Ku = clinic.FinalBookMessage_Ku,
                FinalBookMessage_Ar = clinic.FinalBookMessage_Ar,
                FinalBookSMSMessage = clinic.FinalBookSMSMessage,
                FinalBookSMSMessage_Ku = clinic.FinalBookSMSMessage_Ku,
                FinalBookSMSMessage_Ar = clinic.FinalBookSMSMessage_Ar,
                Notification = clinic.Notification,
                Notification_Ku = clinic.Notification_Ku,
                Notification_Ar = clinic.Notification_Ar,
                IsGovernmental = clinic.IsGovernmental,
                IsHostelry = clinic.IsHostelry,
                Type = clinic.Type,
                HospitalId = clinic.HospitalId,
                Logo = clinic.Logo
            };

            if (!string.IsNullOrEmpty(model.Logo))
            {
                ViewBag.LogoPreview = "<img src=" + model.Logo + " alt=\"Logo\">";
            }

            return View("Create", model);
        }

        [HttpPost]
        [Authorize(Roles = "admin,hospitalmanager")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var message = string.Empty;

            var resultStatus = MVCResultStatus.danger;
            try
            {
                var clinic = _clinicService.GetClinicById((int)id);
                if (clinic == null) throw new EntityNotFoundException();
                if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
                {
                    var currentHospital = _hospitalService.GetCurrentHospital()?.Id;
                    if (clinic.HospitalId != currentHospital)
                    {
                        throw new Exception("UnAuthorized to delete clinic");
                    }
                }
                var pendingAppointments = _appointmentService.GetAllForClinic(clinic.Id).Where(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now).ToList();
                if (pendingAppointments.Count >= 1)
                {
                    resultStatus = MVCResultStatus.danger;
                    message = Core.Resources.EntitiesResources.Messages.CenterHasPendingTurns;
                }
                _clinicService.DeleteClinic(clinic);
                logger.Info("Clinic with name " + clinic.Name_Ku + " deleted by " + HttpContext.User.Identity.Name);
                resultStatus = MVCResultStatus.success;
                message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully;
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        resultStatus = MVCResultStatus.danger;
                        message = Core.Resources.UI.AdminPanel.PanelResource.ItemIsUsedYouCannotDeleteIt;
                    }
                }
            }
            catch (Exception)
            {
                resultStatus = MVCResultStatus.danger;
                message = Core.Resources.EntitiesResources.Messages.AnErrorOccuredWhileDeleteItem;
            }

            TempData.Put("message", new MVCResultModel { status = resultStatus, message = message });

            return RedirectToAction("Index", "CommonClinic", new { area = "" });
        }

        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager")]
        //[NoDirectAccess]
        public IActionResult Details(int id)
        {
            var clinic = _clinicService.GetClinicById(id);

            if (clinic == null) throw new EntityNotFoundException();

            var details = new ClinicDetailsViewModel
            {
                Name = Lng == Lang.KU ? clinic.Name_Ku : clinic.Name_Ar,
                Description = Lng == Lang.KU ? clinic.Description_Ku : clinic.Description_Ar,
                Place = Lng == Lang.KU ? (clinic.City.Province.Name_Ku + ", " + clinic.City.Name_Ku) : (clinic.City.Province.Name_Ar + ", " + clinic.City.Name_Ar),
                Address = Lng == Lang.KU ? clinic.Address_Ku : clinic.Address_Ar,
                IsGovernmental = clinic.IsGovernmental ? Global.Yes : Global.No,
                IsHostelry = clinic.IsHostelry ? Global.Yes : Global.No,
                Type = Enum.GetName(typeof(ClinicType), clinic.Type),
                Phones = clinic.PhoneNumbers.Select(x => x.PhoneNumber).ToList(),
                Managers = clinic.ClinicUsers.Where(x => x.IsManager == true).Select(x => x.Person.FullName).ToList(),
                PolyclinicsCount = clinic.ShiftCenters.Count,
                CreationDate = DateTime.Parse(clinic.CreatedAt.ToString()).Year + " " + DateTime.Parse(clinic.CreatedAt.ToString()).Month + " " + DateTime.Parse(clinic.CreatedAt.ToString()).Day
            };

            return PartialView(details); ;
        }
        #endregion       

        #region Helper Methods
        private async Task<List<SelectListItem>> GetHospitalsSelectListAsync()
        {
            var hospitals = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Text = "..."
                }
            };

            var hospitalsLit = await _hospitalService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name
            }).ToListAsync();

            hospitals.AddRange(hospitalsLit);

            return hospitals;
        }
        #endregion
    }
}