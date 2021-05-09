using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Persons;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.Areas.ClinicManager.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AN.Web.AppCode.Extensions;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class UsersController : ClinicManagerController
    {
        #region Fields
        private static Logger logger;
        private readonly IPersonService _userService;
        private readonly IClinicService _clinicService;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public UsersController(IPersonService userService, IClinicService clinicService, BanobatDbContext dbContext) : base(clinicService)
        {
            _userService = userService;
            _clinicService = clinicService;
            logger = LogManager.GetCurrentClassLogger();
            _dbContext = dbContext;
        }
        #endregion

        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MobileSortParam = sortOrder == "Mobile" ? "mobile_desc" : "Mobile";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var users = from u in _userService.GetAllForClinic(CurrentClinic.Id)
                        select new CMListUsersViewModel
                        {
                            Id = u.Id,
                            Name = u.FirstName + " " + u.SecondName + " " + u.ThirdName,
                            //Email = u.Email,
                            Mobile = u.Mobile,
                        };

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u =>
                   u.Name.Contains(searchString) ||
                   u.Mobile.Contains(searchString) ||
                   u.Mobile.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(a => a.Name);
                    break;
                case "Mobile":
                    users = users.OrderBy(a => a.Mobile);
                    break;
                case "mobile_desc":
                    users = users.OrderByDescending(a => a.Mobile);
                    break;
                default:
                    users = users.OrderBy(a => a.Name);
                    break;
            }

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genders = MyEnumExtensions.EnumToSelectList<Gender>().ToList();

            return View(new CreateCMUsersViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCMUsersViewModel model)
        {
            try
            {
                string imagePath = string.Empty, newAvatarName = string.Empty;

                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null && model.ImageUpload.Length > 0)
                    {
                        var validImageTypes = new string[] { "image/jpeg", "image/pjpeg", "image/png" };

                        if (!validImageTypes.Contains(model.ImageUpload.ContentType))
                        {
                            ModelState.AddModelError("ImageUpload", Core.Resources.EntitiesResources.Messages.PleaseSelectPicWithSpecefiedFormat);
                            throw new Exception(Core.Resources.EntitiesResources.Messages.PleaseSelectPicWithSpecefiedFormat);
                        }

                        var uploadDir = "wwwroot\\Content\\images\\avatars";
                        var fileExt = Path.GetExtension(model.ImageUpload.FileName)?.Substring(1);
                        newAvatarName = "img_" + model.Mobile + "." + fileExt;
                        imagePath = Path.Combine(Directory.GetCurrentDirectory(), uploadDir, newAvatarName);
                    }

                    var existsMobile = _dbContext.Persons.Where(u => u.Mobile == model.Mobile).Count() >= 1;
                    if (existsMobile)
                    {
                        throw new Exception(Core.Resources.EntitiesResources.Messages.MobileNumberDuplicate);
                    }

                    //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
                    //var userManager = new UserManager<User>(new UserStore<User>(_dbContext));

                    var ClinicManagerRole = Shared.Enums.LoginAs.CLINICMANAGER.ToString();
                    var PolyClinicManagerRole = Shared.Enums.LoginAs.POLYCLINICMANAGER.ToString();
                    var DoctorRole = "";

                    var user = new Person
                    {
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        ThirdName = model.ThirdName,
                        Age = model.Age ?? 0,
                        Gender = model.Gender,
                        Mobile = model.Mobile,
                        ZipCode = model.ZipCode,
                        Address = model.Address,
                        Avatar = newAvatarName,
                        //Email = "aw" + model.Mobile + "@awronore.krd",
                        //UserName = model.Mobile,
                        //ParentId = HttpContext.User.Identity.GetUserId(),
                        CreatorRole = Shared.Enums.LoginAs.CLINICMANAGER,
                        CreationPlaceId = CurrentClinic.Id,
                        IsApproved = true,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now
                    };
                    #region Begin Transaction
                    using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            //Generate random password
                            var RandomPassword = "Ap@123456"; //System.Web.Security.Membership.GeneratePassword(8, 0);

                            _userService.InsertNewPerson(user);

                            //foreach (var role in model.Roles)
                            //{
                            //    switch (role)
                            //    {
                            //        case 2:
                            //            var assignClinicManagerRole = userManager.AddToRole(user.Id, ClinicManagerRole);
                            //            if (!assignClinicManagerRole.Succeeded)
                            //            {
                            //                throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                            //            }
                            //            break;
                            //        case 3:
                            //            var assignPolyClinicManagerRole = userManager.AddToRole(user.Id, PolyClinicManagerRole);
                            //            if (!assignPolyClinicManagerRole.Succeeded)
                            //            {
                            //                throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                            //            }
                            //            break;
                            //        case 4:
                            //            var assignDoctorRole = userManager.AddToRole(user.Id, DoctorRole);
                            //            if (!assignDoctorRole.Succeeded)
                            //            {
                            //                throw new Exception(Core.Resources.EntitiesResources.Messages.ErrorOccuredWhileAssignRole);
                            //            }
                            //            _dbContext.UserDoctorInfoes.Add(new UserDoctorInfo
                            //            {
                            //                UserDoctorId = user.Id,
                            //                MedicalCouncilNumber = model.DocotrMedicalCouncilNumber,
                            //                Picture = newAvatarName,
                            //                CreatedAt = DateTime.Now
                            //            });

                            //            break;
                            //    }
                            //}

                            _dbContext.ClinicPersons.Add(new ClinicPersons
                            {
                                Clinic_Id = CurrentClinic.Id,
                                PersonId = user.Id,
                                IsManager = false,
                                CreatedAt = DateTime.Now
                            });

                            if (CurrentClinic != null && !CurrentClinic.IsIndependent)
                            {
                                _dbContext.HospitalPersons.Add(new HospitalPersons
                                {
                                    HospitalId = (int)CurrentClinic.HospitalId,
                                    PersonId = user.Id,
                                    IsManager = false,
                                    CreatedAt = DateTime.Now
                                });
                            }
                            _dbContext.SaveChanges();
                            if (!imagePath.Equals(string.Empty) && imagePath != null)
                            {
                                using (var stream = new FileStream(imagePath, FileMode.Create))
                                {
                                    model.ImageUpload.CopyTo(stream);
                                }
                            }
                            transaction.Commit();
                            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully });
                            return RedirectToAction("Index", "Users", new { area = "ClinicManager" });
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);
                            transaction.Rollback();
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Genders = MyEnumExtensions.EnumToSelectList<Gender>().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {            
            try
            {
                //در اینجا برای رعایت نکان امنیتی باید مشخص شود که یوزر جاری کدام یوزرها را می تواند حذف کند
                // و یوزر مورد حذف از میان همان ها پیدا شود
                //در این جا چون کاربر نقش مدیر سیستم را دارد از میان همه یوزرهای موجود در بانک یوزر موردنظر یافت می شود
                var user = _dbContext.Persons.SingleOrDefault(x => x.Id == id && x.CreatorRole == Shared.Enums.LoginAs.CLINICMANAGER && x.CreationPlaceId == CurrentClinic.Id);

                if (user == null) throw new EntityNotFoundException();

                //کاربر جاری نمیتواند خودش را حذف کند
                //if (user.Id == HttpContext.User.Identity.GetUserId())
                //{
                //    throw new DeleteCurrentUserException();
                //}

                using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        //foreach (var role in user.Roles)
                        //{
                        //    var _roleName = _userService.GetRoleNameById(role.RoleId);
                        //    switch (_roleName)
                        //    {
                        //        #region Check Admin Role
                        //        case Shared.Enums.LoginAs.ADMIN:
                        //            //کاربر جاری می تواند ادمین هایی که خودش ایجاد کرده را حذف کند                                  
                        //            if (user.ParentId != HttpContext.User.Identity.GetUserId())
                        //            {
                        //                throw new Exception(Core.Resources.EntitiesResources.Messages.UserIsAdminCanotDelIt);
                        //            }
                        //            break;
                        //        #endregion

                        //        #region Check HospitalManager Role
                        //        case Shared.Enums.LoginAs.HOSPITALMANAGER:
                        //            //Check if this user has any hospital to manage or not?
                        //            var foundedHospitals = user.HospitalUsers.Where(hu => hu.IsManager == true).Select(hu => hu.Hospital).Distinct().ToList();
                        //            if (foundedHospitals != null && foundedHospitals.Count >= 1)
                        //            {
                        //                var hNames = string.Empty;
                        //                foreach (var item in foundedHospitals)
                        //                {
                        //                    hNames += " " + (Lng == Core.Enums.Lang.KU ? item.Name_Ku : item.Name_Ar);
                        //                }
                        //                var hospitalManagerMessage = Core.Resources.EntitiesResources.Messages.UserIsManagingCentersPleaseUnassignFirst;
                        //                throw new Exception(hospitalManagerMessage);
                        //            }
                        //            break;
                        //        #endregion

                        //        #region Check ClinicManager Role
                        //        case Shared.Enums.LoginAs.CLINICMANAGER:
                        //            //کاربر جاری می تواند مدیرمطب هایی که خودش ایجاد کرده را حذف کند                                  
                        //            if (user.ParentId != HttpContext.User.Identity.GetUserId())
                        //            {
                        //                throw new Exception(Core.Resources.EntitiesResources.Messages.UserIsPolyclinicManagerCannotDelIt);
                        //            }
                        //            //Check if this user has any clinic to manage or not?
                        //            var foundedClinics = user.ClinicUsers.Where(cu => cu.IsManager == true).Select(cu => cu.Clinic).Distinct().ToList();
                        //            if (foundedClinics != null && foundedClinics.Count >= 1)
                        //            {
                        //                var cNames = string.Empty;
                        //                foreach (var item in foundedClinics)
                        //                {
                        //                    cNames += " " + (Lng == Core.Enums.Lang.KU ? item.Name_Ku : item.Name_Ar);
                        //                }
                        //                var clinicManagerMessage = Core.Resources.EntitiesResources.Messages.UserIsManagingCentersPleaseUnassignFirst;
                        //                throw new Exception(clinicManagerMessage);
                        //            }
                        //            break;
                        //        #endregion

                        //        #region PolyClinicManager Role
                        //        case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                        //            //Check if this user has any policlinic to manage or not?
                        //            var foundedPoliClinics = user.PoliClinicUsers.Where(pcu => pcu.IsManager == true).Select(pcu => pcu.PoliClinic).Distinct().ToList();
                        //            if (foundedPoliClinics != null && foundedPoliClinics.Count >= 1)
                        //            {
                        //                var pcNames = string.Empty;
                        //                foreach (var item in foundedPoliClinics)
                        //                {
                        //                    pcNames += " " + (Lng == Core.Enums.Lang.KU ? item.Name_Ku : item.Name_Ar);
                        //                }
                        //                var PolyClinicManagerMessage = Core.Resources.EntitiesResources.Messages.UserIsManagingCentersPleaseUnassignFirst;
                        //                throw new Exception(PolyClinicManagerMessage);
                        //            }
                        //            break;
                        //        #endregion

                        //        #region Check Doctor Role
                        //        case UsersRoleName.Doctor:
                        //            var suppliedServices = user.ServiceSupplies.Distinct().ToList();
                        //            if (suppliedServices != null && suppliedServices.Count >= 1)
                        //            {
                        //                //:: check that if this doctor have pending appointments
                        //                var pendingAppointments = new List<long>();
                        //                foreach (var serviceSupply in suppliedServices)
                        //                {
                        //                    var foundedAppointments = serviceSupply.Appointments.Where(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now).Select(a => a.Id);
                        //                    foreach (var appoint in foundedAppointments)
                        //                    {
                        //                        pendingAppointments.Add(appoint);
                        //                    }
                        //                }
                        //                if (pendingAppointments != null && pendingAppointments.Count >= 1)
                        //                {
                        //                    var doctorMessage = Core.Resources.EntitiesResources.Messages.DoctorHasPendingTurns;
                        //                    throw new Exception(doctorMessage);
                        //                }
                        //                // if doctor don't have any pending appointment
                        //                else
                        //                {
                        //                    //Remove supplied services by this user doctor
                        //                    _dbContext.ServiceSupplies.RemoveRange(suppliedServices);
                        //                    //چون رابطه آبشاری برای حذف تنظیم شده است با حذف هر ارایه نوبت ها و زمانبندی های وی نیز حذف خواهند شد
                        //                }
                        //            }

                        //            //مقادیر درون جدول اطلاعات دکتر باید حذف شوند
                        //            if (user.UserDoctorInfo != null)
                        //            {
                        //                // ابتدا حذف تخصص ها به خاطر جلوگیری از خطای کانفلیکت                                                
                        //                _dbContext.DoctorExpertises.RemoveRange(_dbContext.DoctorExpertises.Where(dc => dc.UserDoctorId == user.Id));

                        //                var _userDoctorInfo = _dbContext.UserDoctorInfoes.Find(user.Id);
                        //                _dbContext.UserDoctorInfoes.Remove(_userDoctorInfo);
                        //            }
                        //            break;
                        //        #endregion

                        //        #region Patient Role
                        //        case UsersRoleName.Patient:
                        //            //:: check that if this patient have pending appointments
                        //            var patientPendingAppointments = user.Appointments.Where(a => a.Status == AppointmentStatus.Pending && a.Start_DateTime >= DateTime.Now).Distinct().ToList();

                        //            if (patientPendingAppointments != null && patientPendingAppointments.Count >= 1)
                        //            {
                        //                var patientMessage = Core.Resources.EntitiesResources.Messages.PatientHasPendingTurns;
                        //                throw new Exception(patientMessage);
                        //            }
                        //            // if patient don't have any pending appointment
                        //            else
                        //            {
                        //                _dbContext.Appointments.RemoveRange(user.Appointments);
                        //            }

                        //            //مقادیر درون جدول اطلاعات بیمار باید حذف شوند
                        //            if (user.UserPatientInfo != null)
                        //            {
                        //                // ابتدا حذف بیمه ها به خاطر جلوگیری از خطای کانفلیکت                                                
                        //                _dbContext.PatientInsurances.RemoveRange(_dbContext.PatientInsurances.Where(pi => pi.UserPatientId == user.Id));

                        //                var _userPatientInfo = _dbContext.UserPatientInfoes.Find(user.Id);
                        //                _dbContext.UserPatientInfoes.Remove(_userPatientInfo);
                        //            }
                        //            break;
                        //            #endregion
                        //    }
                        //}

                        if (!string.IsNullOrEmpty(user.Avatar) && !user.Avatar.Equals("NoAvatar.jpg") && !user.Avatar.Equals("NoAvatar_Female.jpg"))
                        {
                            var avatarPath = Path.Combine(Directory.GetCurrentDirectory(), "~/css/images/avatars/" + user.Avatar);
                            if (System.IO.File.Exists(avatarPath))
                            {
                                System.IO.File.Delete(avatarPath);
                            }
                        }

                        _dbContext.Persons.Remove(user);
                        _dbContext.SaveChanges();
                        transaction.Commit();

                        logger.Info("user with mobile " + user.Mobile + " and name " + user.FullName + " deleted by " + HttpContext.User.Identity.Name);
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });

                        //بازگشت به آدرسی که امده ایم
                        return Redirect(Request.Headers["Referer"].ToString());
                        //return RedirectToAction("List", "Users", new { area = "Admin" });
                    }
                    catch (Exception ex)
                    {
                        TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = ex.Message });
                        transaction.Rollback();
                    }
                }
                return Redirect(Request.Headers["Referer"].ToString());
                //return RedirectToAction("List", "Users", new { area = "Admin" });
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Core.Resources.EntitiesResources.Messages.AnErrorOccuredWhileDeleteItem });
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult GetUserDetails(int userId)
        {
            if (userId == null)
            {
                return Json(new { Error = "Bad Request" });
            }
            try
            {
                var user = _userService.GetAllForClinic(CurrentClinic.Id).SingleOrDefault(x => x.Id == userId);
                if (user == null)
                {
                    return Json(new { Error = "Bad Request" });
                }
                var details = new
                {
                    Name = user.FullName,
                    user.Age,
                    user.Mobile,
                    //user.Email,
                    user.Description,
                    //Roles = user.Roles.Select(r => _userService.GetPersianRoleNameById(r.RoleId) + " - ").ToList(),
                    user.Avatar
                };

                return Json(details); ;
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult CheckMobile(string mobile)
        {
            try
            {
                var existsMobile = _dbContext.Persons.FirstOrDefault(x => x.Mobile == mobile) != null;
                if (existsMobile)
                {
                    throw new Exception(Core.Resources.EntitiesResources.Messages.MobileNumberDuplicate);
                }

                return Json(new { Result = "1", Message = Core.Resources.EntitiesResources.Messages.MobileIsNotValid });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", Message = ex.Message });
            }
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult AddExistingUserToClinic(string mobile)
        {
            try
            {
                var user = _dbContext.Persons.FirstOrDefault(x => x.Mobile == mobile);
                if (user == null)
                    throw new Exception(Core.Resources.EntitiesResources.Messages.ItemNotFound);

                var isExistInClinic = (from c in _dbContext.ClinicPersons
                                       where c.Clinic_Id == CurrentClinic.Id && c.PersonId == user.Id
                                       select c).FirstOrDefault() != null;
                if (!isExistInClinic)
                {
                    _dbContext.ClinicPersons.Add(new ClinicPersons
                    {
                        Clinic_Id = CurrentClinic.Id,
                        PersonId = user.Id,
                        IsManager = false,
                        CreatedAt = DateTime.Now
                    });
                    if (CurrentClinic != null && !CurrentClinic.IsIndependent)
                    {
                        var isExistInHospital = (from c in _dbContext.HospitalPersons
                                                 where c.HospitalId == CurrentClinic.HospitalId && c.PersonId == user.Id
                                                 select c).FirstOrDefault() != null;

                        if (!isExistInHospital)
                        {
                            _dbContext.HospitalPersons.Add(new HospitalPersons
                            {
                                HospitalId = (int)CurrentClinic.HospitalId,
                                PersonId = user.Id,
                                IsManager = false,
                                CreatedAt = DateTime.Now
                            });
                        }
                    }
                    _dbContext.SaveChanges();
                }

                return Json(new { Result = "1", Message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }
    }
}