using AN.Core.Data;
using AN.Core.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class CenterPrescription : BaseEntity
    {
        public CenterPrescription()
        {
        }

        public int TreatmentHistoryId { get; set; }

        public int CenterId { get; set; }

        public string _SonarNeedIds { get; set; }
        [NotMapped]
        public List<int> SonarNeedIds
        {
            get { return _SonarNeedIds == null ? null : JsonConvert.DeserializeObject<List<int>>(_SonarNeedIds); }
            set { _SonarNeedIds = JsonConvert.SerializeObject(value); }
        }

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

        public virtual ShiftCenter Center { get; set; }
    }
}
