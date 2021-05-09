using AN.Core.DTO.Doctors;
using AN.Core.Enums;

namespace AN.Core.DTO.Location
{
    public class NearByDoctorDTO : BaseDTO
    {
        public string FullName { get; set; }
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public double X_Longitude { get; set; }
        public double Y_Latitude { get; set; }
        public double Distance { get; set; }
        public string Avatar { get; set; }
        public string ExpertiseCategory { get; set; }
        public double AverageRating { get; set; }
        public bool HasEmptyTurn { get; set; }
        public ReservationType ReservationType { get; set; }
        public int? CenterServiceId { get; set; } = null;
        public string Service { get; set; }
        public DoctorTimePeriods TimePeriods { get; set; }
    }    
}
