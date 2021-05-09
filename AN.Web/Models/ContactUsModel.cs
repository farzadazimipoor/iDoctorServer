using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class ContactUsModel
    {
        [Display(Name = "Email", ResourceType = typeof(LocalResource.Resource))]
        [Required(ErrorMessageResourceName = "PromptEmailRequired", ErrorMessageResourceType = typeof(LocalResource.Resource))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "PromptEnterValidEmail", ErrorMessageResourceType = typeof(LocalResource.Resource))]
        [EmailAddress(ErrorMessageResourceName = "PromptEnterValidEmail", ErrorMessageResourceType = typeof(LocalResource.Resource))]
        public string Email { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Core.Resources.Global.Global))]
        [Required(ErrorMessageResourceName = "Msg_FieldRequired", ErrorMessageResourceType = typeof(Core.Resources.Global.Global))]
        public string Name { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        [Phone(ErrorMessageResourceName = "Msg_EnterValidMobileNumber", ErrorMessageResourceType = typeof(Core.Resources.Global.Global))]
        public string Phone { get; set; }

        [Display(Name = "Topic", ResourceType = typeof(Core.Resources.Global.Global))]
        [Required(ErrorMessageResourceName = "Msg_FieldRequired", ErrorMessageResourceType = typeof(Core.Resources.Global.Global))]
        public string Topic { get; set; }

        [MaxLength(500, ErrorMessageResourceType = typeof(Core.Resources.Global.Global), ErrorMessageResourceName = "MaxLength500")]
        [Display(Name = "Text", ResourceType = typeof(Core.Resources.Global.Global))]
        [Required(ErrorMessageResourceName = "Msg_FieldRequired", ErrorMessageResourceType = typeof(Core.Resources.Global.Global))]
        public string Message { get; set; }

        [Display(Name = "Captcha", ResourceType = typeof(Core.Resources.Global.Global))]
        [Required(ErrorMessageResourceName = "Msg_FieldRequired", ErrorMessageResourceType = typeof(Core.Resources.Global.Global))]
        public string MyCaptcha { get; set; }
    }
}