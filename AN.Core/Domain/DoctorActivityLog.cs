using AN.Core.Data;
using AN.Core.Enums;
using System;

namespace AN.Core.Domain
{
    public class DoctorActivityLog : BaseEntity
    {        
        public DateTime Date { get; set; }
        
        public DoctorActivityAction Action { get; set; }
       
        public int ServiceSupplyId { get; set; }
       
        public virtual ServiceSupply ServiceSupply { get; set; }
    }
}
