using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class PharmacyItemDTO : BaseDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }       
    }

    public class PharmaciesResultDTO
    {
        public long TotalCount { get; set; }
        public List<PharmacyItemDTO> Pharmacies { get; set; }
    }
}
