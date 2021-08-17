using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.Web.Controllers
{
    public class PolyclinicController : CpanelBaseController
    {
        #region Fields              
        private static Logger logger;
        private readonly IAppointmentService _appointmentService;
        private readonly IHospitalService _hospitalService;
        private readonly IShiftCenterService _polyClinicService;
        private readonly IClinicService _clinicService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly ICommonUtils _commonUtils;
        private readonly IPersonService _userService;
        private readonly IWorkContext _workContext;
        private readonly IServicesService _healthServiceService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor       
        public PolyclinicController(IAppointmentService appointmentService,
                                    IShiftCenterService polyclinicService,
                                    IHospitalService hospitalService,
                                    IClinicService clinicService,
                                    IServiceSupplyService serviceSupplyService,
                                    ICommonUtils commonUtils,
                                    IPersonService userService,
                                    IWorkContext workContext,
                                    IServicesService healthServiceService,
                                    IHostingEnvironment hostingEnvironment, BanobatDbContext dbContext) : base(workContext)
        {
            _appointmentService = appointmentService;
            _polyClinicService = polyclinicService;
            _hospitalService = hospitalService;
            _clinicService = clinicService;
            _serviceSupplyService = serviceSupplyService;
            _commonUtils = commonUtils;
            _userService = userService;
            _workContext = workContext;
            _healthServiceService = healthServiceService;
            _hostingEnvironment = hostingEnvironment;
            _dbContext = dbContext;
            logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        #region Properties
        private Hospital _currentHospital;
        public Hospital CurrentHospital => _currentHospital ?? (_currentHospital = _hospitalService.GetCurrentHospital());

        private Clinic _currentClinic;
        public Clinic CurrentClinic => _currentClinic ?? (_currentClinic = _clinicService.GetCurrentClinic());

        private ShiftCenter _currentPolyClinic;
        public ShiftCenter CurrentPolyClinic => _currentPolyClinic ?? (_currentPolyClinic = _polyClinicService.GetCurrentShiftCenter());

        private string BasePrescriptLocalPath => "wwwroot\\uploaded\\prescriptions\\prescript_base.mrt";

        private string BasePrescriptFullPath => Path.Combine(_hostingEnvironment.ContentRootPath, BasePrescriptLocalPath);
        #endregion

        #region Helper Methods
        private ShiftCenter GetPolyclinic(int? polyclinicId)
        {
            if (polyclinicId != null)
            {
                switch (LoginAs)
                {
                    case Shared.Enums.LoginAs.ADMIN:
                        return _polyClinicService.GetShiftCenterById((int)polyclinicId);
                    case Shared.Enums.LoginAs.HOSPITALMANAGER:
                        return _polyClinicService.GetAllShiftCentersForHospital(CurrentHospital.Id).FirstOrDefault(x => x.Id == polyclinicId);
                    case Shared.Enums.LoginAs.CLINICMANAGER:
                        if (CurrentClinic != null)
                            return CurrentClinic.ShiftCenters.FirstOrDefault(x => x.Id == polyclinicId);
                        break;
                    case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                    case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                        if (CurrentPolyClinic != null)
                        {
                            if (polyclinicId == CurrentPolyClinic.Id)
                                return CurrentPolyClinic;
                        }
                        break;
                }
            }

            return null;
        }

        private ServiceSupply GetServiceSupply(int? serviceSupplyId)
        {
            if (serviceSupplyId != null)
            {
                switch (LoginAs)
                {
                    case Shared.Enums.LoginAs.ADMIN:
                        return _serviceSupplyService.GetServiceSupplyById((int)serviceSupplyId);
                    case Shared.Enums.LoginAs.CLINICMANAGER:
                        if (CurrentClinic != null)
                            return _serviceSupplyService.GetServiceSupplyByIdForClinic(CurrentClinic.Id, (int)serviceSupplyId);
                        break;
                    case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                    case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                        if (CurrentPolyClinic != null)
                            return _serviceSupplyService.GetServiceSupplyByIdForPolyClinic(CurrentPolyClinic.Id, (int)serviceSupplyId);
                        break;
                }
            }
            return null;
        }

        private async Task<IList<SelectListItem>> GetDoctorsAsync()
        {
            var result = new List<SelectListItem>();

            switch (LoginAs)
            {
                case Shared.Enums.LoginAs.ADMIN:
                    result = (from u in await _userService.GetAllUserDoctorsAsync()
                              select new SelectListItem
                              {
                                  Value = u.Id.ToString(),
                                  Text = (Lng == Lang.KU ? u.FullName_Ku : Lng == Lang.AR ? u.FullName_Ar : u.FullName) + " - " + u.Mobile
                              }).ToList();
                    break;
                case Shared.Enums.LoginAs.CLINICMANAGER:
                    if (CurrentClinic != null)
                    {
                        result = (from u in await _userService.GetAllUserDoctorsForClinicAsync(CurrentClinic.Id)
                                  select new SelectListItem
                                  {
                                      Value = u.Id.ToString(),
                                      Text = (Lng == Lang.KU ? u.FullName_Ku : Lng == Lang.AR ? u.FullName_Ar : u.FullName) + " - " + u.Mobile
                                  }).ToList();
                    }
                    break;
                case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                    if (CurrentPolyClinic != null)
                    {
                        result = (from u in await _userService.GetAllUserDoctorsForPolyClinicAsync(CurrentPolyClinic.Id)
                                  select new SelectListItem
                                  {
                                      Value = u.Id.ToString(),
                                      Text = (Lng == Lang.KU ? u.FullName_Ku : Lng == Lang.AR ? u.FullName_Ar : u.FullName) + " - " + u.Mobile
                                  }).ToList();
                    }
                    break;
            }

            return result;
        }

        private async Task<List<SelectListItem>> GetClinicssSelectListAsync(bool isNullable)
        {
            var clinics = new List<SelectListItem>();

            if (isNullable)
            {
                clinics.Add(new SelectListItem
                {
                    Value = "",
                    Text = "..."
                });
            }

            var query = _clinicService.Table;

            if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
            {
                var hospitalId = CurrentHospital.Id;
                query = query.Where(x => x.HospitalId == hospitalId);
            }

            var clinicsList = await query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Name_Ku : x.Name_Ar
            }).ToListAsync();

            clinics.AddRange(clinicsList);

            return clinics;
        }
        #endregion

        [HttpGet]
        [CheckLoginAs(RequestedAreas = "admin,hospitalmanager,clinicmanager")]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int? clinicId = null, int? hospitalId = null, ShiftCenterType? type = null)
        {
            ViewBag.Lang = Lng;

            ViewBag.LoginAs = LoginAs.ToString();

            ViewBag.ShiftCenterTypes = MyEnumExtensions.EnumToSelectList<ShiftCenterType>().ToList();

            if (_workContext.LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
            {
                clinicId = _clinicService.GetCurrentClinic()?.Id;
            }
            else
            {
                ViewBag.Clinics = await GetClinicssSelectListAsync(true);

                if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
                {
                    hospitalId = CurrentHospital?.Id;
                }
            }

            ViewBag.Type = type;

            ViewBag.ClinicId = clinicId;

            ViewBag.HospitalId = hospitalId;

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";

            if (!string.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var queryModel = new QueryModel<ShiftCenter>
            {
                SearchString = searchString,
                SearchStringFilterProperties = new List<Expression<Func<ShiftCenter, string>>>
                {
                    m => m.Name_Ar,
                    w => w.Name_Ku,
                    x => x.Name,
                    y => y.Description,
                    n => n.Description_Ar,
                    o => o.Description_Ku,
                    p => p.Address,
                    q => q.Address_Ar,
                    r => r.Address_Ku
                },
                OrderBy = x => Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name,
                IsOrderByDesc = sortOrder == "name_desc" ? true : false
            };

            queryModel.Predicates.Add(x => x.IsApproved);

            if (type != null)
            {
                queryModel.Predicates.Add(x => x.Type.HasFlag(type));
            }

            if (hospitalId != null)
            {
                queryModel.Predicates.Add(x => x.Clinic != null && x.Clinic.HospitalId == hospitalId);
            }

            if (clinicId != null)
            {
                queryModel.Predicates.Add(x => x.ClinicId == clinicId);
            }

            var query = _polyClinicService.DynamicQuery(queryModel);

            var polyclinics = query.Select(x => new ListPoliClinicsViewModel
            {
                PoliClinicId = x.Id,
                PoliClinicName = Lng == Lang.AR ? x.Name_Ar : Lng == Lang.KU ? x.Name_Ku : x.Name,
                PoliClinicDescription = Lng == Lang.AR ? x.Description_Ar : Lng == Lang.KU ? x.Description_Ku : x.Description,
                Clinic = x.ClinicId != null ? Lng == Lang.AR ? x.Clinic.Name_Ar : Lng == Lang.KU ? x.Clinic.Name_Ku : x.Clinic.Name : "",
                Doctors = x.ServiceSupplies.Select(s => Lng == Lang.KU ? s.Person.FullName_Ku : Lng == Lang.AR ? s.Person.FullName_Ar : s.Person.FullName).ToList(),
            });

            //ViewBag.ClinicsCount = clinics.Count();

            var pageSize = 10;
            var pageNumber = (page ?? 1);

            var result = polyclinics.ToPagedList(pageNumber, pageSize);

            return View(result);
        }

        [Route("Add")]
        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        public async Task<IActionResult> AddPoliClinic()
        {
            ViewBag.Lang = Lng;

            ViewBag.LoginAs = LoginAs.ToString();

            // Center Types
            var centerTypesList = new List<SelectListItem>();
            foreach (ShiftCenterType p in Enum.GetValues(typeof(ShiftCenterType)))
            {
                centerTypesList.Add(new SelectListItem
                {
                    Text = p.ToString(),
                    Value = p.ToString()
                });
            }
            ViewBag.ShiftCenterTypes = centerTypesList;

            if (LoginAs != Shared.Enums.LoginAs.CLINICMANAGER)
            {
                ViewBag.Clinics = await GetClinicssSelectListAsync(LoginAs == Shared.Enums.LoginAs.ADMIN);
            }
            var model = new PoliClinicViewModel { listCities = _commonUtils.PopulateCitiesList() };

            return View(model);
        }

        [Route("Add")]
        [HttpPost]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager,polyclinicmanager,doctor,secretary,beautycentermanager")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> AddPoliClinic(PoliClinicViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
                    {
                        model.ClinicId = _clinicService.GetCurrentClinic()?.Id;
                    }

                    var poliClinic = new ShiftCenter();
                    var phones = new List<ShiftCenterPhoneModel>
                    {
                        new ShiftCenterPhoneModel
                        {
                            PhoneNumber = model.Phone1,
                            IsForReserve = model.Phone1IsForReserve,
                        }
                    };

                    if (model.Phone2 != null)
                    {
                        phones.Add(new ShiftCenterPhoneModel
                        {
                            PhoneNumber = model.Phone2,
                            IsForReserve = model.Phone2IsForReserve,
                        });
                    }
                    if (model.Phone3 != null)
                    {
                        phones.Add(new ShiftCenterPhoneModel
                        {
                            PhoneNumber = model.Phone3,
                            IsForReserve = model.Phone3IsForReserve,
                        });
                    }

                    ShiftCenterType? selectedTypes = null;
                    foreach (var p in model.Types)
                    {
                        Enum.TryParse(p, out ShiftCenterType addedPermission);
                        if (selectedTypes == null)
                        {
                            selectedTypes = addedPermission;
                        }
                        else
                        {
                            selectedTypes |= addedPermission;
                        }
                    }

                    if (model.Id.HasValue)
                    {
                        if (LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER || LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
                        {
                            if (model.Id != _polyClinicService.GetCurrentShiftCenter()?.Id)
                            {
                                throw new Exception("UnAuthorized");
                            }
                        }
                        #region Edit Policlinic
                        poliClinic = await _dbContext.ShiftCenters.FindAsync(model.Id);
                        if (poliClinic == null) throw new Exception(Messages.PolyclinicNotFound);

                        _dbContext.Entry(poliClinic).State = EntityState.Modified;

                        if (LoginAs == Shared.Enums.LoginAs.ADMIN || LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
                        {
                            poliClinic.ClinicId = model.ClinicId;
                            poliClinic.IsIndependent = model.ClinicId == null;
                        }

                        poliClinic.Type = selectedTypes.Value;
                        poliClinic.Name = model.Name;
                        poliClinic.Name_Ku = model.Name_Ku;
                        poliClinic.Name_Ar = model.Name_Ar;
                        poliClinic.Description = model.Description;
                        poliClinic.Description_Ku = model.Description_Ku;
                        poliClinic.Description_Ar = model.Description_Ar;
                        poliClinic.CityId = model.CityId;
                        poliClinic.Address = model.Address;
                        poliClinic.Address_Ku = model.Address_Ku;
                        poliClinic.Address_Ar = model.Address_Ar;
                        poliClinic.FinalBookMessage = model.FinalBookMessage;
                        poliClinic.FinalBookMessage_Ku = model.FinalBookMessage_Ku;
                        poliClinic.FinalBookMessage_Ar = model.FinalBookMessage_Ar;
                        poliClinic.FinalBookSMSMessage = model.FinalBookSMSMessage;
                        poliClinic.FinalBookSMSMessage_Ku = model.FinalBookSMSMessage_Ku;
                        poliClinic.FinalBookSMSMessage_Ar = model.FinalBookSMSMessage_Ar;
                        poliClinic.BookingRestrictionHours = model.BookingRestriction;
                        poliClinic.ActiveDaysAhead = model.ActiveDaysAhead;
                        poliClinic.Notification = model.Notification;
                        poliClinic.Notification_Ku = model.Notification_Ku;
                        poliClinic.Notification_Ar = model.Notification_Ar;
                        poliClinic.PhoneNumbers = phones;
                        poliClinic.SupportAppointments = model.SupportAppointments;
                        poliClinic.ShowInHealthBank = model.ShowInHealthBank;
                        poliClinic.UpdatedAt = DateTime.Now;

                        double.TryParse(model.GoogleMap_lng, out double x_longitude);
                        double.TryParse(model.GoogleMap_lat, out double y_latitude);
                        poliClinic.Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                        {
                            SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                        };

                        await _dbContext.SaveChangesAsync();

                        logger.Info("Polyclinic with name " + poliClinic.Name_Ku + " edited by " + HttpContext.User.Identity.Name);
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemUpdatedSuccessFully });
                        #endregion
                    }
                    else
                    {
                        if (LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER || LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
                        {
                            throw new Exception("You can not add polyclinic from here");
                        }

                        var strategy = _dbContext.Database.CreateExecutionStrategy();

                        await strategy.ExecuteAsync(async () =>
                        {
                            using (var transaction = _dbContext.Database.BeginTransaction())
                            {
                                try
                                {
                                    double.TryParse(model.GoogleMap_lng, out double x_longitude);
                                    double.TryParse(model.GoogleMap_lat, out double y_latitude);

                                    poliClinic = new ShiftCenter
                                    {
                                        Type = selectedTypes.Value,
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
                                        IsIndependent = model.ClinicId == null,
                                        IsApproved = true,
                                        IsDeleted = false,
                                        ClinicId = model.ClinicId,
                                        FinalBookMessage = model.FinalBookMessage,
                                        FinalBookMessage_Ku = model.FinalBookMessage_Ku,
                                        FinalBookMessage_Ar = model.FinalBookMessage_Ar,
                                        FinalBookSMSMessage = model.FinalBookSMSMessage,
                                        FinalBookSMSMessage_Ku = model.FinalBookSMSMessage_Ku,
                                        FinalBookSMSMessage_Ar = model.FinalBookSMSMessage_Ar,
                                        BookingRestrictionHours = model.BookingRestriction,
                                        Notification = model.Notification,
                                        Notification_Ku = model.Notification_Ku,
                                        Notification_Ar = model.Notification_Ar,
                                        AutomaticScheduleEnabled = false,
                                        KnownAsDoctorName = false,
                                        ActiveDaysAhead = model.ActiveDaysAhead,
                                        PhoneNumbers = phones,
                                        SupportAppointments = model.SupportAppointments,
                                        ShowInHealthBank = model.ShowInHealthBank,
                                        CreatedAt = DateTime.Now,
                                        // Pass the longitude as the first parameter (x) and the latitude as the second parameter (y) to the Point constructor.
                                        Location = new NetTopologySuite.Geometries.Point(x_longitude, y_latitude)
                                        {
                                            SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                                        },
                                        PrescriptionPath = ""
                                    };
                                    _dbContext.ShiftCenters.Add(poliClinic);

                                    await _dbContext.SaveChangesAsync();

                                    var firstHealthService = await _dbContext.Services.FirstOrDefaultAsync(x => poliClinic.Type.HasFlag(x.ServiceCategory.CenterType));

                                    if (firstHealthService != null)
                                    {
                                        _dbContext.CenterServices.Add(new Core.Domain.ShiftCenterService
                                        {
                                            HealthServiceId = firstHealthService.Id,
                                            ShiftCenterId = poliClinic.Id

                                        });
                                    }

                                    await _dbContext.SaveChangesAsync();

                                    transaction.Commit();

                                    logger.Info("Polyclinic with name " + poliClinic.Name_Ku + " created by " + HttpContext.User.Identity.Name);
                                }
                                catch
                                {
                                    transaction.Rollback();
                                    throw;
                                }
                            }
                        });
                    }

                    return RedirectToAction("EditPoliclinic", "Polyclinic", new { area = "", id = poliClinic.Id, tempMessage = Messages.ItemAddedSuccessFully });
                }
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = model.Id.HasValue ? Messages.AnErrorOccuredWhileUpdateItem : Messages.AnErrorOccuredWhileAddingItem });
            }
            if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER || LoginAs == Shared.Enums.LoginAs.ADMIN)
            {
                ViewBag.Clinics = await GetClinicssSelectListAsync(LoginAs == Shared.Enums.LoginAs.ADMIN);
            }
            model.listCities = _commonUtils.PopulateCitiesList();
            return View(model);

        }

        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager,polyclinicmanager,doctor,secretary,beautycentermanager")]
        public async Task<IActionResult> EditPoliclinic(int? id, string tempMessage = "")
        {
            ViewBag.Lang = Lng;

            ViewBag.LoginAs = LoginAs.ToString();

            // Center Types
            var centerTypesList = new List<SelectListItem>();
            foreach (ShiftCenterType p in Enum.GetValues(typeof(ShiftCenterType)))
            {
                centerTypesList.Add(new SelectListItem
                {
                    Text = p.ToString(),
                    Value = p.ToString()
                });
            }
            ViewBag.ShiftCenterTypes = centerTypesList;

            if (LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER || LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
            {
                id = _polyClinicService.GetCurrentShiftCenter()?.Id;
            }

            if (id == null) throw new ArgumentNullException(nameof(id));

            var poliClinic = _polyClinicService.GetShiftCenterById((int)id);

            if (poliClinic == null) throw new EntityNotFoundException();

            var phonesCount = poliClinic.PhoneNumbers != null ? poliClinic.PhoneNumbers.Count : 0;

            var phonesArray = poliClinic.PhoneNumbers != null ? poliClinic.PhoneNumbers.ToArray() : new ShiftCenterPhoneModel[3];

            var images = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.SHIFT_CENTER && x.OwnerTableId == poliClinic.Id).Select(x => new AddPoliclinicImageViewModel
            {
                Id = x.Id,
                name = x.Name,
                url = x.Url,
                thumbnailUrl = x.ThumbnailUrl,
                deleteType = "POST",
                deleteUrl = x.DeleteUrl,
                size = x.Size,
                PoliclinicId = poliClinic.Id
            }).ToListAsync();

            var resultModel = new PoliClinicViewModel
            {
                Id = poliClinic.Id,
                ClinicId = poliClinic.ClinicId,
                Name = poliClinic.Name,
                Name_Ku = poliClinic.Name_Ku,
                Name_Ar = poliClinic.Name_Ar,
                Description = poliClinic.Description,
                Description_Ku = poliClinic.Description_Ku,
                Description_Ar = poliClinic.Description_Ar,
                CityId = poliClinic.IsIndependent == true ? (int)poliClinic.CityId : (poliClinic.Clinic.IsIndependent == true ? (int)poliClinic.Clinic.CityId : poliClinic.Clinic.Hospital.CityId),
                listCities = _commonUtils.PopulateCitiesList(),
                Address = poliClinic.Address,
                Address_Ku = poliClinic.Address_Ku,
                Address_Ar = poliClinic.Address_Ar,
                Phone1 = phonesCount >= 1 ? phonesArray[0].PhoneNumber : null,
                Phone2 = phonesCount >= 2 ? phonesArray[1].PhoneNumber : null,
                Phone3 = phonesCount >= 3 ? phonesArray[2].PhoneNumber : null,
                Phone1IsForReserve = phonesCount >= 1 ? phonesArray[0].IsForReserve : false,
                Phone2IsForReserve = phonesCount >= 2 ? phonesArray[1].IsForReserve : false,
                Phone3IsForReserve = phonesCount >= 3 ? phonesArray[2].IsForReserve : false,
                GoogleMap_lat = poliClinic.Location != null && poliClinic.Location?.Y > 0 ? poliClinic.Location?.Y.ToString() : "",
                GoogleMap_lng = poliClinic.Location != null && poliClinic.Location?.X > 0 ? poliClinic.Location?.X.ToString() : "",
                BookingRestriction = poliClinic.BookingRestrictionHours,
                ActiveDaysAhead = poliClinic.ActiveDaysAhead,
                Notification = poliClinic.Notification,
                Notification_Ku = poliClinic.Notification_Ku,
                Notification_Ar = poliClinic.Notification_Ar,
                FinalBookMessage = poliClinic.FinalBookMessage,
                FinalBookMessage_Ku = poliClinic.FinalBookMessage_Ku,
                FinalBookMessage_Ar = poliClinic.FinalBookMessage_Ar,
                FinalBookSMSMessage = poliClinic.FinalBookSMSMessage,
                FinalBookSMSMessage_Ku = poliClinic.FinalBookSMSMessage_Ku,
                FinalBookSMSMessage_Ar = poliClinic.FinalBookSMSMessage_Ar,
                SupportAppointments = poliClinic.SupportAppointments,
                ShowInHealthBank = poliClinic.ShowInHealthBank,
                Images = images,
                Logo = poliClinic.Logo
            };

            // Center Types
            var currentTypes = new List<string>();
            foreach (ShiftCenterType p in Enum.GetValues(typeof(ShiftCenterType)))
            {
                if ((poliClinic.Type & p) != 0) currentTypes.Add(p.ToString());
            }
            resultModel.Types = currentTypes;

            if (LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER || LoginAs == Shared.Enums.LoginAs.ADMIN)
            {
                ViewBag.Clinics = await GetClinicssSelectListAsync(LoginAs == Shared.Enums.LoginAs.ADMIN);
            }

            if (!string.IsNullOrEmpty(tempMessage))
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = tempMessage });
            }

            if (!string.IsNullOrEmpty(resultModel.Logo))
            {
                ViewBag.LogoPreview = "<img src=" + resultModel.Logo + " alt=\"Logo\">";
            }

            return View("AddPoliClinic", resultModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            try
            {
                var poliClinic = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == id);

                if (poliClinic == null) throw new Exception(Messages.PolyclinicNotFound);

                if (LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
                {
                    if (poliClinic.ClinicId != CurrentClinic?.Id)
                    {
                        throw new Exception("UnAuthorized to delete clinic");
                    }
                }
                var pendingAppointments = _appointmentService.GetAllForPolyClinic(poliClinic.Id).Where(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now).ToList();

                if (pendingAppointments.Count >= 1)
                {
                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.CenterHasPendingTurns });
                    return RedirectToAction("Index", "Polyclinic", new { area = "" });
                }
                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        _dbContext.CenterServices.RemoveRange(poliClinic.PolyclinicHealthServices);

                        _dbContext.ShiftCenters.Remove(poliClinic);

                        await _dbContext.SaveChangesAsync();

                        transaction.Commit();
                    }
                });

                logger.Info("Polyclinic with name " + poliClinic.Name_Ku + " deleted by " + HttpContext.User.Identity.Name);
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemDeletedSuccessFully });
                return RedirectToAction("Index", "Polyclinic", new { area = "" });
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
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
            }

            return RedirectToAction("Index", "Polyclinic", new { area = "" });
        }

        [HttpGet]
        [Authorize(Roles = "admin,hospitalmanager,clinicmanager")]
        public IActionResult Details(int id)
        {
            var policlinic = _polyClinicService.GetShiftCenterById(id);

            if (policlinic == null) throw new EntityNotFoundException();

            var details = new PolyclinicDetailsViewModel
            {
                Id = policlinic.Id,
                Name = Lng == Lang.KU ? policlinic.Name_Ku : Lng == Lang.AR ? policlinic.Name_Ar : policlinic.Name,
                Description = Lng == Lang.KU ? policlinic.Description_Ku : Lng == Lang.AR ? policlinic.Description_Ar : policlinic.Description,
                Place = Lng == Lang.KU ? (policlinic.City.Province.Name_Ku + ", " + policlinic.City.Name_Ku) : policlinic.City.Province.Name_Ar + ", " + policlinic.City.Name_Ar,
                Address = Lng == Lang.KU ? policlinic.Address_Ku : Lng == Lang.AR ? policlinic.Address_Ar : policlinic.Address,
                Latitude = policlinic.Location?.Y.ToString(),
                Longitude = policlinic.Location?.X.ToString(),
                Phones = policlinic.PhoneNumbers.Select(x => x.PhoneNumber).ToList(),
                Managers = policlinic.ShiftCenterUsers.Where(x => x.IsManager == true).Select(x => x.Person.FullName).ToList(),
                Doctors = policlinic.ServiceSupplies.Select(x => x.Person.FirstName + " " + x.Person.FullName).ToList(),
                Type = policlinic.Type.ToString()
            };

            return PartialView(details);
        }

        #region Setting Health Services
        [HttpGet]
        public IActionResult SetHealthServices(int polyclinicId)
        {
            var polyclinic = GetPolyclinic(polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.ItemNotFound);

            var currentServices = (from h in polyclinic.PolyclinicHealthServices
                                   select new
                                   {
                                       h.Service.Id,
                                       Name = Lng == Lang.KU ? h.Service.Name_Ku : Lng == Lang.AR ? h.Service.Name_Ar : h.Service.Name,
                                       Price = h.Price ?? h.Service.Price.ToString(),
                                       CurrencyType = h.CurrencyType
                                   }).ToList();

            var allServices = _healthServiceService.GetAll().Where(x => polyclinic.Type.HasFlag(x.ServiceCategory.CenterType)).Select(x => new
            {
                x.Id,
                Name = Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name,
                Price = x.Price,
                CurrencyType = CurrencyType.USD
            }).ToList();

            var result = new List<SelectPolyclinicHealthServicesViewModel>();

            foreach (var item in allServices)
            {
                var currentItem = currentServices.FirstOrDefault(x => x.Id == item.Id);

                if (currentItem != null)
                {
                    result.Add(new SelectPolyclinicHealthServicesViewModel
                    {
                        Selected = true,
                        Id = item.Id,
                        Name = item.Name,
                        Price = currentItem.Price,
                        CurrencyType = currentItem.CurrencyType
                    });
                }
                else
                {
                    result.Add(new SelectPolyclinicHealthServicesViewModel
                    {
                        Selected = false,
                        Id = item.Id,
                        Name = item.Name,
                        CurrencyType = CurrencyType.USD
                    });
                }
            }

            ViewBag.Lang = Lng;

            TempData["area"] = LoginAs.ToString();

            return View(new SetPolyclinicHealthServicesViewModel
            {
                PoliClinicId = polyclinic.Id,
                PoliClinicName = Lng == Lang.KU ? polyclinic.Name_Ku : polyclinic.Name_Ar,
                Services = result
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetHealthServices(SetPolyclinicHealthServicesViewModel model)
        {
            try
            {
                TempData["area"] = LoginAs.ToString();

                if (ModelState.IsValid)
                {
                    var polyclinic = GetPolyclinic(model.PoliClinicId);

                    var strategy = _dbContext.Database.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () =>
                    {
                        using (var transaction = _dbContext.Database.BeginTransaction())
                        {
                            var _policlinic = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == polyclinic.Id);

                            var currentServices = _policlinic.PolyclinicHealthServices.ToList();

                            var selectedServices = model.Services.Where(x => x.Selected == true).ToList();

                            var nonSelectedServices = model.Services.Where(x => x.Selected != true).ToList();

                            foreach (var service in selectedServices)
                            {
                                if (!currentServices.Any(s => s.HealthServiceId == service.Id))
                                {
                                    var pcHealthService = new Core.Domain.ShiftCenterService
                                    {
                                        ShiftCenterId = _policlinic.Id,
                                        HealthServiceId = service.Id,
                                        Price = service.Price?.ToString(),
                                        CurrencyType = service.CurrencyType
                                    };

                                    _dbContext.CenterServices.Add(pcHealthService);
                                }
                                else
                                {
                                    var currentService = await _dbContext.CenterServices.FirstOrDefaultAsync(x => x.ShiftCenterId == _policlinic.Id && x.HealthServiceId == service.Id);

                                    if (currentService != null)
                                    {
                                        currentService.Price = service.Price?.ToString();

                                        currentService.CurrencyType = service.CurrencyType;

                                        _dbContext.CenterServices.Attach(currentService);

                                        _dbContext.Entry(currentService).State = EntityState.Modified;
                                    }
                                }
                            }

                            foreach (var service in nonSelectedServices)
                            {
                                if (currentServices.Any(s => s.HealthServiceId == service.Id))
                                {
                                    var pcHealthService = _policlinic.PolyclinicHealthServices.First(x => x.HealthServiceId == service.Id);

                                    if (pcHealthService.UsualSchedulePlans != null)
                                    {
                                        _dbContext.UsualSchedulePlans.RemoveRange(pcHealthService.UsualSchedulePlans);
                                    }

                                    var query = _dbContext.Appointments.Where(x => x.ShiftCenterServiceId == pcHealthService.Id);

                                    var pendings = query.Where(x => x.Status == AppointmentStatus.Pending).ToList();

                                    if (pendings.Count == 0)
                                    {
                                        var appoints = query.ToList();

                                        foreach (var item in appoints)
                                        {
                                            _dbContext.PoliclinicMessages.RemoveRange(item.ShiftCenterMessages.ToList());
                                        }
                                        _dbContext.Appointments.RemoveRange(appoints);
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", Messages.HealthServiceHasPendingTurn);

                                        throw new Exception("Pending Appointments");
                                    }
                                    _dbContext.CenterServices.Remove(pcHealthService);
                                }
                            }

                            await _dbContext.SaveChangesAsync();

                            transaction.Commit();

                            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ActionDoneSuccesfully });
                        }
                    });

                    if (LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER)
                    {
                        return RedirectToAction("Index", "Home", new { area = "PolyClinicManager" });
                    }
                    else if (LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
                    {
                        return RedirectToAction("Index", "Home", new { area = "BeautyCenterManager" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Polyclinic", new { area = "" });
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("PoliClinicName", Messages.ErrorOccuredWhileDoneAction);
            }
            return View(model);
        }
        #endregion

        #region Setting Doctors
        [HttpGet]
        [Authorize(Roles = "admin,polyclinicmanager,doctor,secretary,beautycentermanager")]
        public async Task<IActionResult> SettingDoctor(int? polyclinicId)
        {
            var polyclinic = GetPolyclinic(polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.ItemNotFound);

            var doctors = await GetDoctorsAsync();

            ViewBag.Lang = Lng;

            TempData["area"] = LoginAs.ToString();

            ViewData["poliClinicName"] = Lng == Lang.KU ? polyclinic.Name_Ku : polyclinic.Name_Ar;

            var model = new SettingDoctorViewModel
            {
                ListDoctors = doctors,
                ListReservationStartPoints = _commonUtils.PopulateReservationRangeStartPoints(),
                ListReservationEndPoints = _commonUtils.PopulateReservationRangeEndPoints(),
                PolyclinicId = polyclinic.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignNewDoctor(SettingDoctorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var polyclinic = GetPolyclinic(model.PolyclinicId);

                    //Check if doctor doesn't added before?
                    var poliClinic = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == polyclinic.Id);

                    var founded = poliClinic.ServiceSupplies.FirstOrDefault(x => x.PersonId == model.UserDoctorId) != null;

                    if (!founded)
                    {
                        //محدوده شروع نوبت دهی
                        var reservationStartPoint = model.StartPoint;
                        if (reservationStartPoint == 1)
                        {
                            var startPointNumber = model.StartPointNumber;
                            var startPointUnit = model.StartPointUnit;

                            switch (startPointUnit)
                            {
                                case 1: //Hour
                                    reservationStartPoint = startPointNumber * 60; // Minutes
                                    break;
                                case 2: //Day
                                    reservationStartPoint = startPointNumber * 24 * 60; //Minutes
                                    break;
                            }
                        }
                        //محدوده پایان نوبت دهی
                        var reservationEndPoint = model.EndPoint;
                        if (reservationEndPoint == 1)
                        {
                            var endPointNumber = model.EndPointNumber;
                            var endPointUnit = model.EndPointUnit;

                            switch (endPointUnit)
                            {
                                case 1: //Hour
                                    reservationEndPoint = endPointNumber * 60; // Minutes
                                    break;
                                case 2: //Day
                                    reservationEndPoint = endPointNumber * 24 * 60; //Minutes
                                    break;
                            }
                        }

                        var strategy = _dbContext.Database.CreateExecutionStrategy();
                        await strategy.ExecuteAsync(async () =>
                        {
                            using (var transaction = _dbContext.Database.BeginTransaction())
                            {
                                var serviceSupply = new ServiceSupply
                                {
                                    Duration = 5,
                                    ShiftCenterId = model.PolyclinicId,
                                    ReservationType = model.ReservationType,
                                    PersonId = model.UserDoctorId,
                                    OnlineReservationPercent = model.OnlineReservationPercent,
                                    IsAvailable = false,
                                    StartReservationDate = DateTime.Parse(model.StartReservationDate),
                                    VisitPrice = 0,
                                    PrePaymentPercent = 0,
                                    PaymentType = PaymentType.Free,
                                    ReservationRangeStartPoint = reservationStartPoint,
                                    ReservationRangeEndPointPosition = (Position)model.EndPointPosition,
                                    ReservationRangeEndPointDiffMinutes = reservationEndPoint,
                                    RankScore = 0,
                                    CreatedAt = DateTime.Now,
                                    Notification = "",
                                    Notification_Ar = "",
                                    Notification_Ku = "",
                                    PrescriptionPath = ""
                                };

                                _dbContext.ServiceSupplies.Add(serviceSupply);

                                await _dbContext.SaveChangesAsync();

                                await _dbContext.ServiceSupplyInfo.AddAsync(new ServiceSupplyInfo
                                {
                                    ServiceSupplyId = serviceSupply.Id,
                                    MedicalCouncilNumber = model.MedicalCouncilNumber,
                                    AcceptionDate = DateTime.Now,
                                    Bio = model.Bio ?? "",
                                    Bio_Ar = model.Bio_Ar ?? "",
                                    Bio_Ku = model.Bio_Ku ?? "",
                                    Website = "",
                                    Description = "#Requested",
                                    Description_Ar = "#Requested",
                                    Description_Ku = "#Requested",
                                    Picture = "",
                                    IsDeleted = false,
                                    WorkExperience = 0,
                                    CreatedAt = DateTime.Now,
                                    Phone = model.Phone ?? ""
                                });

                                await _dbContext.SaveChangesAsync();

                                var destinationDirPath = $"wwwroot\\uploaded\\prescriptions\\shiftcenters\\{poliClinic.Id}\\{serviceSupply.Id}";

                                var fullDestinationDirPath = Path.Combine(_hostingEnvironment.ContentRootPath, destinationDirPath);

                                if (!Directory.Exists(fullDestinationDirPath))
                                {
                                    Directory.CreateDirectory(fullDestinationDirPath);
                                }

                                _dbContext.Entry(serviceSupply).State = EntityState.Modified;

                                serviceSupply.PrescriptionPath = Path.Combine(destinationDirPath, $"prescript_{serviceSupply.Id}.mrt");

                                await _dbContext.SaveChangesAsync();

                                var destinationPrescriptPath = Path.Combine(_hostingEnvironment.ContentRootPath, serviceSupply.PrescriptionPath);
                                try
                                {
                                    System.IO.File.Copy(BasePrescriptFullPath, destinationPrescriptPath, true);
                                }
                                catch
                                {
                                    throw new AwroNoreException("Can not copy prescription file. please try again");
                                }


                                transaction.Commit();
                            }
                        });


                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemAddedSuccessFully });
                    }
                    else
                    {
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.DoctorAssignedToPolyclinicAlready });
                        ModelState.AddModelError("", Messages.DoctorAssignedToPolyclinicAlready);
                    }

                }
            }
            catch (Exception ex)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = $"{Messages.ErrorOccuredWhileDoneAction} " + ex.Message });
                ModelState.AddModelError("", $"{Messages.ErrorOccuredWhileDoneAction} " + ex.Message);
            }

            return RedirectToAction("SettingDoctor", "Polyclinic", new { area = "", polyclinicId = model.PolyclinicId });
        }

        [HttpGet]
        public IActionResult EditPolyclinicDoctor(int? serviceSupplyId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId.Value)) throw new AccessDeniedException();
            }

            var serviceSupply = GetServiceSupply(serviceSupplyId);

            if (serviceSupply == null) throw new Exception(Messages.ItemNotFound);

            ViewBag.Lang = Lng;

            ViewBag.PolyclinicName = Lng == Lang.KU ? serviceSupply.ShiftCenter.Name_Ku : serviceSupply.ShiftCenter.Name_Ar;

            ViewBag.PolyclinicDoctorName = serviceSupply.Person.FullName;

            var startPoint = serviceSupply.ReservationRangeStartPoint;

            var endPoint = serviceSupply.ReservationRangeEndPointDiffMinutes;

            if (startPoint > 1) startPoint = 1;

            if (endPoint > 1) endPoint = 1;

            var model = new EditServiceSupplyViewModel
            {
                OnlineReservationPercent = serviceSupply.OnlineReservationPercent,
                PolyclinicId = serviceSupply.ShiftCenterId,
                ReservationType = serviceSupply.ReservationType,
                ServiceSupplyId = serviceSupply.Id,
                StartReservationDate = serviceSupply.StartReservationDate.ToShortDateString(),
                UserDoctorId = serviceSupply.PersonId,
                StartPoint = startPoint,
                StartPointNumber = serviceSupply.ReservationRangeStartPoint / 60,
                StartPointUnit = 1,
                EndPoint = endPoint,
                EndPointNumber = serviceSupply.ReservationRangeEndPointDiffMinutes / 60,
                EndPointPosition = (int)serviceSupply.ReservationRangeEndPointPosition,
                EndPointUnit = 1,
                ListReservationStartPoints = _commonUtils.PopulateReservationRangeStartPoints(),
                ListReservationEndPoints = _commonUtils.PopulateReservationRangeEndPoints(),
                Bio = serviceSupply.ServiceSupplyInfo?.Bio,
                Bio_Ku = serviceSupply.ServiceSupplyInfo?.Bio_Ku,
                Bio_Ar = serviceSupply.ServiceSupplyInfo?.Bio_Ar,
                Phone = serviceSupply.ServiceSupplyInfo?.Phone,
                MedicalCouncilNumber = serviceSupply.ServiceSupplyInfo?.MedicalCouncilNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPolyclinicDoctor(EditServiceSupplyViewModel model)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(model.ServiceSupplyId)) throw new AccessDeniedException();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    //محدوده شروع نوبت دهی
                    var reservationStartPoint = model.StartPoint;
                    if (reservationStartPoint == 1)
                    {
                        var startPointNumber = model.StartPointNumber;
                        var startPointUnit = model.StartPointUnit;

                        switch (startPointUnit)
                        {
                            case 1: //Hour
                                reservationStartPoint = startPointNumber * 60; // Minutes
                                break;
                            case 2: //Day
                                reservationStartPoint = startPointNumber * 24 * 60; //Minutes
                                break;
                        }
                    }
                    //محدوده پایان نوبت دهی
                    var reservationEndPoint = model.EndPoint;
                    if (reservationEndPoint == 1)
                    {
                        var endPointNumber = model.EndPointNumber;
                        var endPointUnit = model.EndPointUnit;

                        switch (endPointUnit)
                        {
                            case 1: //Hour
                                reservationEndPoint = endPointNumber * 60; // Minutes
                                break;
                            case 2: //Day
                                reservationEndPoint = endPointNumber * 24 * 60; //Minutes
                                break;
                        }
                    }

                    var serviceSupply = GetServiceSupply(model.ServiceSupplyId);

                    if (serviceSupply == null) throw new Exception(Messages.ItemNotFound);

                    var _serviceSupply = await _dbContext.ServiceSupplies.FindAsync(serviceSupply.Id);

                    _dbContext.Entry(_serviceSupply).State = EntityState.Modified;

                    _serviceSupply.ReservationType = model.ReservationType;
                    _serviceSupply.OnlineReservationPercent = model.OnlineReservationPercent;
                    _serviceSupply.StartReservationDate = DateTime.Parse(model.StartReservationDate);
                    _serviceSupply.ReservationRangeStartPoint = reservationStartPoint;
                    _serviceSupply.ReservationRangeEndPointPosition = (Position)model.EndPointPosition;
                    _serviceSupply.ReservationRangeEndPointDiffMinutes = reservationEndPoint;
                    _serviceSupply.ServiceSupplyInfo.Bio = model.Bio;
                    _serviceSupply.ServiceSupplyInfo.Bio_Ku = model.Bio_Ku;
                    _serviceSupply.ServiceSupplyInfo.Bio_Ar = model.Bio_Ar;
                    _serviceSupply.ServiceSupplyInfo.Phone = model.Phone;
                    _serviceSupply.ServiceSupplyInfo.MedicalCouncilNumber = model.MedicalCouncilNumber;

                    if (string.IsNullOrEmpty(_serviceSupply.PrescriptionPath))
                    {
                        var destinationDirPath = $"wwwroot\\uploaded\\prescriptions\\shiftcenters\\{_serviceSupply.ShiftCenterId}\\{_serviceSupply.Id}";

                        var fullDestinationDirPath = Path.Combine(_hostingEnvironment.ContentRootPath, destinationDirPath);

                        if (!Directory.Exists(fullDestinationDirPath))
                        {
                            Directory.CreateDirectory(fullDestinationDirPath);
                        }

                        _serviceSupply.PrescriptionPath = Path.Combine(destinationDirPath, $"prescript_{_serviceSupply.Id}.mrt");

                        var destinationPrescriptPath = Path.Combine(_hostingEnvironment.ContentRootPath, _serviceSupply.PrescriptionPath);
                        try
                        {
                            System.IO.File.Copy(BasePrescriptFullPath, destinationPrescriptPath, true);
                        }
                        catch
                        {
                            throw new AwroNoreException("Can not copy prescription file. please try again");
                        }
                    }

                    _dbContext.SaveChanges();

                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ActionDoneSuccesfully });

                    return RedirectToAction("SettingDoctor", "Polyclinic", new { area = "", polyclinicId = model.PolyclinicId });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePolyclinicDoctor(int? polyclinicId, int? serviceSupplyId)
        {
            if (polyclinicId == null || serviceSupplyId == null) throw new ArgumentNullException();

            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(serviceSupplyId.Value)) throw new AccessDeniedException();
            }

            var polyclinic = GetPolyclinic(polyclinicId);

            var poliClinic = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == polyclinic.Id);

            var ss = poliClinic.ServiceSupplies.SingleOrDefault(x => x.Id == serviceSupplyId);
            if (ss != null)
            {
                var foundedAppointments = ss.Appointments.Where(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now).Select(a => a.Id);
                if (foundedAppointments != null && foundedAppointments.ToList().Count >= 1)
                {
                    var doctorMessage = Messages.DoctorHasPendingTurns;
                    throw new Exception(doctorMessage);
                }
                // if doctor don't have any pending appointment
                else
                {
                    var activityLogs = await _dbContext.DoctorActivityLogs.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (activityLogs.Any())
                    {
                        _dbContext.DoctorActivityLogs.RemoveRange(activityLogs);
                    }

                    var schedules = await _dbContext.Schedules.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (schedules.Any())
                    {
                        _dbContext.Schedules.RemoveRange(schedules);
                    }

                    var usualSchedules = await _dbContext.UsualSchedulePlans.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (usualSchedules.Any())
                    {
                        _dbContext.UsualSchedulePlans.RemoveRange(usualSchedules);
                    }

                    var messages = from a in ss.Appointments
                                   join m in _dbContext.PoliclinicMessages
                                   on a.Id equals m.AppointmentId
                                   select m;
                    if (messages != null && messages.ToList().Count > 0)
                    {
                        _dbContext.PoliclinicMessages.RemoveRange(messages);
                    }

                    var offers = await _dbContext.Offers.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (offers.Any())
                    {
                        foreach (var offer in offers)
                        {
                            var offerAppointments = await _dbContext.Appointments.Where(x => x.OfferId == offer.Id).ToListAsync();

                            if (offerAppointments.Any())
                            {
                                _dbContext.Appointments.RemoveRange(offerAppointments);
                            }
                        }
                        _dbContext.Offers.RemoveRange(offers);
                    }

                    var serviceSupplyInfo = await _dbContext.ServiceSupplyInfo.FirstOrDefaultAsync(x => x.ServiceSupplyId == serviceSupplyId);
                    if (serviceSupplyInfo != null)
                    {
                        _dbContext.ServiceSupplyInfo.Remove(serviceSupplyInfo);
                    }

                    var treatmentHistories = await _dbContext.TreatmentHistories.Where(x => x.Patient.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (treatmentHistories.Any())
                    {
                        foreach (var treatmentHistory in treatmentHistories)
                        {
                            var pharmacyPrescriptions = await _dbContext.PharmacyPrescriptions.Where(x => x.TreatmentHistoryId == treatmentHistory.Id).ToListAsync();
                            if (pharmacyPrescriptions.Any())
                            {
                                foreach (var prescript in pharmacyPrescriptions)
                                {
                                    var doneItems = await _dbContext.PharmacyDoneTreatments.Where(x => x.PharmacyPrescriptionId == prescript.Id).ToListAsync();
                                    if (doneItems.Any())
                                    {
                                        _dbContext.PharmacyDoneTreatments.RemoveRange(doneItems);
                                    }
                                }
                                _dbContext.PharmacyPrescriptions.RemoveRange(pharmacyPrescriptions);
                            }
                        }
                        _dbContext.TreatmentHistories.RemoveRange(treatmentHistories);
                    }

                    var ratings = await _dbContext.ServiceSupplyRatings.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (ratings.Any())
                    {
                        _dbContext.ServiceSupplyRatings.RemoveRange(ratings);
                    }

                    var appointments = await _dbContext.Appointments.Where(x => x.ServiceSupplyId == serviceSupplyId).ToListAsync();
                    if (appointments.Any())
                    {
                        _dbContext.Appointments.RemoveRange(appointments);
                    }

                    //Remove supplied service by this user doctor
                    _dbContext.ServiceSupplies.Remove(ss);
                }
            }

            _dbContext.SaveChanges();

            return Json(new { success = true, message = "" });
        }

        [HttpGet]
        public IActionResult SericeSupplyDetails(int id)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(id)) throw new AccessDeniedException();
            }

            var serviceSupply = GetServiceSupply(id);

            if (serviceSupply == null) throw new EntityNotFoundException();

            var details = new ServiceSupplyDetailsModel
            {
                Name = serviceSupply.Person.FullName,
                Mobile = serviceSupply.Person.Mobile,
                //Email = serviceSupply.User.Email,
                Description = serviceSupply.Person.Description,
                Avatar = serviceSupply.Person.Avatar,
                StartReservationDate = serviceSupply.StartReservationDate.ToShortDateString(),
                VisitPrice = serviceSupply.VisitPrice,
                PrePaymentPercent = serviceSupply.PrePaymentPercent,
                PaymentType = serviceSupply.PaymentType.ToString()
            };

            return PartialView(details);
        }
        #endregion               
    }
}