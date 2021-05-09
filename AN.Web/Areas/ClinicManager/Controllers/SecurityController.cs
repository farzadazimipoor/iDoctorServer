using AN.BLL.DataRepository.Clinics;
using AN.Core.Domain;
using AN.Core.Resources.EntitiesResources;
using AN.Core.Resources.Global;
using AN.DAL;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.ClinicManager.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class SecurityController : ClinicManagerController
    {
        private static Logger logger;
        private readonly IClinicService _clinicService;
        private readonly BanobatDbContext _dbContext;
        public SecurityController(IClinicService clinicService, BanobatDbContext dbContext) : base(clinicService)
        {
            _clinicService = clinicService;
            logger = LogManager.GetCurrentClassLogger();
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Blocked()
        {
            var _listPolyclinics = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "0",
                        Text = Global.All
                    }
                };

            var currentClinic = CurrentClinic;

            var query = currentClinic.ShiftCenters.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Core.Enums.Lang.KU ? x.Name_Ku : x.Name_Ar
            }).ToList();

            _listPolyclinics.AddRange(query);

            return View(new CMBlockMobileViewModel
            {
                Polyclinics = _listPolyclinics
            });
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlockMobile(CMBlockMobileViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PolyclinicId == 0)
                    {
                        var polyclinics = _dbContext.ShiftCenters.Where(p => p.ClinicId == CurrentClinic.Id).ToList();
                        foreach (var item in polyclinics)
                        {
                            _dbContext.BlockedMobiles.Add(new BlockedMobiles
                            {
                                CreatedAt = DateTime.Now,
                                Mobile = model.Mobile,
                                Description = model.Description,
                                ShiftCenterId = item.Id
                            });
                        }
                    }
                    else
                    {
                        _dbContext.BlockedMobiles.Add(new BlockedMobiles
                        {
                            CreatedAt = DateTime.Now,
                            Mobile = model.Mobile,
                            Description = model.Description,
                            ShiftCenterId = model.PolyclinicId
                        });
                    }

                    _dbContext.SaveChanges();

                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ActionDoneSuccesfully });

                    return RedirectToAction("Blocked", "Security", new { area = "ClinicManager" });
                }
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.PleaseEnterAllRequestedData });
            }
            catch
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.ErrorOccuredWhileDoneAction });
            }

            var _listPolyclinics = new List<SelectListItem>();
            _listPolyclinics.Add(new SelectListItem
            {
                Value = "0",
                Text = Global.All
            });
            var currentClinic = CurrentClinic;
            var query = currentClinic.ShiftCenters.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lng == Core.Enums.Lang.KU ? x.Name_Ku : x.Name_Ar
            }).ToList();

            _listPolyclinics.AddRange(query);

            model.Polyclinics = _listPolyclinics;

            return RedirectToAction("Blocked", model);
        }
    }

    public class BlockMobileComprarer : IEqualityComparer<CMBlockMobileViewModel>
    {
        public bool Equals(CMBlockMobileViewModel x, CMBlockMobileViewModel y)
        {
            //اینجا مشخص کردم که در صورت برابری شماره ملی یا نام کاربری دو یوزر با هم برابرند            
            if (x.Mobile == y.Mobile)
                return true;

            return false;
        }

        public int GetHashCode(CMBlockMobileViewModel obj)
        {
            return obj.Mobile.GetHashCode();
        }
    }
}