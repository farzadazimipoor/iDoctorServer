using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class PharmacyDoneTreatments : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int TreatmentId { get; set; }

        public int PharmacyPrescriptionId { get; set; }

        public virtual PharmacyPrescription PharmacyPrescription { get; set; }
    }
}
