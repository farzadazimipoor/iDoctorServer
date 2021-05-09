using System;
using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class NotificationListItemDTO : BaseDTO
    {
        public string Image { get; set; }      
        public string Title { get; set; }
        public string TitleKu { get; set; }
        public string TitleAr { get; set; }
        public string Text { get; set; }
        public string TextKu { get; set; }
        public string TextAr { get; set; }
        public string Description { get; set; }
        public string DescriptionKu { get; set; }
        public string DescriptionAr { get; set; }
        public string PayloadJson { get; set; }
        public bool IsExpired { get; set; } 
        public DateTime CreatedAt { get; set; }        
    }

    public class NotificationsResultDTO
    {
        public long TotalCount { get; set; }
        public List<NotificationListItemDTO> Notifications { get; set; }
    }
}
