using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Province", ResourceType = typeof(Global))]
        public string ProvinceName { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string City { get; set; }        
    }

    public class CreateCityViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name { get; set; }

        [Display(Name = "Name_Ku", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name_Ku { get; set; }

        [Display(Name = "Name_Ar", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name_Ar { get; set; }

        [Display(Name = "Province", ResourceType = typeof(Global))]
        public int ProvinceId { get; set; }

        public IEnumerable<SelectListItem> listProvinces { get; set; }
    }
}