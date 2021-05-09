using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.Helper;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.Web.ViewComponents
{
    [Area("")]
    public class ListUsualPlansTableComponent : ViewComponent
    {
        private readonly IWorkContext _workContext;
        private readonly IShiftCenterService _polyclinicService;
        private readonly BanobatDbContext _dbContext;
        public ListUsualPlansTableComponent(IWorkContext workContext, IShiftCenterService shiftCenterService, BanobatDbContext banobatDbContext)
        {
            _workContext = workContext;
            _polyclinicService = shiftCenterService;
            _dbContext = banobatDbContext;
        }

        Lang Lng => CultureHelper.Lang;

        public async Task<IViewComponentResult> InvokeAsync(int polyclinicId)
        {           
            var polyclinic = _polyclinicService.GetShiftCenterForArea(polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.PolyclinicNotFound);

            IQueryable<UsualSchedulePlan> query = _dbContext.UsualSchedulePlans;

            query = query.Where(x => x.ServiceSupply.ShiftCenterId == polyclinic.Id);

            if(_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                query = query.Where(x => _workContext.WorkingArea.ServiceSupplyIds.Contains(x.ServiceSupplyId));
            }

            var morningplans = await query.Where(x => x.Shift == ScheduleShift.Morning).OrderByDescending(x => x.CreatedAt).ToListAsync();

            var morningPlansResult = new List<Shift>();

            foreach(var x in morningplans)
            {
                var doctorName = string.Empty;
                var medicalServiceName = string.Empty;
                var serviceSupply = polyclinic.ServiceSupplies.FirstOrDefault(s => s.Id == x.ServiceSupplyId);
                var centerService = polyclinic.PolyclinicHealthServices.FirstOrDefault(h => h.Id == x.ShiftCenterServiceId);
                if (serviceSupply != null)
                {
                    var doctorPerson = serviceSupply.Person;
                    doctorName = Lng == Lang.KU ? doctorPerson.FullName_Ku : Lng == Lang.AR ? doctorPerson.FullName_Ar : doctorPerson.FullName;
                }
                if(centerService != null)
                {
                    var service = centerService.Service;
                    medicalServiceName = Lng == Lang.KU ? service.Name_Ku : Lng == Lang.AR ? service.Name_Ar : service.Name;
                }
                morningPlansResult.Add(new Shift
                {
                    DayOfWeek = Utils.ConvertDayOfWeek(x.DayOfWeek.ToString()),
                    From = x.StartTime,
                    To = x.EndTime,
                    DoctorName = doctorName,
                    MedicalServiceName = medicalServiceName,
                    PrerequisiteName = x.Prerequisite.GetDisplayName(),
                    MaxCount = x.MaxCount,
                    UsualPlanId = x.Id
                });
            }

            var eveningplans = await query.Where(x => x.Shift == ScheduleShift.Evening).OrderByDescending(x => x.CreatedAt).ToListAsync();

            var eveningPlansResult = new List<Shift>();

            foreach (var x in eveningplans)
            {
                var doctorName = string.Empty;
                var medicalServiceName = string.Empty;
                var serviceSupply = polyclinic.ServiceSupplies.FirstOrDefault(s => s.Id == x.ServiceSupplyId);
                var centerService = polyclinic.PolyclinicHealthServices.FirstOrDefault(h => h.Id == x.ShiftCenterServiceId);
                if (serviceSupply != null)
                {
                    var doctorPerson = serviceSupply.Person;
                    doctorName = Lng == Lang.KU ? doctorPerson.FullName_Ku : Lng == Lang.AR ? doctorPerson.FullName_Ar : doctorPerson.FullName;
                }
                if (centerService != null)
                {
                    var service = centerService.Service;
                    medicalServiceName = Lng == Lang.KU ? service.Name_Ku : Lng == Lang.AR ? service.Name_Ar : service.Name;
                }
                eveningPlansResult.Add(new Shift
                {
                    DayOfWeek = Utils.ConvertDayOfWeek(x.DayOfWeek.ToString()),
                    From = x.StartTime,
                    To = x.EndTime,
                    DoctorName = doctorName,
                    MedicalServiceName = medicalServiceName,
                    PrerequisiteName = x.Prerequisite.GetDisplayName(),
                    MaxCount = x.MaxCount,
                    UsualPlanId = x.Id
                });
            }

            var result = new UsualPlansViewModel
            {
                MorningShiftPlans = morningPlansResult,
                EveningShiftPlans = eveningPlansResult,
                PolyclinicId = polyclinicId
            };

            return View(result);
        }
    }
}
