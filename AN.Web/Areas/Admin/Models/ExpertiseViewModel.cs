using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class ExpertiseCategoryViewModel
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
    }    
}