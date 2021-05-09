using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.MyAttributes;
using AN.Core.Resources.Global;
using AN.Core.Resources.UI.AdminPanel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class SchedulingViewModel
    {
        public int ServiceSupplyId { get; set; }
        public int PolyclinicId { get; set; }
        public string DoctorName { get; set; }
    }

    public class ScheduleEventViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Date { get; set; }

        [Display(Name = "FromTime", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string StartTime { get; set; }

        [Display(Name = "ToTime", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string EndTime { get; set; }

        [Display(Name = "Service", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int HealthServiceId { get; set; }

        [Display(Name = "Prerequisite", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public PrerequisiteType Prerequisite { get; set; }

        [Display(Name = "MaxCapacity", ResourceType = typeof(Global))]
        [PosNumberNoZero(ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_NumberMustBeBiggerThanZero")]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Range(1, 500, ErrorMessageResourceName = "Range1And500", ErrorMessageResourceType = typeof(Global))]
        public int MaxCount { get; set; } = 1;

        public bool IsAvailable { get; set; } = false;

        public ActionType Action { get; set; } = ActionType.NotSet;

        public DateTime? StartDateTime => DateTime.Parse($"{GlobalUtils.FaNum2EN(Date)} {GlobalUtils.FaNum2EN(StartTime)}");

        public DateTime? EndDateTime => DateTime.Parse($"{GlobalUtils.FaNum2EN(Date)} {GlobalUtils.FaNum2EN(EndTime)}");
    }

    public class SaveScheduleResultModel
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }


    public class DoctorAvailabilityModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }
        public string doctorName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public bool IsAvailable { get; set; }

        public IList<Appointment> PendingAppointments { get; set; }
        public bool CancelAllAppointments { get; set; }
    }



    public class SetUsualPlanViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }

        [Display(Name = "Day", ResourceType = typeof(Global))]
        public string DayOfWeek { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "FromTime", ResourceType = typeof(Global))]
        public string From { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "ToTime", ResourceType = typeof(Global))]
        public string To { get; set; }

        [Display(Name = "Shift", ResourceType = typeof(Global))]
        public int Shift { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }

        public string DoctorName { get; set; }

        [Display(Name = "Service", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int MedicalServiceId { get; set; }

        public string MedicalServiceName { get; set; }

        [Display(Name = "Prerequisite", ResourceType = typeof(Global))]
        public PrerequisiteType PrerequisiteType { get; set; }

        [Range(1, 1000, ErrorMessageResourceName = "Range1And1000", ErrorMessageResourceType = typeof(Global))]
        [Display(Name = "MaxCapacity", ResourceType = typeof(Global))]
        public int MaxCount { get; set; }

        public IEnumerable<MySelectListItem> ListMedicalServices { get; set; }       
        public IEnumerable<SelectListItem> ListServiceSupplies { get; set; }
        public IEnumerable<SelectListItem> ListDaysOfWeek { get; set; }

    }

    public class UsualPlansViewModel
    {
        public IEnumerable<Shift> MorningShiftPlans { get; set; }

        public IEnumerable<Shift> EveningShiftPlans { get; set; }

        public int PolyclinicId { get; set; }
    }


    public class Shift
    {
        public string DayOfWeek { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DoctorName { get; set; }
        public string MedicalServiceName { get; set; }
        public string PrerequisiteName { get; set; }
        public int MaxCount { get; set; }
        public int UsualPlanId { get; set; }
    }

    public class ShiftSaveModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int HealthServiceId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public DayOfWeek DayOfWeek { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ScheduleShift Shift { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public bool Enabled { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string StartTime { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string EndTime { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int MaxCount { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public PrerequisiteType Prerequisite { get; set; }
    }

    public class ScheduleInsurancesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class InsertScheduleInsurancesModel
    {
        public int ScheduleId { get; set; }
        public int InsuranceId { get; set; }
        public int Capacity { get; set; }
    }
}