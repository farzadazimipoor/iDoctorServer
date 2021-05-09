using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.Persons;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AN.Core.Resources.EntitiesResources;

namespace AN.Web.Controllers
{
    [Authorize(Roles = "admin,polyclinicmanager,doctor,secretary")]
    public class SpecialityController : CpanelBaseController
    {
        private readonly IHospitalService _hospitalService;
        private readonly IClinicService _clinicService;
        private readonly IShiftCenterService _polyclinicService;
        private readonly ICommonUtils _commonUtils;
        private readonly IPersonService _userService;
        private readonly IWorkContext _workContext;
        private readonly BanobatDbContext _dbContext;
        public SpecialityController(IHospitalService hospitalService,
                                    IClinicService clinicService,
                                    IShiftCenterService polyclinicService,
                                    ICommonUtils commonUtils,
                                    IPersonService userService,
                                    IWorkContext workContext, BanobatDbContext dbContext) : base(workContext)
        {
            _hospitalService = hospitalService;
            _clinicService = clinicService;
            _polyclinicService = polyclinicService;
            _commonUtils = commonUtils;
            _userService = userService;
            _workContext = workContext;
            _dbContext = dbContext;
        }

        private IEnumerable<Person> _usersList;
        public IEnumerable<Person> Users => _usersList ?? (_usersList = GetUsersList());

        private List<Person> GetUsersList()
        {
            var result = new List<Person>();
            try
            {
                switch (LoginAs)
                {
                    case Shared.Enums.LoginAs.ADMIN:
                        result = _userService.GetAll().ToList();
                        break;
                    case Shared.Enums.LoginAs.HOSPITALMANAGER:
                        result = _userService.GetAllForHospital(_hospitalService.GetCurrentHospital().Id).ToList();
                        break;
                    case Shared.Enums.LoginAs.CLINICMANAGER:
                        result = _userService.GetAllForClinic(_clinicService.GetCurrentClinic().Id).ToList();
                        break;
                    case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                    case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                        result = _userService.GetAllForPoliClinic(_polyclinicService.GetCurrentShiftCenter().Id).ToList();
                        break;
                }
            }
            catch
            {
                // IGNORED
            }
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int polyclinicId, int doctorId, string userMessage = "")
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(doctorId)) throw new AccessDeniedException();
            }

            var cats = _commonUtils.PopulateExpertiseCategoriesList();

            var doctor = await _dbContext.ServiceSupplies.FindAsync(doctorId);

            if (doctor == null) throw new EntityNotFoundException();

            ViewBag.Lang = Lng;

            TempData["area"] = LoginAs.ToString();

            if (!string.IsNullOrEmpty(userMessage))
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = userMessage });
            }

            return View(new SpecialityViewModel
            {
                PolyclinicId = polyclinicId,
                doctorId = doctorId,
                Categories = cats,
                Expertises = _commonUtils.PopulateExpertisesList(int.Parse(cats.FirstOrDefault().Value)),
                DoctorName = doctor.Person.FullName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignSpeciality(SpecialityViewModel model)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(model.doctorId)) throw new AccessDeniedException();
            }

            var doctor = await _dbContext.ServiceSupplies.FindAsync(model.doctorId);

            if (doctor == null) throw new EntityNotFoundException();

            if (doctor.ServiceSupplyInfo == null) throw new Exception(Messages.UserIsNotDoctorYouCannotAssignSpeciality);

            var currentExpertises = doctor.DoctorExpertises.Select(x => new
            {
                x.Expertise.Id
            }).Distinct().ToList();

            var founded = (from ce in currentExpertises where ce.Id == model.expertiseId select ce).FirstOrDefault();
            if (founded == null)
            {
                _dbContext.DoctorExpertises.Add(new DoctorExpertise
                {
                    ServiceSupplyId = model.doctorId,
                    ExpertiseId = model.expertiseId,                   
                    CreatedAt = DateTime.Now
                });

                _dbContext.SaveChanges();
            }

            var userMessage = Messages.ActionDoneSuccesfully;

            return RedirectToAction("Index", "Speciality", new { area = "", model.PolyclinicId, model.doctorId, userMessage });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDoctorSpeciality(int polyclinicId, int doctorId, int expertiseId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(doctorId)) throw new AccessDeniedException();
            }

            var doctorExpertise = _dbContext.DoctorExpertises.FirstOrDefault(x => x.ServiceSupplyId == doctorId && x.ExpertiseId == expertiseId);

            _dbContext.DoctorExpertises.Remove(doctorExpertise);

            _dbContext.SaveChanges();

            var userMessage = Messages.ItemDeletedSuccessFully;

            return RedirectToAction("Index", "Speciality", new { area = "", polyclinicId, doctorId, userMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecialities(int categoryId)
        {
            try
            {
                var expertises = await _dbContext.Expertises.Where(x => x.ExpertiseCategoryId == categoryId).Select(x => new { x.Id, Name = Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name }).ToListAsync();

                var result = new JavaScriptSerializer().Serialize(expertises);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> SetScientificGrade(int polyclinicId, int doctorId)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(doctorId)) throw new AccessDeniedException();
            }

            var doctor = await _dbContext.ServiceSupplies.FindAsync(doctorId);

            if (doctor == null) throw new EntityNotFoundException();

            ViewBag.DoctorName = Lng == Lang.KU ? doctor.Person.FullName_Ku : Lng == Lang.AR ? doctor.Person.FullName_Ar : doctor.Person.FullName;

            var gradesList = await _dbContext.ScientificCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Lang.KU ? x.Name_Ku : Lng == Lang.AR ? x.Name_Ar : x.Name
            }).ToListAsync();

            ViewBag.Grades = gradesList;

            var model = new SetScientificGradeViewModel
            {
                CenterId = polyclinicId,
                ServiceSupplyId = doctorId,
                Grades = doctor.ServiceSupplyInfo?.DoctorScientificCategories.Select(x => x.ScientificCategoryId).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetScientificGrade(SetScientificGradeViewModel model)
        {
            if (_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                if (!_workContext.WorkingArea.ServiceSupplyIds.Contains(model.ServiceSupplyId)) throw new AccessDeniedException();
            }

            var doctor = await _dbContext.ServiceSupplies.FindAsync(model.ServiceSupplyId);

            if (doctor == null) throw new EntityNotFoundException();

            var scientificCategories = await _dbContext.DoctorScientificCategories.Where(x => x.ServiceSupplyId == model.ServiceSupplyId).ToListAsync();

            if (scientificCategories.Any())
            {
                _dbContext.DoctorScientificCategories.RemoveRange(scientificCategories);
            }

            if(model.Grades != null && model.Grades.Any())
            {
                var newGrades = model.Grades.Select(x => new DoctorScientificCategory
                {
                    ScientificCategoryId = x,
                    ServiceSupplyId = model.ServiceSupplyId,
                    CreatedAt = DateTime.Now
                }).ToList();

                _dbContext.DoctorScientificCategories.AddRange(newGrades);
            }
         
            await _dbContext.SaveChangesAsync();

            return Json(new { success = true, message = Messages.ActionDoneSuccesfully });
        }
    }
}