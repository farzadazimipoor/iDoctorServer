using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class DoctorScientificCategory : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int ServiceSupplyId { get; set; }

        public int ScientificCategoryId { get; set; }

        public virtual ServiceSupplyInfo ServiceSupplyInfo { get; set; }

        public virtual ScientificCategory ScientificCategory { get; set; }
    }
}
