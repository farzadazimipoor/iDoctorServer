using System.Collections.Generic;

namespace AN.Core.DTO.Location
{
    public class PlaceDTO : BaseDTO
    {
        public string Name { get; set; }
    }

    public class CountryDTO : PlaceDTO
    {
        public List<ProvinceDTO> Provinces { get; set; }
    }

    public class ProvinceDTO : PlaceDTO
    {
        public int CountryId { get; set; }
        public List<CityDTO> Cities { get; set; }
    }

    public class CityDTO : PlaceDTO
    {
        public int ProvinceId { get; set; }
    }
}
