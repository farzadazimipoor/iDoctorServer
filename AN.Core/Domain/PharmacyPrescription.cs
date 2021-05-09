using AN.Core.Data;
using AN.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Domain
{
    public class PharmacyPrescription : BaseEntity
    {
        public PharmacyPrescription()
        {
            DoneTreatments = new HashSet<PharmacyDoneTreatments>();
        }

        public int TreatmentHistoryId { get; set; }
      
        public int PharmacyId { get; set; }

        public PrescriptionStatus Status { get; set; }

        /// <summary>
        /// The doctor wants to know how old the patient was at the time of the referral
        /// </summary>
        public float? PatientVisitAge { get; set; } = 0;

        /// <summary>
        /// The doctor wants to know how weight the patient was at the time of the referral
        /// </summary>
        [Range(1, 500)] // Kilogram
        public float? PatientVisitWeight { get; set; }

        /// <summary>
        /// The doctor wants to know how height the patient was at the time of the referral
        /// </summary>
        [Range(1, 300)] // CM
        public float? PatientVisitHeight { get; set; }

        public virtual TreatmentHistory TreatmentHistory { get; set; }

        public virtual Pharmacy Pharmacy { get; set; }

        public virtual ICollection<PharmacyDoneTreatments> DoneTreatments { get; set; }
    }
}
