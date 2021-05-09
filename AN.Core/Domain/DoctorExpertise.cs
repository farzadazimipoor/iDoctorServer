using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class DoctorExpertise : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int ServiceSupplyId { get; set; }

        public int ExpertiseId { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual Expertise Expertise { get; set; }
    }
}
