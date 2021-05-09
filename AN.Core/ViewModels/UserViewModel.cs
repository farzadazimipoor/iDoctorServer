using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string Username { get; set; }

        [Display(Name = "OldPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "NewPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Err_PasswordMustBe6Digit", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "Err_PasswordsAreNotMatch", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string ConfirmPassword { get; set; }
    }
}
