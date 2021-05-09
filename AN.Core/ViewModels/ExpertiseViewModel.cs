using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class ExpertiseCreateUpdateViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name { get; set; }

        [Display(Name = "Name_Ku", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name_Ku { get; set; }

        [Display(Name = "Name_Ar", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength100")]
        public string Name_Ar { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description { get; set; }

        [Display(Name = "Description_Ku", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description_Ku { get; set; }

        [Display(Name = "Description_Ar", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description_Ar { get; set; }

        [Display(Name = "Category", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int CategoryId { get; set; }
    }

    public class ExpertiseListViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Category", ResourceType = typeof(Global))]
        public string Category { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class ExpertiseFilterViewModel
    {
        public string FilterString { get; set; }
        public int? CategoryId { get; set; }       
    }
}
