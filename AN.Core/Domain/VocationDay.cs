using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class VocationDay : BaseEntity
    {       
        public DateTime Date { get; set; }

        public string DayOfWeek { get; set; }       

        public string Description { get; set; }            
    }
}
