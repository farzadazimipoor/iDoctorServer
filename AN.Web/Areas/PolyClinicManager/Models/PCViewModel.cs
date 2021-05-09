using AN.Core.Resources.Global;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class PCViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name { get; set; }        
        
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> listCities { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "Err_MobileNotValid", ErrorMessageResourceType = typeof(Global))]
        public string Phone1 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone2 { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone3 { get; set; }

        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string GoogleMap_lat { get; set; }
        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string GoogleMap_lng { get; set; }

        [Display(Name = "ReservationLimitationBeforeVisit", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [Range(0, 99)]
        public int BookingRestriction { get; set; } = 24; //default value is 24

        [Display(Name = "ActiveDaysAhead", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public int ActiveDaysAhead { get; set; } = 15;

        [Display(Name = "Notification", ResourceType = typeof(Global))]
        public string Notification { get; set; }

        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone1IsForReserve { get; set; }
        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone2IsForReserve { get; set; }
        [Display(Name = "ToReserve", ResourceType = typeof(Global))]
        public bool Phone3IsForReserve { get; set; }

        public List<AddPoliclinicImageViewModel> Images { get; set; }
    }   

    public class VocationDayViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Day", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string DayOfWeek { get; set; }

        public IEnumerable<SelectListItem> DaysOfWeek { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Date { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }
    }      
}