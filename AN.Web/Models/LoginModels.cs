using AN.Core.Enums;
using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class MobileLoginViewModel
    {
        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Mobile { get; set; }
    }

    public class VerifyOTPViewModel
    {
        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Mobile { get; set; }

        [Display(Name = "OTP")]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MinLength(6), MaxLength(6)]
        public string OTP { get; set; }
    }

    public class VerifyOTPResultModel
    {
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }

    public class CheckMobileResult
    {
        public bool IsExistUser { get; set; }
        public string Mobile { get; set; }
    }

    public class RegisterUserModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Email", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Err_PasswordMustBe6Digit", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Compare("Password", ErrorMessageResourceName = "Err_PasswordsAreNotMatch", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Captcha", ResourceType = typeof(Global))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string CaptchaResponse { get; set; }
    }

    public class RegisterUserResultModel
    {
        public string Mobile { get; set; }
    }
}