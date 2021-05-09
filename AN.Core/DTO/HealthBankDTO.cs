using AN.Core.Enums;
using AN.Core.Models;
using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class HealthBankCategoryDTO
    {
        public HealthBankCategoryType Type { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public ShiftCenterType? CenterType { get; set; }
    }   

    public class HealthBankListItemDTO
    {
        public int Id { get; set; }
        public HealthBankCategoryType Type { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CenterType { get; set; }
        public string City { get; set; }
    }

    public class HealthBankItemsPagingResultDTO
    {
        public long TotalCount { get; set; }

        public List<HealthBankListItemDTO> Items { get; set; }
    }

    public class HealthBankItemDetailDTO : HealthBankListItemDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Annoucement { get; set; }
        public List<ImageUrlModel> Images { get; set; }
    }
}
