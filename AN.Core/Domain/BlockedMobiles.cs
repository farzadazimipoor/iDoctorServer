using AN.Core.Data;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Domain
{
    public class BlockedMobiles : BaseEntity
    {
        [MaxLength(10), MinLength(10)]
        public string Mobile { get; set; }
        
        public string Description { get; set; }

        public int ShiftCenterId { get; set; }
       
        public virtual ShiftCenter ShiftCenter { get; set; }

    }
}
