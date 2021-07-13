using AN.Core.Enums;
using AN.Core.MyAttributes;
using AN.Core.Resources.Global;
using AN.Core.Resources.UI.AdminPanel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class ListPoliClinicsViewModel
    {
        public int PoliClinicId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string PoliClinicName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string PoliClinicDescription { get; set; }

        [Display(Name = "Clinic", ResourceType = typeof(Global))]
        public string Clinic { get; set; }

        [Display(Name = "Manager", ResourceType = typeof(Global))]
        public List<string> Managers { get; set; }

        [Display(Name = "Doctors", ResourceType = typeof(Global))]
        public List<string> Doctors { get; set; }
    }

    public class PoliClinicViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ShiftCenterType Type { get; set; }

        [Display(Name = "Clinic", ResourceType = typeof(Global))]
        public int? ClinicId { get; set; }

        #region NAME
        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name_Ku { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name_Ar { get; set; }
        #endregion

        #region ADDRESS
        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Address { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Address_Ku { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Address_Ar { get; set; }
        #endregion

        #region FINAL BOOK MESSAGE
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(PanelResource))]
        public string FinalBookMessage { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(PanelResource))]
        public string FinalBookMessage_Ku { get; set; }

        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(PanelResource))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        public string FinalBookMessage_Ar { get; set; }
        #endregion

        #region FINAL BOOK SMS MESSAGE
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(PanelResource))]
        public string FinalBookSMSMessage { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(PanelResource))]
        public string FinalBookSMSMessage_Ku { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(PanelResource))]
        public string FinalBookSMSMessage_Ar { get; set; }
        #endregion

        #region DESCRIPTION
        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description_Ku { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description_Ar { get; set; }
        #endregion

        #region NOTIFICATION
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Notification", ResourceType = typeof(Global))]
        public string Notification { get; set; }

        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Notification", ResourceType = typeof(Global))]
        public string Notification_Ku { get; set; }

        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Notification", ResourceType = typeof(Global))]
        public string Notification_Ar { get; set; }
        #endregion

        #region PHONES
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength15")]
        public string Phone1 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [MaxLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength15")]
        public string Phone2 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [MaxLength(15, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength15")]
        public string Phone3 { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone1IsForReserve { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone2IsForReserve { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone3IsForReserve { get; set; }
        #endregion

        #region GIS
        [MaxLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength9")]
        [MinLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLength9")]
        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string GoogleMap_lat { get; set; }

        [MaxLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength9")]
        [MinLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLength9")]
        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string GoogleMap_lng { get; set; } 
        #endregion

        [Display(Name = "ReservationLimitationBeforeVisit", ResourceType = typeof(PanelResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Range(0, 24, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Range0And24")]
        public int BookingRestriction { get; set; } = 24; //default value is 24

        [Range(0, 365, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Range1And365")]
        [Display(Name = "ActiveDaysAhead", ResourceType = typeof(PanelResource))]
        public int ActiveDaysAhead { get; set; } = 15;

        public bool SupportAppointments { get; set; } = false;

        public bool ShowInHealthBank { get; set; } = false;

        public List<AddPoliclinicImageViewModel> Images { get; set; }

        public string Logo { get; set; }

        public IEnumerable<SelectListItem> listCities { get; set; }
    }

    public class AddPoliclinicImageViewModel : UploadFilesResultViewModel
    {
        public int? PoliclinicId { get; set; }
    }

    public class PolyclinicDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        public string Place { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string Latitude { get; set; }

        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string Longitude { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public List<string> Phones { get; set; }

        [Display(Name = "Managers", ResourceType = typeof(Global))]
        public List<string> Managers { get; set; }

        [Display(Name = "Doctors", ResourceType = typeof(Global))]
        public List<string> Doctors { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Global))]
        public string Type { get; set; }
    }

    public class SetPolyclinicHealthServicesViewModel
    {
        public int PoliClinicId { get; set; }
        public string PoliClinicName { get; set; }
        public List<SelectPolyclinicHealthServicesViewModel> Services { get; set; }
    }

    public class SelectPolyclinicHealthServicesViewModel
    {
        public bool Selected { get; set; }

        public decimal? Price { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class SettingDoctorViewModel
    {
        [Display(Name = "Doctor", ResourceType = typeof(Global))]        
        public IEnumerable<SelectListItem> ListDoctors { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string DoctorName { get; set; }

        [Display(Name = "MedicalCouncilNumber", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength10")]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]         
        public string MedicalCouncilNumber { get; set; }       

        [Display(Name = "ReservationType", ResourceType = typeof(Global))]
        public ReservationType ReservationType { get; set; }

        [Display(Name = "ReservationType", ResourceType = typeof(Global))]
        public string ReservationTypeString { get; set; }

        [Display(Name = "OnlineReservationPercentage", ResourceType = typeof(PanelResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Range(1, 100, ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_RangeBetween1And100")]
        [PosNumberNoZero(ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_NumberMustBeBiggerThanZero")]
        public int OnlineReservationPercent { get; set; } = 100;

        public int ServiceSupplyId { get; set; }

        [Display(Name = "StartReservationDate", ResourceType = typeof(PanelResource))]
        public string StartReservationDate { get; set; } = DateTime.Now.ToShortDateString();

        public int PolyclinicId { get; set; }

        public int UserDoctorId { get; set; }       

        public bool IsAvailable { get; set; } = false;
        [Display(Name = "From", ResourceType = typeof(Global))]
        public IEnumerable<SelectListItem> ListReservationStartPoints { get; set; }
        public int StartPoint { get; set; }
        public int StartPointNumber { get; set; }
        public int StartPointUnit { get; set; }

        [Display(Name = "To", ResourceType = typeof(Global))]
        public IEnumerable<SelectListItem> ListReservationEndPoints { get; set; }
        public int EndPoint { get; set; }
        public int EndPointNumber { get; set; }
        public int EndPointUnit { get; set; }
        public int EndPointPosition { get; set; }      
        
        public List<string> Specialities { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Bio { get; set; }

        [Display(Name = "Description_Ku", ResourceType = typeof(Global))]
        public string Bio_Ku { get; set; }

        [Display(Name = "Description_Ar", ResourceType = typeof(Global))]
        public string Bio_Ar { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Phone { get; set; }
    }

    public class EditServiceSupplyViewModel
    {
        //[Display(Name = "TimePeriod", ResourceType = typeof(Global))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        //[Range(3, 100, ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_RangeBetween3And100")]
        //[PosNumberNoZero(ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_NumberMustBeBiggerThanZero")]
        //public int Duration { get; set; } = 15;

        [Display(Name = "ReservationType", ResourceType = typeof(Global))]
        public ReservationType ReservationType { get; set; }

        [Display(Name = "OnlineReservationPercentage", ResourceType = typeof(PanelResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Range(0, 100, ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_RangeBetween1And100")]
        [PosNumberNoZero(ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_NumberMustBeBiggerThanZero")]
        public int OnlineReservationPercent { get; set; } = 100;

        public int ServiceSupplyId { get; set; }

        [Display(Name = "StartReservationDate", ResourceType = typeof(PanelResource))]
        public string StartReservationDate { get; set; } = DateTime.Now.ToShortDateString();

        public int PolyclinicId { get; set; }

        public int UserDoctorId { get; set; }

        //[Display(Name = "VisitPrice", ResourceType = typeof(PanelResource))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        //public long VisitPrice { get; set; } = 0;

        //[Display(Name = "PrepaymentPercentage", ResourceType = typeof(PanelResource))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        //[Range(0, 100, ErrorMessageResourceType = typeof(PanelResource), ErrorMessageResourceName = "Err_RangeBetween1And100")]
        //public int PrePaymentPercent { get; set; } = 0;

        //[Display(Name = "PaymentType", ResourceType = typeof(Global))]
        //public int PaymentType { get; set; } = 0;

        //[Display(Name = "Rate", ResourceType = typeof(Global))]
        //public long RankScore { get; set; }

        [Display(Name = "From", ResourceType = typeof(Global))]
        public IEnumerable<SelectListItem> ListReservationStartPoints { get; set; }
        public int StartPoint { get; set; }
        public int StartPointNumber { get; set; }
        public int StartPointUnit { get; set; }

        [Display(Name = "To", ResourceType = typeof(Global))]
        public IEnumerable<SelectListItem> ListReservationEndPoints { get; set; }
        public int EndPoint { get; set; }
        public int EndPointNumber { get; set; }
        public int EndPointUnit { get; set; }
        public int EndPointPosition { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Bio { get; set; }

        [Display(Name = "Description_Ku", ResourceType = typeof(Global))]
        public string Bio_Ku { get; set; }

        [Display(Name = "Description_Ar", ResourceType = typeof(Global))]
        public string Bio_Ar { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Phone { get; set; }

        [Display(Name = "MedicalCouncilNumber", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength10")]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string MedicalCouncilNumber { get; set; }
    }
    
    public class ServiceSupplyDetailsModel
    {
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        public string Avatar { get; set; }

        [Display(Name = "StartReservationDate", ResourceType = typeof(PanelResource))]
        public string StartReservationDate { get; set; }

        [Display(Name = "VisitPrice", ResourceType = typeof(PanelResource))]
        public long? VisitPrice { get; set; }

        [Display(Name = "PrepaymentPercentage", ResourceType = typeof(PanelResource))]
        public int PrePaymentPercent { get; set; }

        [Display(Name = "PaymentType", ResourceType = typeof(Global))]
        public string PaymentType { get; set; }
    }
}