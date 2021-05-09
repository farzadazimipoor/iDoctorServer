using AN.Core.Enums;
using AN.Core.Resources.Enums;
using AN.Core.Resources.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.SonarManager.Models
{   
    public class CreateUpdateSonarPrescriptionViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "VisitDate", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string VisitDate { get; set; }

        [Display(Name = "Problems", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Problems { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description { get; set; }      

        public int PersonId { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int DoctorId { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Global))]
        public float? PatientVisitAge { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Global))]
        public float? PatientVisitWeight { get; set; }

        [Display(Name = "Height", ResourceType = typeof(Global))]
        public float? PatientVisitHeight { get; set; }

        [Display(Name = "sonography", ResourceType = typeof(EnumResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int SonarCenterId { get; set; }

        [Display(Name = "Requests", ResourceType = typeof(Global))]
        public List<int> SonarNeeds { get; set; }
    }

    public class SonarPrescriptionDetailsViewModel
    {
        public int Id { get; set; }
        public int TreatmentHistoryId { get; set; }
        public string HealthCenterName { get; set; }
        public string HealthCenterPhone { get; set; }
        public string HealthCenterAddress { get; set; }
        public string DoctorName { get; set; }
        public string DoctorExpertise { get; set; }
        public string PatientName { get; set; }
        public float PatientAge { get; set; }
        public string VisitDate { get; set; }
        public string Problems { get; set; }
        public string Instructions { get; set; }
        public PrescriptionStatus Status { get; set; }
        public List<int> SonarNeedIds { get; set; }
        public List<string> SonarNeeds { get; set; }
        public string PatientAvatar { get; set; }
    }
}
