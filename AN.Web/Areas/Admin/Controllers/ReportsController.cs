using AN.Core.Enums;
using AN.DAL;
using AN.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using System;
using System.Linq;

namespace AN.Web.Areas.Admin.Controllers
{
    public class ReportsController : AdminController
    {
        private readonly BanobatDbContext _dbContext;
        public ReportsController(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoctorAppointmentsReport()
        {
            var doctors = (from user in _dbContext.Persons
                           join serviceSupply in _dbContext.ServiceSupplies on user.Id equals serviceSupply.PersonId
                           join appointment in _dbContext.Appointments on serviceSupply.Id equals appointment.ServiceSupplyId
                           where serviceSupply.Appointments.Where(x => !x.IsDeleted && x.Paymentstatus != PaymentStatus.NotPayed).ToList().Count >= 1
                           select new DoctorAppointmentsViewModel
                           {
                               DoctorName = user.FirstName + " " + user.SecondName + " " + user.ThirdName,
                               AppointmentsCount = serviceSupply.Appointments.Where(x => !x.IsDeleted && x.Paymentstatus != PaymentStatus.NotPayed).ToList().Count
                           })
                               .Distinct()
                               .OrderByDescending(x => x.AppointmentsCount)
                               .ToList();
            return View(doctors);
        }

        public IActionResult PolyclinicsWithPendingAppoints(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PolyclinicNameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountSortParam = sortOrder == "Count" ? "count_desc" : "Count";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IQueryable<ObjResult> query;

            if (!string.IsNullOrEmpty(searchString))
            {
                var date = DateTime.Parse(searchString);
                query = (from p in _dbContext.ShiftCenters
                         where ((bool)p.IsIndependent || (bool)p.Clinic.IsIndependent) && p.ServiceSupplies.Any(x => x.Appointments.Any(y => y.Status == AppointmentStatus.Pending))
                         select new ObjResult
                         {
                             Polyclinic = p,
                             Manager = p.ShiftCenterUsers.FirstOrDefault(x => x.IsManager).Person,
                             Appointments = _dbContext.Appointments.Where(x => x.ServiceSupply.ShiftCenterId == p.Id && x.Status == AppointmentStatus.Pending && x.Start_DateTime > DateTime.Now && x.Start_DateTime.Date == date.Date)
                         });
            }
            else
            {
                query = (from p in _dbContext.ShiftCenters
                         where ((bool)p.IsIndependent || (bool)p.Clinic.IsIndependent) && p.ServiceSupplies.Any(x => x.Appointments.Any(y => y.Status == AppointmentStatus.Pending))
                         select new ObjResult
                         {
                             Polyclinic = p,
                             Manager = p.ShiftCenterUsers.FirstOrDefault(x => x.IsManager).Person,
                             Appointments = _dbContext.Appointments.Where(x => x.ServiceSupply.ShiftCenterId == p.Id && x.Status == AppointmentStatus.Pending && x.Start_DateTime > DateTime.Now)
                         });
            }

            query = query.Where(x => x.Appointments.Count() > 0);

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(a => a.Polyclinic.Name_Ku);
                    break;
                case "Count":
                    query = query.OrderBy(a => a.Appointments.Count());
                    break;
                case "count_desc":
                    query = query.OrderByDescending(a => a.Appointments.Count());
                    break;
                default:
                    query = query.OrderByDescending(a => a.Appointments.Count());
                    break;
            }

            var result = query.Select(x => new PolyclinicsWithPendingAppointsModel
            {
                Polyclinic = x.Polyclinic,
                Manager = x.Manager.FirstName + " " + x.Manager.SecondName + " " + x.Manager.ThirdName,
                Mobile = x.Manager.Mobile,
                Count = x.Appointments.Count()
            });

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));
        }
    }
}