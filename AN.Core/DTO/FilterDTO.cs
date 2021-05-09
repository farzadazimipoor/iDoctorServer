using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class FilterDTO
    {
        public List<Location.CountryDTO> Countries { get; set; }
        public List<Location.CityDTO> Cities { get; set; }
        public List<HospitalDTO> Hospitals { get; set; }       
        public List<ClinicDTO> Clinics { get; set; }
        public List<ExpertiseCategoryDTO> ExpertiseCategories { get; set; }
        public List<ExpertiseDTO> Expertises { get; set; }
        public List<InsuranceItemDTO> Insurances { get; set; }
    }

    public class ServicesFilterDTO
    {
        public List<ServiceCategoryDTO> ServiceCategories { get; set; }
        public List<ServiceDTO> Services { get; set; }
        public string ConsultancyDisclaimer { get; set; }
    }
}
