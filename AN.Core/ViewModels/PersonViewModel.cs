using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class PersonListViewModel
    {       
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "IsEmployee", ResourceType = typeof(Global))]
        public string IsEmployee { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class PersonCreateUpdateViewModel
    {
        public int? Id { get; set; } = null;       

        #region FirstName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string FirstName_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.EntitiesResources.User))]
        public string FirstName_Ar { get; set; }
        #endregion

        #region SecondName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName_Ar { get; set; }
        #endregion

        #region ThirdName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName_Ar { get; set; }
        #endregion            

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceName = "Err_ThisFieldIsRequired", ErrorMessageResourceType = typeof(Global))]
        [MaxLength(11, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]        
        public string Mobile { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Global))]
        [MaxLength(256, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength256")]
        public string Email { get; set; }
       
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public Gender Gender { get; set; }

        [Display(Name = "IsEmployee", ResourceType = typeof(Global))]
        public bool IsEmployee { get; set; } = false;

        [Display(Name = "ZipCode", ResourceType = typeof(Global))]
        public string ZipCode { get; set; }    

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }      
        
        [Display(Name = "Birthdate", ResourceType = typeof(Global))]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Age", ResourceType = typeof(Global))]
        [Range(1, 150, ErrorMessageResourceName = "Range1And150", ErrorMessageResourceType = typeof(Global))]
        public float Age { get; set; }       

        [Display(Name = "Weight", ResourceType = typeof(Global))]
        [Range(1, 500, ErrorMessageResourceName = "Range1And500", ErrorMessageResourceType = typeof(Global))] // Kilogram
        public float? Weight { get; set; }

        [Display(Name = "Height", ResourceType = typeof(Global))]
        [Range(1, 300, ErrorMessageResourceName = "Range1And300", ErrorMessageResourceType = typeof(Global))]  // CM
        public float? Height { get; set; }       

        [Display(Name = "IdNumber", ResourceType = typeof(Global))]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        public string IdNumber { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "MarriageStatus", ResourceType = typeof(Global))]
        public MarriageStatus MarriageStatus { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Language", ResourceType = typeof(Global))]
        public Language Language { get; set; }

        [Display(Name = "BloodType", ResourceType = typeof(Global))]
        public BloodType? BloodType { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }
    }

    public class PersonFilterViewModel
    {
        public string FilterString { get; set; }
        public Gender? Gender { get; set; }
        public bool IsEmployee { get; set; }
        public string IsEmployeeFilter { get; set; }
    }

    public class PersonInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "TrackingCode", ResourceType = typeof(Global))]
        public string UniqueId { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string FirstName { get; set; }

        [Display(Name = "SecondName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string SecondName { get; set; }

        [Display(Name = "ThirdName", ResourceType = typeof(Core.Resources.EntitiesResources.User))]
        public string ThirdName { get; set; }

        [Display(Name = "Birthdate", ResourceType = typeof(Global))]
        public string Birthdate { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Global))]
        public float Age { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Sex { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Global))]
        public float Weight { get; set; }

        [Display(Name = "Height", ResourceType = typeof(Global))]
        public float Height { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string MobileNumber { get; set; }

        [Display(Name = "IdNumber", ResourceType = typeof(Global))]
        public string IdNumber { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "MarriageStatus", ResourceType = typeof(Global))]
        public string MarriageStatus { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Global))]
        public string Language { get; set; }

        public string Avatar { get; set; }
    }

    public class PatientListViewModel
    {      
        public int Id { get; set; }

        public int? ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Global))]
        [Sortable(Default = false)]
        public float Age { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "IdNumber", ResourceType = typeof(Global))]
        public string IdNumber { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "TrackingCode", ResourceType = typeof(Global))]
        public string UniqueId { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }       

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class PatientFilterViewModel
    {
        public string FilterString { get; set; }

        public string UniqueId { get; set; }

        /// <summary>
        /// Selected in filters form
        /// </summary>
        public int? ServiceSupplyId { get; set; }

        /// <summary>
        /// Force to load only patients for this service suppliers that user can manage
        /// </summary>
        public List<int> ServiceSupplyIds { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
