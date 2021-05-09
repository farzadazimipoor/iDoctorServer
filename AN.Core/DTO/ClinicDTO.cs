namespace AN.Core.DTO
{
    public class ClinicDTO : BaseDTO
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        public int? HospitalId { get; set; }
    }
}
