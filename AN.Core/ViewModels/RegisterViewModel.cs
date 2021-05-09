using AN.Core.Enums;
using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class RegisterPoliClinicViewModel : GoogleReCaptchaBaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "SecondName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "ThirdName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string ThirdName { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]       
        [Display(Name = "Mobile", ResourceType = typeof(Resources.EntitiesResources.User))]     
        public string Mobile { get; set; }

        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string Email { get; set; }

        public ShiftCenterType CenterType { get; set; } = ShiftCenterType.Polyclinic;

        [Display(Name = "Polyclinic", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string PoliClinicName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "City", ResourceType = typeof(Global))]
        public int CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string PoliClinicAddress { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }
    }

    public class RegisterDownloadAppModel : RegisterPoliClinicViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Speciality { get; set; }


        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterOfflineResult
    {
        public RegisterOfflineData Doctor { get; set; }
    }

    public class RegisterOfflineData
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public string Speciality { get; set; }
        public string Password { get; set; }
    }
}
