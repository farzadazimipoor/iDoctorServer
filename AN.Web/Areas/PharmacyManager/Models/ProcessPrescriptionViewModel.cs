using AN.Core.Models;
using System.Collections.Generic;

namespace AN.Web.Areas.PharmacyManager.Models
{
    public class ProcessPrescriptionViewModel
    {
        public int Id { get; set; }
        public string HealthCenterName { get; set; }
        public string HealthCenterPhone { get; set; }
        public string HealthCenterAddress { get; set; }
        public string DoctorName { get; set; }
        public string DoctorExpertise { get; set; }
        public string PatientName { get; set; }
        public string VisitDate { get; set; }
        public string Problems { get; set; }
        public List<PrintPrescriptTreatmentsModel> Treatments { get; set; }
        public string Instructions { get; set; }
    }   
}
