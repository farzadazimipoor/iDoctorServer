using AN.Core.Enums;
using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class PCUsersViewModel
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
                
        [Display(Name = "MedicalCouncilNumber", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string DocotrMedicalCouncilNumber { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(Global))]
        public string ZipCode { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Description { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int[] Roles { get; set; }       

        public string AvatarName { get; set; }
    }

    public class CreatePCUsersViewModel : PCUsersViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        //[UniqueMobileAttribute]
        public string Mobile { get; set; }

        //[DataType(DataType.Upload, ErrorMessage = "تصویر انتخاب نشده است")]
        [Display(Name = "Image", ResourceType = typeof(Global))]
        //[ValidateUserProfilePicture]
        public IFormFile ImageUpload { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        //[UniqueEmail]
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
    }

    public class EditPCUsersViewModel : PCUsersViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        public string Mobile { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Global))]
        [EmailAddress(ErrorMessageResourceName = "Err_EmailIsNotValid", ErrorMessageResourceType = typeof(Core.Resources.UI.login.LoginResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Email { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }
    }

    public class PCListUsersViewModel
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

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        public List<string> UserRoles { get; set; }

        public bool HaveEditPermission { get; set; } = false;

        public bool IsDoctor { get; set; } = false;
    }


    public class PCUsersCountModel
    {       
        public int PolyClinicManagersCount { get; set; }
        public int DoctorsCount { get; set; }
        public int PatientsCount { get; set; }
    }


    public class PCListManagersViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Family", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string Family { get; set; }      

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }
        public bool HaveEditPermission { get; set; } = false;
    }


    public class PCListDoctorsViewModel
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

        public bool HaveEditPermission { get; set; } = false;

        public bool IsAvailable { get; set; } = false;
    }


    public class PCListPatientsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Family", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string Family { get; set; }      

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "TurnsCount", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public int AppointsCount { get; set; }

        public bool HaveEditPermission { get; set; } = false;
    }
}