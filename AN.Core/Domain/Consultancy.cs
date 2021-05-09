using AN.Core.Data;
using AN.Core.Enums;
using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Consultancy : BaseEntity
    {
        public Consultancy()
        {
            ConsultancyMessages = new HashSet<ConsultancyMessage>();
        }

        public ConsultancyStatus Status { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<ConsultancyMessage> ConsultancyMessages { get; set; }
    }
}
