using AN.Core.Enums;
using AN.Core.Resources.Global;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Description { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> listCities { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Address { get; set; }
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Phone1 { get; set; }
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone2 { get; set; }
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string Phone3 { get; set; }
        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string GoogleMap_lat { get; set; }
        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string GoogleMap_lng { get; set; }
        [Display(Name = "Notification", ResourceType = typeof(Global))]
        public string Notification { get; set; }
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

        public List<CMAddClinicImageViewModel> Images { get; set; }
    }


    public class CMAddClinicImageViewModel : UploadFilesResultViewModel
    {
        public int? ClinicId { get; set; }
    }   
}