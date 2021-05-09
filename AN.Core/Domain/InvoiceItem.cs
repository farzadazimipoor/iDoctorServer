using AN.Core.Data;

namespace AN.Core.Domain
{
    public class InvoiceItem : BaseEntity
    {        
        public int InvoiceId { get; set; }

        public int? ShiftCenterCerviceId { get; set; }

        public string CustomServiceName { get; set; }

        public decimal Price { get; set; }

        public string Note { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual ShiftCenterService ShiftCenterService { get; set; }
    }
}
