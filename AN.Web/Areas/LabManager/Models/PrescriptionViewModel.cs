using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Web.Areas.LabManager.Models
{
    public class LabratoryPrescriptionDetailsViewModel
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
        public List<int> LabNeedIds { get; set; }
        public List<string> LabNeeds { get; set; }
        public string PatientAvatar { get; set; }
    }
}
