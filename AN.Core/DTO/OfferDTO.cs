using AN.Core.DTO.Doctors;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Models;
using System;
using System.Collections.Generic;

namespace AN.Core.DTO
{
    /// <summary>
    /// Service Category entity
    /// </summary>
    public class OfferCategoryDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public bool IsTrending { get; set; }
        public List<MySelectListItem> Services { get; set; }
    }

    /// <summary>
    /// Offer entity
    /// </summary>
    public class OfferItemDTO : BaseDTO
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public double? DiscountPercentange { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? CurrentPrice { get; set; }

        public string CurrencyType { get; set; }

        public bool ShowDiscountBanner { get; set; } = true;

        public int ServiceSupplyId { get; set; }

        public DoctorListItemDTO ServiceSupply { get; set; }

        public int ShiftCenterServiceId { get; set; }      

        public List<string> Photos { get; set; }

        public string Photo { get; set; }

        public long VisitsCount { get; set; } = 0;

        public long AppointmentsCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class OffersDataDTO
    {
        public List<OfferItemDTO> SlideShow { get; set; }
        public List<OfferCategoryDTO> Categories { get; set; }
        public List<OfferItemDTO> TrendingNow { get; set; }
        public List<OfferItemDTO> All { get; set; }
        public OffersFilterDataDTO FiltersData { get; set; }
    }

    public class OffersResultDTO
    {
        public long TotalCount { get; set; }
        public List<OfferItemDTO> Offers { get; set; }
    }

    public class OfferTimePeriodsDTO : BaseDTO
    {
        public int ServiceSupplyId { get; set; }
        public int ShiftCenterServiceId { get; set; }
        public string Date { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int MaxCount { get; set; }
        public int RemainedCount { get; set; }
        public string Code { get; set; }
        public List<TurnTimePeriodDTO> TimePeriods { get; set; }
    }

    public class OffersFilterDTO
    {
        public int? ServiceCategoryId { get; set; }
        public int? ServiceId { get; set; }
        public OfferSort? SortBy { get; set; }
        public SortDir SortDir { get; set; } = SortDir.ASC;
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CityId { get; set; }
    }

    public class OffersFilterDataDTO
    {
        public List<MySelectListItem> SortBy { get; set; }
        public List<MySelectListItem> SortDir { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
