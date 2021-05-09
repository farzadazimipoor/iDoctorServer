using AN.BLL.DataRepository.Clinics;
using AN.DAL;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using NLog;
using System;
using System.Linq;
using System.Net;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class PoliClinicController : ClinicManagerController
    {
        #region Fields
        private readonly JavaScriptSerializer javaScriptSerializer;
        private static Logger logger;
        private readonly IClinicService _clinicService;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public PoliClinicController(IClinicService clinicService, BanobatDbContext dbContext) : base(clinicService)
        {
            _clinicService = clinicService;

            logger = LogManager.GetCurrentClassLogger();
            javaScriptSerializer = new JavaScriptSerializer();
            _dbContext = dbContext;
        }
        #endregion                   

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult GetHealthServices(int? polyclinicId)
        {
            try
            {
                if (polyclinicId == null)
                {
                    return Json(new { Error = "Bad Request" });
                }
                var services = from h in _dbContext.CenterServices
                               where h.ShiftCenterId == polyclinicId && h.ShiftCenter.ClinicId == CurrentClinic.Id
                               select new { Id = h.Id, Name = Lng == Core.Enums.Lang.KU ? h.Service.Name_Ku : h.Service.Name_Ar };

                var jsonResult = javaScriptSerializer.Serialize(services.ToList());
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult GetServiceSupplies(int? polyclinicId)
        {
            try
            {
                if (polyclinicId == null)
                {
                    return Json(new { Error = "Bad Request" });
                }

                var serviceSupplies = from s in _dbContext.ServiceSupplies
                                      where s.ShiftCenterId == polyclinicId && s.ShiftCenter.ClinicId == CurrentClinic.Id
                                      select s;

                var result = serviceSupplies.Select(x => new { x.Id, Name = x.Person.FirstName + " " + x.Person.SecondName + " " + x.Person.ThirdName }).ToList();

                var jsonResult = javaScriptSerializer.Serialize(result);
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }

        [HttpGet]
        //[NoDirectAccess]
        public JsonResult GetServiceSuppliesForHealthService(int? polyclinicId, int? polyclinicHealthServiceId)
        {
            try
            {
                if (polyclinicId == null || polyclinicHealthServiceId == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Bad Request");
                }

                var serviceSupplies = _dbContext.ServiceSupplies
                    .Where(ss => ss.IsAvailable &&
                                 ss.ShiftCenterId == polyclinicId &&
                                 ss.ShiftCenter.ClinicId == CurrentClinic.Id &&
                                 (ss.Schedules.Where(x => x.ShiftCenterServiceId == polyclinicHealthServiceId).ToList().Count > 0 ||
                                 ss.UsualSchedulePlans.Where(u => u.ServiceSupplyId == ss.Id && u.ShiftCenterServiceId == polyclinicHealthServiceId).ToList().Count > 0))
                    .Select(x => new { x.Id, Name = x.Person.FirstName + " " + x.Person.SecondName + " " + x.Person.ThirdName }).ToList();

                var jsonResult = javaScriptSerializer.Serialize(serviceSupplies);
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "0", ex.Message });
            }
        }
    }
}