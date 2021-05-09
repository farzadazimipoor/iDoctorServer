using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class InsuranceCRUDViewModel
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

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "Description_Ku", ResourceType = typeof(Global))]
        public string Description_Ku { get; set; }

        [Display(Name = "Description_Ar", ResourceType = typeof(Global))]
        public string Description_Ar { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
    }

    public class InsuranceListItemViewModel
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
        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreatedAt { get; set; }      

        public string Logo { get; set; }

        public string LogoHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class InsuranceFilterViewModel
    {
        public string FilterString { get; set; }
    }
}
