using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class CreatePatientViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int? ServiceSupplyId { get; set; }

        public int? AppointmentId { get; set; }

        public PersonCreateUpdateViewModel PersonModel { get; set; }
    }

    public class CreateSonarPatientViewModel
    {
        public int? Id { get; set; }
       
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int? ServiceSupplyId { get; set; }

        public int? AppointmentId { get; set; }

        public PersonCreateUpdateViewModel PersonModel { get; set; }
    }

    public class CreatePatientFromPersonViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int? ServiceSupplyId { get; set; }        

        public PersonInfoViewModel PersonInfo { get; set; }

        public List<SelectListItem> DoctorsList { get; set; }
    }

    public class CreateSonarPatientFromPersonViewModel
    {       
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int? ServiceSupplyId { get; set; }

        public PersonInfoViewModel PersonInfo { get; set; }

        public List<SelectListItem> DoctorsList { get; set; }
    }

    public class FindPatientViewModel
    {
        [Display(Name = "TrackingCode", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string UniqueId { get; set; }
        public int AppointmentId { get; set; }
    }  
    
    public class FindPersonModel
    {
        public string SearchString { get; set; }
    }

    public class PatientAttachmentViewModel : UploadFilesResultViewModel
    {
        public DateTime CreatedAt { get; set; }
        public int PatientId { get; set; }
    }
}