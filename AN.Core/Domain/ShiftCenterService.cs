using AN.Core.Data;
using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class ShiftCenterService : BaseEntity
    {
        public ShiftCenterService()
        {
            Schedules = new HashSet<Schedule>();
            Appointments = new HashSet<Appointment>();          
            UsualSchedulePlans = new HashSet<UsualSchedulePlan>();
            Offers = new HashSet<Offer>();
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public CurrencyType CurrencyType { get; set; } = CurrencyType.USD;

        public decimal? Price { get; set; }

        public decimal? PriceWithDiscount { get; set; }

        public string Note { get; set; }
        public string Note_Ku { get; set; }
        public string Note_Ar { get; set; }

        public int ShiftCenterId { get; set; }

        public int HealthServiceId { get; set; }       
       
        public virtual ShiftCenter ShiftCenter { get; set; }
       
        public virtual Service Service { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }      
        public virtual ICollection<UsualSchedulePlan> UsualSchedulePlans { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
