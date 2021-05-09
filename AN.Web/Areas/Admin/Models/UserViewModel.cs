using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
    }

    public class UserCreateUpdateViewModel : UserViewModel
    {
        [Display(Name = "Person", ResourceType = typeof(Global))]
        public int? PersonId { get; set; }

        [Display(Name = "Role", ResourceType = typeof(Global))]
        public string Role { get; set; }

        [Display(Name = "Center", ResourceType = typeof(Global))]
        public int? CenterId { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public List<int> ServiceSupplyIds { get; set; } = new List<int>();

        [Display(Name = "Email", ResourceType = typeof(Global))]
        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [MaxLength(256, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength256")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(11, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "EnableTwoFactorAuthentication", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public bool TwoFactorEnabled { get; set; } = false;
    }

    public class UserCreateViewModel : UserCreateUpdateViewModel
    {
        [Display(Name = "Username", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        public string UserName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Err_PasswordMustBe6Digit", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "Err_PasswordsAreNotMatch", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string ConfirmPassword { get; set; }       
    }

    public class UserUpdateViewModel : UserCreateUpdateViewModel
    {

    }

    public class UserListViewModel : UserViewModel
    {      
        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Username", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string UserName { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Role", ResourceType = typeof(Global))]
        public string Role { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Person", ResourceType = typeof(Global))]
        public string Person { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Center", ResourceType = typeof(Global))]
        public string Center { get; set; }

        public string LockoutStatusHtml { get; set; }

        public string ActionsHtml { get; set; }       
    }
}
