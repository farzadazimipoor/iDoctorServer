using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class EventLog : BaseEntity
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IP { get; set; }
        public string Parameters { get; set; }       
        public DateTime Date { get; set; }
    }
}
