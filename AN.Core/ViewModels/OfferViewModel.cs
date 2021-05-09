using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class OfferCreateUpdateViewModel
    {
        public int? Id { get; set; } = null;

        #region Title       
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ku { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ar { get; set; }
        #endregion

        #region Summary       
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary_Ku { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary_Ar { get; set; }
        #endregion        

        [Display(Name = "DiscountPercentange", ResourceType = typeof(Global))]
        public double? DiscountPercentange { get; set; }

        [Display(Name = "OldPrice", ResourceType = typeof(Global))]
        public decimal? OldPrice { get; set; }

        [Display(Name = "CurrentPrice", ResourceType = typeof(Global))]
        public decimal? CurrentPrice { get; set; }

        [Display(Name = "ShowDiscountBanner", ResourceType = typeof(Global))]
        public bool ShowDiscountBanner { get; set; }

        public CurrencyType CurrencyType { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public DateTime StartAt { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public DateTime ExpiredAt { get; set; }

        [Display(Name = "Center", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ShiftCenterId { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Global))]       
        public string Date { get; set; }

        [Display(Name = "FromTime", ResourceType = typeof(Global))]        
        public string StartTime { get; set; }

        [Display(Name = "ToTime", ResourceType = typeof(Global))]        
        public string Endtime { get; set; }

        [Display(Name = "MaxCapacity", ResourceType = typeof(Global))]
        [Range(1, 1000, ErrorMessageResourceName = "Range1And1000", ErrorMessageResourceType = typeof(Global))]        
        public int? MaxCount { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(500, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength500")]
        public string Description { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int ServiceSupplyId { get; set; }

        [Display(Name = "Service", ResourceType = typeof(Global))]       
        public int? ShiftCenterServiceId { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload_Ku { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Global))]
        public IFormFile ImageUpload_Ar { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Global))]
        public OfferType Type { get; set; }

        [Display(Name = "SendNotification", ResourceType = typeof(Global))]
        public bool SendNotification { get; set; }

        #region Notification
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string NotificationTitle { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string NotificationTitle_Ku { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string NotificationTitle_Ar { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string NotificationBody { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string NotificationBody_Ku { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string NotificationBody_Ar { get; set; } 
        #endregion
    }

    public class OfferListViewModel
    {
        [SearchableInt]
        [Sortable]
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "CreateDate", ResourceType = typeof(Global))]       
        public string Date { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "FromTime", ResourceType = typeof(Global))]
        public string StartTime { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "ToTime", ResourceType = typeof(Global))]
        public string EndTime { get; set; }

        [SearchableString]
        [Sortable]
        [Display(Name = "Status", ResourceType = typeof(Global))]
        public string Status { get; set; }

        [SearchableString]
        [Sortable]
        [Display(Name = "Center", ResourceType = typeof(Global))]
        public string CenterName { get; set; }

        [SearchableString]
        [Sortable]
        [Display(Name = "Type", ResourceType = typeof(Global))]
        public string Type { get; set; }

        public OfferStatus OfferStatus { get; set; }

        [Display(Name = "Visits", ResourceType = typeof(Global))]
        public long Visits { get; set; }

        [Display(Name = "Appointments", ResourceType = typeof(Global))]
        public long Appointments { get; set; }
        
        public string ActionsHtml { get; set; }
    }
}
