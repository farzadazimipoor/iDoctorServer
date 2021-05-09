using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMUsersViewModel
    {
        public string Id { get; set; }

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

    public class CreateCMUsersViewModel : CMUsersViewModel
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

        //[Display(Name = "پست الکترونیکی (نام کاربری)")]
        //[EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        //[Required(ErrorMessage = "ایمیل الزامی می باشد")]
        ////[UniqueEmail]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "کلمه عبور الزامی می باشد")]
        //[StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "کلمه عبور")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "تکرار کلمه عبور")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "تکرار کلمه عبور، با کلمه عبور یکسان نیست")]
        //public string ConfirmPassword { get; set; }
    }

    public class EditCMUsersViewModel : CMUsersViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        public string Mobile { get; set; }

        //[Display(Name = "پست الکترونیکی")]
        //[EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده معتبر نمی باشد")]
        //[Required(ErrorMessage = "پست الکترونیکی الزامی می باشد")]
        //public string Email { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }
    }

    public class CMListUsersViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }             

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        public string Email { get; set; }

        [Display(Name = "Roles", ResourceType = typeof(Global))]
        public List<string> UserRoles { get; set; }

        public List<String> Expertises { get; set; }

        public bool HaveEditPermission { get; set; } = false;

        public bool IsDoctor { get; set; } = false;
    }


    public class CMUsersCountModel
    {
        public int AllCount { get; set; }
        public int AdminsCount { get; set; }
        public int HospitalManagersCount { get; set; }
        public int ClinicManagersCount { get; set; }
        public int PolyClinicManagersCount { get; set; }
        public int DoctorsCount { get; set; }
        public int PatientsCount { get; set; }
    }
   


    public class SetDoctorExpertisesViewModel
    {
        public string UserId { get; set; }
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
}