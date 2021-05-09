using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            TreatmentHistories = new HashSet<TreatmentHistory>();
            Invoices = new HashSet<Invoice>();
        }

        // Patient can be added for center or only a doctor of center
        public int? CenterId { get; set; }

        public int? ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        public virtual ShiftCenter ShiftCenter { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<TreatmentHistory> TreatmentHistories { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
