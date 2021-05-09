using AN.Core.Data;
using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class TreatmentHistory : BaseEntity
    {
        public TreatmentHistory()
        {
            TreatmentsItems = new HashSet<TreatmentsItems>();
            PharmacyPrescriptions = new HashSet<PharmacyPrescription>();
            Prescriptions = new HashSet<CenterPrescription>();
        }
        
        public DateTime VisitDate { get; set; }
       
        public string Problems { get; set; }
        public string Problems_Ku { get; set; }       
        public string Problems_Ar { get; set; }
        
        public string Treatments { get; set; }       
        public string Treatments_Ku { get; set; }       
        public string Treatments_Ar { get; set; }
      
        public string Description { get; set; }       
        public string Description_Ku { get; set; }       
        public string Description_Ar { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }             

        public int? AppointmentId { get; set; }
       
        public virtual Appointment Appointment { get; set; }

        public virtual PastMedicalHistory PastMedicalHistory { get; set; }

        public virtual ICollection<TreatmentsItems> TreatmentsItems { get; set; }

        public virtual ICollection<PharmacyPrescription> PharmacyPrescriptions { get; set; }

        public virtual ICollection<CenterPrescription> Prescriptions { get; set; }
    }
}
