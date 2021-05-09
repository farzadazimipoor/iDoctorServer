using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class ListHospitalsViewModel
    {
        public int HospitalId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string HospitalName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string HospitalDescription { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        public string City { get; set; }
    }

    public class HospitalViewModel
    {
        public int? Id { get; set; }

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

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description_Ku { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description_Ar { get; set; }
      
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]        
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage_Ku { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]       
        [Display(Name = "ReservationAnnouncementMessage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookMessage_Ar { get; set; }
        
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]        
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage_Ku { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]       
        [Display(Name = "ReservationAnnouncementSMS", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string FinalBookSMSMessage_Ar { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> listPlaces { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        public string Address { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        public string Address_Ku { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        public string Address_Ar { get; set; }

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

        public string Logo { get; set; }
    }     

    public class HospitalDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        public string Place { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }
    }
}