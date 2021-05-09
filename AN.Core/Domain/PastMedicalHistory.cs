using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class PastMedicalHistory : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int TreatmentHistoryId { get; set; }

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

        public virtual TreatmentHistory TreatmentHistory { get; set; }
    }
}
