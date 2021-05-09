using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Persons;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.DAL;
using AN.Web.Areas.HospitalManager.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using AN.Web.AppCode.Extensions;

namespace AN.Web.Areas.HospitalManager.Controllers
{
    public class UsersController : HospitalManagerController
    {
        private readonly IHospitalService _hospitalService;
        private readonly IPersonService _userService;
        private readonly BanobatDbContext _dbContext;
        public UsersController(IHospitalService hospitalService, IPersonService userService, BanobatDbContext dbContext) : base(hospitalService)
        {
            _hospitalService = hospitalService;
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int? page, string searchString)
        {
            var pageIndex = (page ?? 1) - 1;
            var pageSize = 10;
            int totalUsersCount;
            ///برای کارایی بیشتر به این خطی که غیرفعال شده توجه و بیه اینصورت پیاده شود
            //var users = userRepo.GetAllAsync(pageIndex, pageSize, out totalUsersCount).Select(u => new { id = u.Id, Name = u.Name, Family = u.Family, Mobile = u.Mobile, Mobile = u.Mobile, Email = u.Email,Roles=u.Roles });            

            var usersPerPage = new List<Person>();
            if (!string.IsNullOrEmpty(searchString))
            {
                usersPerPage = _userService.GetAllForHospital(CurrentHospital.Id, pageIndex, pageSize, out totalUsersCount, searchString)
                .Where(x => x.IsApproved == true && x.IsDeleted == false).ToList();
            }
            else
            {
                usersPerPage = _userService.GetAllForHospital(CurrentHospital.Id, pageIndex, pageSize, out totalUsersCount)
                .Where(x => x.IsApproved == true && x.IsDeleted == false).ToList();
            }

            var result = usersPerPage.ConvertAll(item => new HMListUsersViewModel
            {
                Id = item.Id,
                Name = item.FirstName + " " + item.SecondName + " " + item.ThirdName,
                Mobile = item.Mobile,
                //Email = item.Email,
                //Mobile = item.Mobile,
                //UserRoles = item.Roles.ToList(),
                //Expertises = item.UserDoctorInfo != null ? item.UserDoctorInfo.DoctorExpertises.Select(x => x.Expertise.Name_Ku).ToList() : null
            });

            ViewBag.Users = new StaticPagedList<HMListUsersViewModel>(result, pageIndex + 1, pageSize, totalUsersCount);

            return View();
        }

        [HttpGet]
        public IActionResult List(string R)
        {
            var curretHospitalUsers = _userService.GetAllForHospital(CurrentHospital.Id);

            var counts = new HMUsersCountModel
            {
                AllCount = curretHospitalUsers.Count(),
                //ClinicManagersCount = curretHospitalUsers.Count(x => _userService.IsHaveRole(x.Id, Shared.Enums.LoginAs.CLINICMANAGER.ToString())),
                PolyClinicManagersCount = 0,
                //DoctorsCount = curretHospitalUsers.Count(x => _userService.IsHaveRole(x.Id, UsersRoleName.Doctor.ToString())),
                //PatientsCount = curretHospitalUsers.Count(x => _userService.IsHaveRole(x.Id, UsersRoleName.Patient.ToString())),
            };

            ViewData["UsersCount"] = counts;

            var role = Shared.Enums.LoginAs.UNKNOWN;
            switch (R)
            {
                case "CM":
                    role = Shared.Enums.LoginAs.CLINICMANAGER;
                    break;
                case "PCM":
                    role = Shared.Enums.LoginAs.POLYCLINICMANAGER;
                    break;               
            }

            var _users = (from u in curretHospitalUsers
                              //where _userService.IsHaveRole(u.Id, role.ToString())
                          select new HMListUsersViewModel
                          {
                              Id = u.Id,
                              Name = u.FirstName + " " + u.SecondName + " " + u.ThirdName,
                              Mobile = u.Mobile,
                              //Email = u.Email,
                              //UserRoles = u.Roles.ToList()
                          });

            return View(_users);
        }

        [HttpGet]
        public IActionResult ListDoctors(int? CID, int? PCID)
        {
            if (CID == null || PCID == null) throw new ArgumentNullException();

            var clinic = CurrentHospital.Clinics.Where(c => c.Id == CID).FirstOrDefault();

            if (clinic == null) throw new EntityNotFoundException();

            var poliClinic = clinic.ShiftCenters.Where(pc => pc.Id == PCID).FirstOrDefault();

            if (poliClinic == null) throw new Exception(AN.Core.Resources.EntitiesResources.Messages.PolyclinicNotFound);

            var poliClinicDoctors = from u in poliClinic.ServiceSupplies select u.Person;

            var _doctors = (from u in poliClinicDoctors
                                //where _userService.IsHaveRole(u.Id, UsersRoleName.Doctor.ToString())
                            select new HMListDoctorsViewModel
                            {
                                Id = u.Id,
                                Name = u.FirstName + " " + u.SecondName + " " + u.ThirdName,
                                Mobile = u.Mobile,
                                //Email = u.Email,
                                ScientificCategory = "Temp",
                                //MedicalCouncilNumber = u.UserDoctorInfo.MedicalCouncilNumber,
                                //UserRoles = u.Roles.ToList(),
                                Duration = u.ServiceSupplies.Where(uss => uss.ShiftCenterId == poliClinic.Id).FirstOrDefault().Duration,
                                ReservationType = u.ServiceSupplies.FirstOrDefault(uss => uss.ShiftCenterId == poliClinic.Id).ReservationType.ToString(),
                                ServiceSupplyId = u.ServiceSupplies.Where(uss => uss.ShiftCenterId == poliClinic.Id).FirstOrDefault().Id,
                                OnlineReservationPercent = u.ServiceSupplies.Where(uss => uss.ShiftCenterId == poliClinic.Id).FirstOrDefault().OnlineReservationPercent
                            });

            ViewData["ClinicName"] = Lng == Core.Enums.Lang.KU ? clinic.Name_Ku : clinic.Name_Ar;

            ViewData["PoliClinicName"] = Lng == Core.Enums.Lang.KU ? poliClinic.Name_Ku : poliClinic.Name_Ar;

            return View(_doctors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var model = new CreateUsersViewModel { listExpertises = PopulateExpertisesList() };
            return View(new HMCreateUsersViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HMCreateUsersViewModel model)
        {
            try
            {

                string imagePath = string.Empty, newAvatarName = string.Empty;

                if (ModelState.IsValid)
                {

                    //if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
                    //{
                    //    ModelState.AddModelError("ImageUpload", "عکس الزامی می باشد");
                    //    throw new Exception("عکس الزامی می باشد");
                    //}

                    if (model.ImageUpload != null && model.ImageUpload.Length > 0)
                    {
                        var validImageTypes = new string[] { "image/jpeg", "image/pjpeg", "image/png" };

                        if (!validImageTypes.Contains(model.ImageUpload.ContentType))
                        {
                            ModelState.AddModelError("ImageUpload", "لطفا عکس با فرمت مناسب را انتخاب نمایید");
                            throw new Exception("لطفا عکس با فرمت مناسب را انتخاب نمایید");
                        }

                        var uploadDir = "~/css/images/avatars";
                        var fileExt = Path.GetExtension(model.ImageUpload.FileName)?.Substring(1);
                        newAvatarName = "img_" + model.Mobile + "." + fileExt;
                        imagePath = Path.Combine(Directory.GetCurrentDirectory(), uploadDir, newAvatarName);
                    }

                    var existsMobile = _dbContext.Persons.Where(u => u.Mobile.Trim() == model.Mobile.Trim()).ToList().Count;
                    if (existsMobile >= 1)
                    {
                        throw new Exception("شماره ملی تکراری می باشد و قبلا کاربری با این شماره ملی در سیستم ثبت شده است");
                    }

                    //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    //var userManager = new UserManager<User>(new UserStore<User>(context));

                    var HospitalManagerRole = Shared.Enums.LoginAs.HOSPITALMANAGER.ToString();
                    var ClinicManagerRole = Shared.Enums.LoginAs.CLINICMANAGER.ToString();
                    var PolyClinicManagerRole = Shared.Enums.LoginAs.POLYCLINICMANAGER.ToString();
                    var DoctorRole = "";

                    var user = new Person
                    {
                        FirstName = model.Name,
                        Age = model.Age ?? 0,
                        Gender = model.Gender,
                        //Mobile = model.Mobile,
                        Mobile = model.Mobile,
                        ZipCode = model.ZipCode,
                        Address = model.Address,
                        Avatar = newAvatarName,
                        //Email = model.Email,
                        //UserName = model.Email,
                        //ParentId = HttpContext.User.Identity.GetUserId(),
                        CreatorRole = Shared.Enums.LoginAs.HOSPITALMANAGER,
                        CreationPlaceId = CurrentHospital.Id,
                        IsApproved = true,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now
                    };
                    #region Begin Transaction
                    using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            _userService.InsertNewPerson(user);

                            //foreach (var role in model.Roles)
                            //{
                            //    switch (role)
                            //    {
                            //        case 2:
                            //            var assignClinicManagerRole = userManager.AddToRole(user.Id, ClinicManagerRole);
                            //            if (!assignClinicManagerRole.Succeeded)
                            //            {
                            //                throw new Exception("اختصاص نقش مدیر کلینیک با خطا مواجه شده است");
                            //            }
                            //            break;
                            //        case 3:
                            //            var assignPolyClinicManagerRole = userManager.AddToRole(user.Id, PolyClinicManagerRole);
                            //            if (!assignPolyClinicManagerRole.Succeeded)
                            //            {
                            //                throw new Exception("اختصاص نقش مدیر مطب با خطا مواجه شده است");
                            //            }
                            //            break;
                            //        case 4:
                            //            var assignDoctorRole = userManager.AddToRole(user.Id, DoctorRole);
                            //            if (!assignDoctorRole.Succeeded)
                            //            {
                            //                throw new Exception("اختصاص نقش دکتر با خطا مواجه شده است");
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

                            _dbContext.HospitalPersons.Add(new HospitalPersons
                            {
                                HospitalId = CurrentHospital.Id,
                                PersonId = user.Id,
                                IsManager = false,
                                CreatedAt = DateTime.Now
                            });

                            _dbContext.SaveChanges();
                            if (!imagePath.Equals(string.Empty) && imagePath != null)
                            {
                                using (var stream = new FileStream(imagePath, FileMode.Create))
                                {
                                    model.ImageUpload.CopyTo(stream);
                                }
                            }
                            transaction.Commit();
                            TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = "کاربر موردنظر با موفقیت افزوده شد" });
                            return RedirectToAction("Index", "Users", new { area = "HospitalManager" });
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("AddUser", ex.Message);
                            transaction.Rollback();
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.Message);
            }
            //model.listExpertises = PopulateExpertisesList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AssignToClinic(int id)
        {           
            try
            {
                var hospitalUsers = _userService.GetAllForHospital(CurrentHospital.Id).ToList();
                var user = hospitalUsers.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    throw new EntityNotFoundException("User Not Found");
                }

                var CurrentClinics = user.ClinicPersons.Where(x => x.Clinic.HospitalId == CurrentHospital.Id).Select(x => new { Id = x.Clinic.Id, Name = x.Clinic.Name_Ku });

                var allClinics = CurrentHospital.Clinics.Select(x => new { Id = x.Id, Name = x.Name_Ku });

                var clinicsResult = new List<HMSelectAssignUserToClinicViewModel>();

                foreach (var item in allClinics)
                {
                    if (CurrentClinics.Contains(item))
                    {
                        clinicsResult.Add(new HMSelectAssignUserToClinicViewModel
                        {
                            Selected = true,
                            Id = item.Id,
                            Name = item.Name,
                        });
                    }
                    else
                    {
                        clinicsResult.Add(new HMSelectAssignUserToClinicViewModel
                        {
                            Selected = false,
                            Id = item.Id,
                            Name = item.Name,
                        });
                    }
                }

                return View(new HMAssignUserToClinicViewModel
                {
                    UserId = user.Id,
                    UserFullName = user.FullName,
                    Clinics = clinicsResult
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignToClinic(HMAssignUserToClinicViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hospitalUsers = _userService.GetAllForHospital(CurrentHospital.Id).ToList();
                    var tmpUser = hospitalUsers.FirstOrDefault(x => x.Id == model.UserId);

                    using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            var user = _dbContext.Persons.Find(tmpUser.Id);

                            var currentClinics = user.ClinicPersons.Where(cu => cu.Clinic.HospitalId == CurrentHospital.Id).Select(x => new { Id = x.Clinic.Id }).ToList();


                            var selectedClinics = (from m in model.Clinics where m.Selected == true select new { Id = m.Id }).ToList();
                            var nonSelectedHospitals = (from m in model.Clinics where m.Selected == false select new { Id = m.Id }).ToList();

                            foreach (var item in selectedClinics)
                            {
                                if (!currentClinics.Contains(item))
                                {
                                    _dbContext.ClinicPersons.Add(new ClinicPersons
                                    {
                                        Clinic_Id = item.Id,
                                        PersonId = user.Id,
                                        IsManager = false,
                                        CreatedAt = DateTime.Now
                                    });
                                }
                            }
                            if (currentClinics != null && currentClinics.ToList().Count >= 1)
                            {
                                foreach (var item in nonSelectedHospitals)
                                {
                                    if (currentClinics.Contains(item))
                                    {
                                        var cu = _dbContext.ClinicPersons.FirstOrDefault(huh => huh.Clinic_Id == item.Id && huh.PersonId == user.Id);
                                        _dbContext.ClinicPersons.Remove(cu);
                                    }
                                }
                            }

                            _dbContext.SaveChanges();
                            transaction.Commit();
                            TempData["SetClinicsSuccess"] = "اختصاص کاربر به کلینیک با موفقیت انجام شد";
                            return RedirectToAction("Index", "Users", new { area = "HospitalManager" });
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("AssignToClinic", "اختصاص کاربر به بیمارستان با خطا مواجه شده است");
                            transaction.Rollback();
                        }
                    }

                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("AssignToHospital", "اختصاص کاربر به بیمارستان با خطا مواجه شده است");
            }
            return View(model);
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult CheckMobile(string mobile)
        {
            try
            {
                /*if (!Utils.IsValidMobile(mobile))
                {
                    throw new Core.MyExceptions.NotValidMobileException(mobile);
                }*/

                var existsMobile = _userService.GetAll()
                                         .Where(u => u.Mobile.Trim() == mobile.Trim())
                                         .ToList().Count >= 1;
                if (existsMobile)
                {
                    var hospitalUsers = _userService.GetAllForHospital(CurrentHospital.Id).Select(x => new { x.Mobile });

                    //if user exist for hospital then...                    
                    if (hospitalUsers.Contains(new { Mobile = mobile }))
                    {
                        return Json(new
                        {
                            Result = ResultCodes.ExistInHospital,
                            Message = "شماره ملی وارد شده هم اکنون در بیمارستان می باشد"
                        });
                    }
                    //if user dont exist for hospital then...
                    else
                    {
                        return Json(new
                        {
                            Result = ResultCodes.NotExistInHospital,
                            Message = "کاربری با این شماره ملی قبلا ثبت شده است اما در این بیمارستان موجود نمی باشد"
                        });
                    }
                }
                else
                {
                    //New National Code
                    return Json(new
                    {
                        Result = ResultCodes.NewMobile,
                        Message = "شماره ملی وارد شده معتبر می باشد"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = ResultCodes.NotValidMobile,
                    Message = ex.Message
                });
            }
        }
    }

    /// <summary>
    /// Check National Code Result Codes
    /// </summary>
    public enum ResultCodes
    {
        /// <summary>
        /// کد ملی اشکال دارد و معتبر نمی باشد
        /// </summary>
        NotValidMobile = 0,

        /// <summary>
        /// کد ملی معتبر است و کاربری با این کد هنوز ثبت نشده است
        /// </summary>
        NewMobile = 1,

        /// <summary>
        /// کد ملی معتبر است، کاربر قبلا ثبت شده است و برای این بیمارستان نیز موجود می باشد
        /// </summary>
        ExistInHospital = 2,

        /// <summary>
        /// کد ملی معتبر است، کاربر قبلا ثبت شده است اما برای این بیمارستان در دسترس نمی باشد
        /// </summary>
        NotExistInHospital = 3
    }
}