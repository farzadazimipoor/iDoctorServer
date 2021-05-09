using AN.Core.Data;
using AN.Core.Enums;
using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Offer : BaseEntity
    {
        public Offer()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Photo { get; set; }
        public string Photo_Ku { get; set; }
        public string Photo_Ar { get; set; }

        public string Title { get; set; }
        public string Title_Ku { get; set; }
        public string Title_Ar { get; set; }

        public string Summary { get; set; }
        public string Summary_Ku { get; set; }
        public string Summary_Ar { get; set; }

        public string Description { get; set; }
        public string Description_Ku { get; set; }
        public string Description_Ar { get; set; }

        public double? DiscountPercentange { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? CurrentPrice { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public bool ShowDiscountBanner { get; set; } = true;

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int? MaxCount { get; set; }

        public int? RemainedCount { get; set; }

        public OfferStatus Status { get; set; }

        public string Code { get; set; }

        public OfferType Type { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime ExpiredAt { get; set; }
       
        public bool SendNotification { get; set; }
       
        public string NotificationTitle { get; set; }
       
        public string NotificationTitle_Ku { get; set; }
       
        public string NotificationTitle_Ar { get; set; }
        
        public string NotificationBody { get; set; }
       
        public string NotificationBody_Ku { get; set; }
       
        public string NotificationBody_Ar { get; set; }

        /// <summary>
        /// Each time user tapped on offer to see description increase this
        /// </summary>
        public long VisitsCount { get; set; } = 0;

        public int ServiceSupplyId { get; set; }

        public int? ShiftCenterServiceId { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual ShiftCenterService ShiftCenterService { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
