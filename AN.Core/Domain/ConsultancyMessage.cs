using AN.Core.Data;
using AN.Core.Enums;
using System;

namespace AN.Core.Domain
{
    public class ConsultancyMessage : BaseEntity
    {
        public string Content { get; set; }

        public ConsultancyMessageType Type { get; set; }

        public ConsultancyMessageStatus Status { get; set; }

        public ConsultancyMessageSender Sender { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int ConsultancyId { get; set; }

        public int ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        public virtual Consultancy Consultancy { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual Person Person { get; set; }

    }
}
