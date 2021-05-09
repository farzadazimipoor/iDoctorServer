namespace AN.Core.DTO
{
    public class ShiftCenterDTO : BaseDTO
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int? ClinicId { get; set; }
    }
}
