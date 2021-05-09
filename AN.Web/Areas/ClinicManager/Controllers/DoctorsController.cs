using AN.BLL.DataRepository.Clinics;
using AN.Core.Enums;
using AN.DAL;
using AN.Web.Areas.ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using X.PagedList;
using System;
using System.Linq;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class DoctorsController : ClinicManagerController
    {
        #region Fields
        private static Logger logger;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public DoctorsController(BanobatDbContext dbContext, IClinicService clinicService) : base(clinicService)
        {
            _dbContext = dbContext;
            logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.StatusSortParam = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.AppointsSortParam = sortOrder == "Appoints" ? "appoints_desc" : "Appoints";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FamilySortParam = sortOrder == "Family" ? "family_desc" : "Family";
            ViewBag.PolyclinicSortParam = sortOrder == "Polyclinic" ? "polyclinic_desc" : "Polyclinic";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var query = from s in _dbContext.ServiceSupplies
                        where s.ShiftCenter.ClinicId == CurrentClinic.Id
                        select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a =>
                a.Person.FirstName.Contains(searchString) ||
                a.Person.SecondName.Contains(searchString) ||
                a.Person.ThirdName.Contains(searchString) ||
                a.Person.Mobile.Contains(searchString) ||
                a.ServiceSupplyInfo.MedicalCouncilNumber.Contains(searchString) ||
                a.ShiftCenter.Name_Ku.Contains(searchString)
                );
            }

            var doctors = query.AsEnumerable().Select(x => new CMDoctorsViewModel
            {
                IsAvailable = x.IsAvailable,
                Name = x.Person.FirstName + " " + x.Person.SecondName + " " + x.Person.ThirdName,
                PendingAppointments = x.Appointments.Where(a => a.Start_DateTime >= DateTime.Now && a.Status == AppointmentStatus.Pending && !a.IsDeleted).Count(),
                MedicalCouncilNumber = x.ServiceSupplyInfo.MedicalCouncilNumber,
                Polyclinic = x.ShiftCenter.Name_Ku,
                ServiceSupplyId = x.Id
            });

            switch (sortOrder)
            {
                case "status_desc":
                    doctors = doctors.OrderByDescending(x => x.IsAvailable);
                    break;
                case "Status":
                    doctors = doctors.OrderBy(x => x.IsAvailable);
                    break;
                case "appoints_desc":
                    doctors = doctors.OrderByDescending(x => x.PendingAppointments);
                    break;
                case "Appoints":
                    doctors = doctors.OrderBy(x => x.PendingAppointments);
                    break;
                case "name_desc":
                    doctors = doctors.OrderByDescending(a => a.Name);
                    break;
                case "Family":
                    doctors = doctors.OrderBy(a => a.Family);
                    break;
                case "family_desc":
                    doctors = doctors.OrderByDescending(a => a.Family);
                    break;
                case "Polyclinic":
                    doctors = doctors.OrderBy(a => a.Polyclinic);
                    break;
                case "polyclinic_desc":
                    doctors = doctors.OrderByDescending(a => a.Polyclinic);
                    break;
                default:
                    doctors = doctors.OrderByDescending(x => x.IsAvailable).ThenByDescending(x => x.PendingAppointments);
                    break;
            }

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(doctors.ToPagedList(pageNumber, pageSize));
        }
    }
}