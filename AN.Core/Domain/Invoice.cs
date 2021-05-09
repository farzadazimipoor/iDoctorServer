using AN.Core.Data;
using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();           
        }

        public DateTime VisitDate { get; set; }

        public string Description { get; set; }

        public int PatientId { get; set; }

        public int? AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
