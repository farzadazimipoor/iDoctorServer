using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class PharmacyListViewModel
    {
        [SearchableInt]
        [Sortable]
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "City", ResourceType = typeof(Global))]
        public string City { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }        
    }

    public class PharmacyCreateUpdateViewModel
    {
        public int? Id { get; set; } = null;

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        public string Name { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        public string Name_Ku { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
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

        [Display(Name = "City", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CityId { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength256")]
        public string Address { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength256")]
        public string Address_Ku { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength256")]
        public string Address_Ar { get; set; }       

        [MaxLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength9")]
        [MinLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLength9")]
        [Display(Name = "Latitude", ResourceType = typeof(Global))]
        public string GoogleMap_lat { get; set; }

        [MaxLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength9")]
        [MinLength(9, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MinLength9")]
        [Display(Name = "Longtitude", ResourceType = typeof(Global))]
        public string GoogleMap_lng { get; set; }       
    }
}
