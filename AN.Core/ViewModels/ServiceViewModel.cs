using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class ServiceListItemViewModel
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public ParentOrChild ParentOrChild { get; set; }

        public int CategoryId { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Category", ResourceType = typeof(Global))]
        public string Category { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }       

        public decimal Price { get; set; }

        public string Time { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class ServiceViewModel
    {
        public int? Id { get; set; } = null;

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Category", ResourceType = typeof(Global))]
        public int ServiceCategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Name_Ku", ResourceType = typeof(Global))]
        public string Name_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Name_Ar", ResourceType = typeof(Global))]
        public string Name_Ar { get; set; }     

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Price", ResourceType = typeof(Global))]
        public string Price { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description { get; set; }

        [Display(Name = "Description_Ku", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description_Ku { get; set; }

        [Display(Name = "Description_Ar", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description_Ar { get; set; }

        [Display(Name = "Time", ResourceType = typeof(Global))]
        public string Time { get; set; }        
    }
}
