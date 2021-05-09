using AWRO.Helper.UIHelper.Attributes;
using AN.Core.Resources.Global;
using AN.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AN.Core.Resources.Enums;
using AN.Core.ViewModels;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class TreatmentHistoryViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "VisitDate", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string VisitDate { get; set; }

        [Display(Name = "ChiefComplaint", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Problems_Ku { get; set; }      
      
        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description_Ku { get; set; }       

        public int? AppointmentId { get; set; } = null;

        public int? PatientId { get; set; }

        public int PersonId { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public int DoctorId { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Global))]
        public float? PatientVisitAge { get; set; }      

        [Display(Name = "Weight", ResourceType = typeof(Global))]
        public float? PatientVisitWeight { get; set; }

        [Display(Name = "Height", ResourceType = typeof(Global))]
        public float? PatientVisitHeight { get; set; }
    }   

    public class CreateTreatmentHistoryViewModel : TreatmentHistoryViewModel
    {
        [Display(Name = "SentToPharmacy", ResourceType = typeof(Global))]
        public int? PharmacyId { get; set; }

        public PatientHistoryInfoModel PatientHistory { get; set; } = new PatientHistoryInfoModel();
    }

    public class CreateSonarTreatmentHistoryViewModel : TreatmentHistoryViewModel
    {
        [Display(Name = "sonography", ResourceType = typeof(EnumResource))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int SonarCenterId { get; set; }

        [Display(Name = "Requests", ResourceType = typeof(Global))]       
        public List<int> SonarNeeds { get; set; }
    }

    public class CreateLabTreatmentHistoryViewModel : TreatmentHistoryViewModel
    {
        [Display(Name = "Laboratory", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int LabCenterId { get; set; }

        [Display(Name = "Requests", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public List<int> LabratoryNeeds { get; set; }
    }

    public class PrintTreatmentHistoryViewModel : TreatmentHistoryViewModel
    {
      
    }

    public class CreateTreatmentHistoryResultModel
    {
        public int TreatmentHistoryId { get; set; }
        public string PatientUniqueId { get; set; }
        public string PatientFullName { get; set; }
    }


    public class TreatmentsItemsGridViewModel : JGrid2BaseViewModel
    {
        [AwroGridWidth(Value = "30%")]
        [AwroGridOrder(Value = 0)]       
        [DropDownList(DataSource = "getDrugsList")]
        [Display(Name = "Drug", ResourceType = typeof(Global))]
        public int? DrugId { get; set; }

        [AwroGridWidth(Value = "20%")]
        [AwroGridOrder(Value = 1)]
        [Display(Name = "DrugName", ResourceType = typeof(Global))]
        public string CustomDrugName { get; set; }

        [AwroGridWidth(Value = "9%")]
        [AwroGridOrder(Value = 1)]
        [Display(Name = "Dose", ResourceType = typeof(Global))]
        public string Dose { get; set; }

        [AwroGridWidth(Value = "3%")]
        [AwroGridOrder(Value = 1)]
        [Display(Name = "Frequency", ResourceType = typeof(Global))]
        public string Frequency { get; set; }

        [AwroGridWidth(Value = "3%")]
        [AwroGridOrder(Value = 1)]
        [Display(Name = "Quantity", ResourceType = typeof(Global))]
        public string Quantity { get; set; }

        [AwroGridWidth(Value = "35%")]
        [AwroGridOrder(Value = 2)]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "")]
        [JGridRenderer(Name = "renderCustomDelete_ExpenseLedger")]
        public string CustomDelete { get; set; }
    }    
}