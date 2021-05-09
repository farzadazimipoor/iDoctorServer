using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class TreatmentHistoryListItemViewModel
    {
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Patient", ResourceType = typeof(Global))]
        public string Patient { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }

        [SearchableString]       
        [Display(Name = "Pharmacy", ResourceType = typeof(Global))]
        public string Pharmacy { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "VisitDate", ResourceType = typeof(Global))]
        public string VisitDate { get; set; }

        public bool IsDoneByPharmacy { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }
    
    public class TreatmentHistoryFilterViewModel
    {
        public string FilterString { get; set; }
        public DateTime? VisitFrom { get; set; }
        public DateTime? VisitTo { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }      
        public List<int> ServiceSupplyIds { get; set; }
    }   

    public class PatientHistoryInfoModel
    {
        public string PresentIllness { get; set; }
        public string PastMedical { get; set; }
        public string DrugHistory { get; set; }
        public string SocialHistory { get; set; }
        public string ExaminationHistory { get; set; }
        public string SignsAndSymptomsHistory { get; set; }
        public string SurgicalHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string SystemicReview { get; set; }
        public string DifferentialDiagnosis { get; set; }
        public string FinalDiagnosis { get; set; }       
    }
}
