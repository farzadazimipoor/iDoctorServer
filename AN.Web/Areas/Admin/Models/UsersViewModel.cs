using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        public string NamePrefix { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName { get; set; }     

        [Display(Name = "Age", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]        
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]        
        public string Mobile { get; set; }       

        [Display(Name = "ZipCode", ResourceType = typeof(Global))]
        public string ZipCode { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int[] Roles { get; set; }
      
        public string AvatarName { get; set; }

    }
   
    public class CreateUsersViewModel : UsersViewModel
    {
        //[DataType(DataType.Upload, ErrorMessage = "تصویر انتخاب نشده است")]
        [Display(Name = "Image", ResourceType = typeof(Global))]
        //[ValidateUserProfilePicture]
        public IFormFile ImageUpload { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        //[EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]        
        //[UniqueEmail]
        public string Email { get; set; }

        //[Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        //[StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Err_PasswordMustBe6Digit", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "ConfirmPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceName = "Err_PasswordsAreNotMatch", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string ConfirmPassword { get; set; }
    }

    public class EditUsersViewModel : UsersViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Global))]
        //[EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        //[Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Email { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }
        
    }

    public class ListUsersViewModel
    {       
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }      

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]        
        public string Email { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string UserName { get; set; }      
        
        public List<string> Expertises { get; set; } 
    }

    public class UsersCountModel
    {
        public int AllCount { get; set; }
        public int AdminsCount { get; set; }
        public int HospitalManagersCount { get; set; }
        public int ClinicManagersCount { get; set; }
        public int PolyClinicManagersCount { get; set; }
        public int DoctorsCount { get; set; }
        public int PatientsCount { get; set; }
    }

    public class ListDoctorsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Family", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string Family { get; set; }      

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }        

        [Display(Name = "MedicalCouncilNumber", ResourceType = typeof(Global))]
        public string MedicalCouncilNumber { get; set; }

        [Display(Name = "TimePeriod", ResourceType = typeof(Global))]
        public int Duration { get; set; }

        [Display(Name = "ReservationType", ResourceType = typeof(Global))]
        public string ReservationType { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        public List<string> UserRoles { get; set; }

        public int ServiceSupplyId { get; set; }

        [Display(Name = "OnlineReservationPercentage", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public int OnlineReservationPercent { get; set; }
    }

    public class UserDetailsViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public int Age { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }
        public string Description { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        public List<string> Roles { get; set; }

        public string Avatar { get; set; }
    }

    public class AssignUserToHospitalViewModel
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<SelectAssignUserToHospitalViewModel> Hospitals { get; set; }
    }

    public class SelectAssignUserToHospitalViewModel
    {       
        public bool Selected { get; set; }

        public int Id { get; set; }

        [Display(Name = "HospitalName", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string Name { get; set; }        
    }

    public class AssignUserToPoliclinicViewModel
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<SelectAssignUserToPoliclinicViewModel> Policlinics { get; set; }
    }


    public class SelectAssignUserToPoliclinicViewModel
    {
        public bool Selected { get; set; }

        public int Id { get; set; }

        [Display(Name = "PolyclinicName", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string Name { get; set; }

    }


    public class SetDoctorExpertisesViewModel
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<ExpertiseCategory> Categories { get; set; }
        public List<SelectDoctorExpertisesViewModel> Expertises { get; set; }
    }


    public class SelectDoctorExpertisesViewModel
    {
        public bool Selected { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
        public string ExpertiseCategoryName { get; set; }        
        
        public int ScientificCateoryId { get; set; }
        public IEnumerable<SelectListItem> ListScientificCategories { get; set; }
    }

    public class ChangePassViewModel
    {
        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string UserId { get; set; }

        [Required(ErrorMessageResourceName = "Err_PasswordIsRequired", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Err_PasswordMustBe6Digit", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessageResourceName = "Err_PasswordsAreNotMatch", ErrorMessageResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string ConfirmNewPassword { get; set; }
    }

}