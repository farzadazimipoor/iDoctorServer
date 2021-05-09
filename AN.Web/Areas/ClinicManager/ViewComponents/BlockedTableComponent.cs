using AN.BLL.DataRepository.Clinics;
using AN.Core.Domain;
using AN.DAL;
using AN.Web.Areas.ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.ClinicManager.ViewComponents
{
    [Area("ClinicManager")]
    public class BlockedTableComponent : ViewComponent
    {
        private readonly IClinicService _clinicService;
        private readonly BanobatDbContext _dbContext;
        public BlockedTableComponent(IClinicService clinicService, BanobatDbContext dbContext)
        {
            _clinicService = clinicService;
            _dbContext = dbContext;
        }

        private Clinic _currentClinic;
        public Clinic CurrentClinic => _currentClinic ?? (_currentClinic = _clinicService.GetCurrentClinic());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blocked = (from bc in _dbContext.BlockedMobiles
                           where bc.ShiftCenter.ClinicId == CurrentClinic.Id
                           select new BlockedMobilesViewModel
                           {
                               Id = bc.Id,
                               Mobile = bc.Mobile,
                               Description = bc.Description,
                               PolyclinicId = bc.ShiftCenterId
                           }).AsEnumerable();

            return View(blocked);
        }
    }
}