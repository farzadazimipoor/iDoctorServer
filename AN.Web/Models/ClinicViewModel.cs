using AN.Core.Enums;
using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class ClinicViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Hospital", ResourceType = typeof(Global))]
        public int? HospitalId { get; set; }

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

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> listCities { get; set; }

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

        #region PHONE
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Phone1 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone2 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone3 { get; set; } 
        #endregion

        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string GoogleMap_lat { get; set; }

        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string GoogleMap_lng { get; set; }

        #region NOTIFICATION
        [Display(Name = "Notification", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Notification { get; set; }

        [Display(Name = "Notification", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Notification_Ku { get; set; }

        [Display(Name = "Notification", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Notification_Ar { get; set; }
        #endregion

        #region FINAL BOOK MESSAGE
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage_Ku { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage_Ar { get; set; }
        #endregion

        #region FINAL BOOK SMS MESSAGE
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage_Ku { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage_Ar { get; set; } 
        #endregion

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone1IsForReserve { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone2IsForReserve { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone3IsForReserve { get; set; }

        [Display(Name = "IsGovernant", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public bool IsGovernmental { get; set; }

        [Display(Name = "IsHosterly", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public bool IsHostelry { get; set; }

        [Display(Name = "ClinicType", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ClinicType Type { get; set; }      
        
        public string Logo { get; set; }
    }   

    public class List
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "Hospital", ResourceType = typeof(Global))]
        public string Hospital { get; set; }

        [Display(Name = "Manager", ResourceType = typeof(Global))]
        public List<string> Managers { get; set; }
    }   

    public class ClinicDetailsViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        public string Place { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "IsGovernant", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string IsGovernmental { get; set; }

        [Display(Name = "IsHosterly", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string IsHostelry { get; set; }

        [Display(Name = "ClinicType", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string Type { get; set; }

        [Display(Name = "CallNumbers", ResourceType = typeof(Global))]
        public List<string> Phones { get; set; }

        [Display(Name = "Managers", ResourceType = typeof(Global))]
        public List<string> Managers { get; set; }

        [Display(Name = "Polyclinics", ResourceType = typeof(Global))]
        public int PolyclinicsCount { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreationDate { get; set; }
    }
}