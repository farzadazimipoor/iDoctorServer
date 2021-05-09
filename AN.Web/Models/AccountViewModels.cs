using AN.Core.Enums;
using AN.Core.Resources.Global;
using AN.Core.Resources.UI.login;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]        
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Provider { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LoginResource), ErrorMessageResourceName = "Err_UsernameIsRequired")]
        [Display(Name = "Username", ResourceType = typeof(LoginResource))]        
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(LoginResource) , ErrorMessageResourceName = "Err_PasswordIsRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(LoginResource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(LoginResource))]
        public bool RememberMe { get; set; }

        [Display(Name = "UserRole", ResourceType = typeof(Global))]
        public LoginAs LgoinAs { get; set; }

    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Family { get; set; }

        [MinLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]       
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(LoginResource))]
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }

        public string Gender { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(LoginResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(LoginResource))]
        [Compare("Password", ErrorMessageResourceName = "Err_PasswordsNotMatch", ErrorMessageResourceType = typeof(Global))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ResetPasswordMobileViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(LoginResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(LoginResource))]
        [Compare("Password", ErrorMessageResourceName = "Err_PasswordsNotMatch", ErrorMessageResourceType = typeof(Global))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "Err_EmailIsRequired", ErrorMessageResourceType = typeof(LoginResource))]
        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(LoginResource))]
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }
    }

    public class ForgotPasswordMobileViewModel
    {
        [Required(ErrorMessageResourceName = "Err_EmailIsRequired", ErrorMessageResourceType = typeof(LoginResource))]
        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(LoginResource))]
        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileBe10Char", ErrorMessageResourceType = typeof(Global))]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }
    }
}
