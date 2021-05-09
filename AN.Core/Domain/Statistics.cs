using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class Statistics : BaseEntity
    {       
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string UserOs { get; set; }
        public string Referer { get; set; }
        public string PageViewed { get; set; }
        public DateTime DateStamp { get; set; }
    }
}
