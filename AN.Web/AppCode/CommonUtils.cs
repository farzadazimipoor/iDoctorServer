using AN.BLL.DataRepository.Expertises;
using AN.BLL.DataRepository.Places;
using AN.BLL.DataRepository.Polyclinics;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Resources.EntitiesResources;
using AN.Core.Resources.Global;
using AN.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.Web.App_Code
{
    public class CommonUtils : ICommonUtils
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IShiftCenterService _polyclinicService;
        private readonly IExpertiseService _expertiseService;
        private readonly IPlaceService _placeService;
        private readonly IWorkContext _workContext;
        public CommonUtils(BanobatDbContext dbContext, IShiftCenterService polyclinicService, IExpertiseService expertiseService, IPlaceService placeService, IWorkContext workContext)
        {
            _dbContext = dbContext;
            _polyclinicService = polyclinicService;
            _expertiseService = expertiseService;
            _placeService = placeService;
            _workContext = workContext;
        }

        private Lang Lng => _workContext.Lang;

        public IEnumerable<SelectListItem> PopulateProvincesList()
        {
            var provinces = _placeService.GetAllProvinces().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = Lng == Lang.KU ? p.Name_Ku : Lng == Lang.AR ? p.Name_Ar : p.Name
            }).AsEnumerable();

            return new SelectList(provinces, "Value", "Text");
        }


        public IEnumerable<SelectListItem> PopulateCitiesList()
        {
            var cities = _placeService.GetAllCities().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = Lng == Lang.KU ? p.Name_Ku : Lng == Lang.AR ? p.Name_Ar : p.Name
            }).AsEnumerable();

            return new SelectList(cities, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PopulateExpertiseCategoriesList()
        {
            var expertiseCats = _expertiseService.GetAllExpertiseCategories().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = Lng == Lang.KU ? p.Name_Ku : Lng == Lang.AR ? p.Name_Ar : p.Name
            });

            return new SelectList(expertiseCats, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PopulateExpertisesList()
        {
            var expertises = _expertiseService.GetAllExpertises().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = Lng == Lang.KU ? p.Name_Ku : Lng == Lang.AR ? p.Name_Ar : p.Name
            });

            return new SelectList(expertises, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PopulateExpertisesList(int categoryId)
        {
            var expertises = _expertiseService.GetExpertisesForCategory(categoryId).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = Lng == Lang.KU ? p.Name_Ku : Lng == Lang.AR ? p.Name_Ar : p.Name
            });

            return new SelectList(expertises, "Value", "Text");
        }      

        public IEnumerable<SelectListItem> PopulateServiceSuppliesList(int policlinicId)
        {
            var policlinic = _polyclinicService.GetShiftCenterById(policlinicId);

            if (policlinic == null) return new List<SelectListItem>();

            var result = policlinic.ServiceSupplies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Person.FullName
            }).ToList();

            return result;
        }

        public IEnumerable<SelectListItem> PopulateDaysOfWeekList()
        {
            IList<SelectListItem> daysOfWeek = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = Global.Saturday },
                new SelectListItem { Value = "1", Text = Global.Sunday },
                new SelectListItem { Value = "2", Text = Global.Monday },
                new SelectListItem { Value = "3", Text = Global.Tuesday },
                new SelectListItem { Value = "4", Text = Global.Wednesday },
                new SelectListItem { Value = "5", Text = Global.Thursday },
                new SelectListItem { Value = "6", Text = Global.Friday }
            };

            return new SelectList(daysOfWeek, "Value", "Text");
        }


        public IEnumerable<SelectListItem> PopulateDaysOfWeekListForUsualPlan()
        {
            IList<SelectListItem> daysOfWeek = new List<SelectListItem>
            {
                new SelectListItem { Value = "Saturday", Text = Global.Saturday },
                new SelectListItem { Value = "Sunday", Text = Global.Sunday },
                new SelectListItem { Value = "Monday", Text = Global.Monday },
                new SelectListItem { Value = "Tuesday", Text = Global.Tuesday },
                new SelectListItem { Value = "Wednesday", Text = Global.Wednesday },
                new SelectListItem { Value = "Thursday", Text = Global.Thursday },
                new SelectListItem { Value = "Friday", Text = Global.Friday }
            };

            return new SelectList(daysOfWeek, "Value", "Text");
        }


        public IEnumerable<SelectListItem> PopulatePrerequisiteTypes()
        {
            var prerequisiteTypes = Enum.GetValues(typeof(PrerequisiteType)).Cast<PrerequisiteType>().ToList();

            var list = from p in prerequisiteTypes
                       select new
                       {
                           Id = prerequisiteTypes.IndexOf(p),
                           Name = p.ToString()
                       };
            var result = list.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return result;
        }


        public IEnumerable<SelectListItem> PopulateAppointmentStatuses()
        {
            var apptStatuses = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

            var list = from p in apptStatuses
                       select new
                       {
                           Id = apptStatuses.IndexOf(p),
                           Name = p.ToString()
                       };
            var result = list.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return result;
        }



        public IEnumerable<SelectListItem> PopulatePaymentStatuses()
        {
            var payments = Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>().ToList();

            var list = from p in payments
                       select new
                       {
                           Id = payments.IndexOf(p),
                           Name = p.ToString()
                       };
            var result = list.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return result;
        }


        public IEnumerable<SelectListItem> PopulateReservationRangeStartPoints()
        {
            var points = new List<SelectListItem>
            {
                new SelectListItem { Value = "-1", Text = Messages.WithoutLimitation_FromNow, Selected = true },
                new SelectListItem { Value = "0", Text = Messages.WithStartingVisitTime },
                new SelectListItem { Value = "1", Text = Messages.Custom }
            };

            return new SelectList(points, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PopulateReservationRangeEndPoints()
        {
            var points = new List<SelectListItem>
            {
                new SelectListItem { Value = "-1", Text = Messages.UntilEndVisitTime, Selected = true },
                new SelectListItem { Value = "0", Text = Messages.WithStartingVisitTime },
                new SelectListItem { Value = "1", Text = Messages.Custom }
            };

            return new SelectList(points, "Value", "Text");
        }
    }
}