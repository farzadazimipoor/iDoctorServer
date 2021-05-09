using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.Polyclinics;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.EntitiesResources;
using AN.Web.App_Code;
using AN.Web.Helper;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.ViewComponents
{
    [Area("")]
    public class ListDoctorsTableComponent : ViewComponent
    {
        private readonly IClinicService _clinicService;
        private readonly IShiftCenterService _polyClinicService;
        private readonly IWorkContext _workContext;
        public ListDoctorsTableComponent(IClinicService clinicService, IShiftCenterService polyclinicService, IWorkContext workContext)
        {
            _clinicService = clinicService;
            _polyClinicService = polyclinicService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? polyclinicId)
        {
            var lng = CultureHelper.Lang;

            var polyclinic = GetPolyclinic(polyclinicId);

            if (polyclinic == null) throw new Exception(Messages.ItemNotFound);

            var serviceSupplies = polyclinic.ServiceSupplies.ToList();

            if(_workContext.WorkingArea.ServiceSupplyIds != null && _workContext.WorkingArea.ServiceSupplyIds.Any())
            {
                serviceSupplies = serviceSupplies.Where(x => _workContext.WorkingArea.ServiceSupplyIds.Contains(x.Id)).ToList();
            }           

            var poliClinicDoctors = serviceSupplies.Select(s => new SettingDoctorViewModel
            {
                DoctorName = lng == Lang.KU ? s.Person.FullName_Ku : lng == Lang.AR ? s.Person.FullName_Ar : s.Person.FullName,
                MedicalCouncilNumber = s.ServiceSupplyInfo?.MedicalCouncilNumber,               
                ReservationType = s.ReservationType,
                ReservationTypeString = s.ReservationType.GetDisplayName(),
                OnlineReservationPercent = s.OnlineReservationPercent,
                ServiceSupplyId = s.Id,
                StartReservationDate = s.StartReservationDate.ToShortDateString(),
                UserDoctorId = s.Person.Id,
                PolyclinicId = polyclinic.Id,
                IsAvailable = s.IsAvailable,     
                Specialities = s?.DoctorExpertises.Select(x => lng == Lang.EN ? x.Expertise.Name : lng == Lang.KU ? x.Expertise.Name_Ku : x.Expertise.Name_Ar).ToList()
            }).ToList();

            return View(poliClinicDoctors);
        }

        private ShiftCenter GetPolyclinic(int? polyclinicId)
        {
            if (polyclinicId != null)
            {
                switch (_workContext.LoginAs)
                {
                    case Shared.Enums.LoginAs.ADMIN:
                        return _polyClinicService.GetShiftCenterById((int)polyclinicId);
                    case Shared.Enums.LoginAs.HOSPITALMANAGER:
                        return _polyClinicService.GetAllShiftCentersForHospital(_workContext.WorkingArea.Id).FirstOrDefault(x => x.Id == polyclinicId);
                    case Shared.Enums.LoginAs.CLINICMANAGER:
                        {
                            var currentClinic = _clinicService.GetCurrentClinic();
                            if (currentClinic != null)
                                return currentClinic.ShiftCenters.FirstOrDefault(x => x.Id == polyclinicId);
                        }
                        break;
                    case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                    case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                        {
                            var currentPolyclinic = _polyClinicService.GetCurrentShiftCenter();
                            if (currentPolyclinic != null)
                            {
                                if (polyclinicId == currentPolyclinic.Id)
                                    return currentPolyclinic;
                            }
                        }                       
                        break;
                }
            }

            return null;
        }
    }
}
