using AN.Core.Enums;
using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class ServiceCategoryViewModel
    {
        public int? Id { get; set; } = null;

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
        [Display(Name = "CenterType", ResourceType = typeof(Global))]
        public ShiftCenterType CenterType { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }

        public string Photo { get; set; }
    }
}
