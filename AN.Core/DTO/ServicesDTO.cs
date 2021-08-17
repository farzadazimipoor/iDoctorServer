using AN.Core.Enums;

namespace AN.Core.DTO
{
    public class ServiceCategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public ShiftCenterType CenterType { get; set; }
    }

    public class ServiceDTO : BaseDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Price { get; set; }
        public string CurrencyType { get; set; }
        public ShiftCenterType CategoryCenterType { get; set; }
    }

    public class CenterServiceDTO : ServiceDTO
    {
        public int CenterServiceId { get; set; }
        public int CenterId { get; set; }
    }
}
