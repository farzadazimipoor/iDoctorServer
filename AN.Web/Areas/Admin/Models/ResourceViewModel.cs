using AN.Core;
using AN.Web.App_Code.Validation;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AN.Core.Resources.Global;
using AN.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace AN.Web.Areas.Admin.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Key", ResourceType = typeof(Global))]
        public ResourceKey Key { get; set; }
        [Display(Name ="Type", ResourceType = typeof(Global))]
        public ResourceType Type { get; set; }
        [Display(Name = "Downloads", ResourceType = typeof(Global))]
        public int Downloads { get; set; }
        [Display(Name = "Url")]
        public string FilePath { get; set; }
        [Display(Name = "CurrentVersion", ResourceType = typeof(Global))]
        public string Version { get; set; }
    }


    public class CreateResourceViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]        
        public ResourceKey Key { get; set; }
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ResourceType Type { get; set; }       

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [ValidVersion]
        public string Version { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public IFormFile FileUpload { get; set; }
    }


    public class UploadNewVersionViewModel
    {
        public int Id { get; set; }
       
        public ResourceKey Key { get; set; }
        public ResourceType Type { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [ValidVersion]
        public string Version { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public IFormFile FileUpload { get; set; }
    }
}