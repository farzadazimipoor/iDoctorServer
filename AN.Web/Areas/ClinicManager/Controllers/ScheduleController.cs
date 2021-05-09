using AN.BLL.DataRepository.Clinics;
using AN.Core.Models;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.ClinicManager.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class ScheduleController : ClinicManagerController
    {
        #region Fields
        private static Logger logger;
        private readonly IClinicService _clinicService;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public ScheduleController(IClinicService clinicService, BanobatDbContext dbContext) : base(clinicService)
        {
            _clinicService = clinicService;
            logger = LogManager.GetCurrentClassLogger();
            _dbContext = dbContext;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ClinicVocations()
        {
            return View(new CMVocationViewModel());
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClinicVocationDay(CMVocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fromDate = DateTime.Parse(model.FromDate);

                    var toDate = DateTime.Parse(model.ToDate);

                    var clinic = await _dbContext.Clinics.FindAsync(CurrentClinic.Id);

                    _dbContext.Entry(clinic).State = EntityState.Modified;

                    var vocations = new List<VocationModel>();

                    if (clinic.Vocations != null)
                    {
                        vocations = clinic.Vocations;
                    }

                    vocations.Add(new VocationModel
                    {
                        F = fromDate,
                        T = toDate
                    });

                    var specialSchedules =
                        _dbContext.Schedules
                        .Where(s => s.ServiceSupply.ShiftCenter.ClinicId == clinic.Id)
                        .AsEnumerable()
                        .Where(s => s.Start_DateTime.Date >= fromDate.Date && s.Start_DateTime.Date <= toDate.Date).ToList();
                    foreach (var s in specialSchedules)
                    {
                        _dbContext.Entry(s).State = EntityState.Modified;

                        s.IsAvailable = false;
                    }

                    clinic.Vocations = vocations;

                    await _dbContext.SaveChangesAsync();

                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemAddedSuccessFully });
                    return RedirectToAction("ClinicVocations", "Schedule", new { area = "ClinicManager" });
                }
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.PleaseEnterAllRequestedData });
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.ErrorOccuredWhileDoneAction });
            }

            return RedirectToAction("ClinicVocations", new CMVocationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClinicVocation(string from, string to)
        {
            try
            {
                var fromDate = DateTime.Parse(from);

                var toDate = DateTime.Parse(to);

                var clinic = await _dbContext.Clinics.FindAsync(CurrentClinic.Id);

                if (clinic.Vocations != null)
                {
                    _dbContext.Entry(clinic).State = EntityState.Modified;

                    var vocations = clinic.Vocations;

                    var voc = vocations.FirstOrDefault(v => v.F.Date == fromDate.Date && v.T.Date == toDate);

                    if (voc != null)
                    {
                        vocations.Remove(voc);
                    }

                    if (vocations.Count > 0)
                        clinic.Vocations = vocations;
                    else
                        clinic.Vocations = null;

                    await _dbContext.SaveChangesAsync();
                }
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemDeletedSuccessFully });
                return RedirectToAction("ClinicVocations", "Schedule", new { area = "ClinicManager" });
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
            }

            return RedirectToAction("ClinicVocations", new CMVocationViewModel());
        }
    }
}