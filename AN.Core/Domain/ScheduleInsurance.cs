using AN.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class ScheduleInsurance : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Key, Column(Order = 0)]
        public int ScheduleId { get; set; }

        [Key, Column(Order = 1)]
        public int ServiceSupplyInsuranceId { get; set; }

        public int AdmissionCapacity { get; set; }

        public string Description { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual ServiceSupplyInsurance Insurance { get; set; }
    }
}
