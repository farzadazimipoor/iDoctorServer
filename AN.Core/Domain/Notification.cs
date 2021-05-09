using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class Notification : BaseEntity
    {
        public int? PersonId { get; set; }
        public string InstanceId { get; set; }
        public string Title { get; set; }
        public string Title_Ku { get; set; }
        public string Title_Ar { get; set; }
        public string Text { get; set; }
        public string Text_Ku { get; set; }
        public string Text_Ar { get; set; }
        public string Description { get; set; }
        public string Description_Ku { get; set; }
        public string Description_Ar { get; set; }
        public string PayloadJson { get; set; }
        public bool IsNeedToBeSeen { get; set; } = false;
        public bool IsSeen { get; set; } = true;
        public DateTime ValidUntil { get; set; }
        public string Image { get; set; }
    }
}
