using AN.Core.Enums;
using AN.Core.Resources.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class BookingViewModel
    {
      
        [Display(Name = "Service", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CenterServiceId { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public DateTime Date { get; set; }
    }

    public class PolyclinicBookingViewModel : BookingViewModel
    {
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }

        [Display(Name = "Patient", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PatientId { get; set; }
    }

    public class BeautyCenterBookingViewModel : BookingViewModel
    {
        [Display(Name = "Employee", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }

        [Display(Name = "Customer", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PatientId { get; set; }
    }

    public class PolyclinicBookableTimesViewModel
    {
        public PolyclinicBookingViewModel BookingModel { get; set; }
        public List<BookableTimesListModel> BokkableTimes { get; set; } = new List<BookableTimesListModel>();
    }

    public class BeautyCenterBookableTimesViewModel
    {
        public BeautyCenterBookingViewModel BookingModel { get; set; }
        public List<BookableTimesListModel> BokkableTimes { get; set; } = new List<BookableTimesListModel>();
    }

    public class BookableTimesListModel
    {
        public TimePeriodType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PersonMobile { get; set; }
        public string PersonName { get; set; }
        public bool IsOutOfSchedule { get; set; }
    }

    public class ConfirmBookingViewModel
    {
        public PersonInfoViewModel PatientPersonInfo { get; set; }
        public PersonInfoViewModel DoctorPersonInfo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Service { get; set; }
        public string DoctorExpertiseCategory { get; set; }
    }

    public class PolyclinicConfirmBookingViewModel : ConfirmBookingViewModel
    {
        public PolyclinicBookingViewModel BookingData { get; set; }
    }

    public class BeautyCenterConfirmBookingViewModel : ConfirmBookingViewModel
    {
        public BeautyCenterBookingViewModel BookingData { get; set; }
    }
}
