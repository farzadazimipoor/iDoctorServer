using AN.Core.Enums;
using AN.Core.Models;
using System.Collections.Generic;

namespace AN.Core.DTO.Doctors
{
    public class DoctorTimePeriods
    {
        public List<TimePeriodModel> TimePeriods { get; set; } = new List<TimePeriodModel>();
        public bool HasOffers { get; set; } = false;
    }

    public class DoctorListItemDTO : BaseDTO
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool HasEmptyTurn { get; set; }
        public string ExpertiseCategory { get; set; }
        public string Address { get; set; }
        public double AverageRating { get; set; }
        public ReservationType ReservationType { get; set; }
        public int? CenterServiceId { get; set; } = null;
        public string Service { get; set; }
        public DoctorTimePeriods TimePeriods { get; set; }
        public ShiftCenterType CenterType { get; set; }
        public bool ConsultancyEnabled { get; set; }
        public bool CanRequestTurn { get; set; }
    }

    public class DoctorsResultDTO
    {
        public long TotalCount { get; set; }
        public List<DoctorListItemDTO> Doctors { get; set; }
    }

    public class DoctorFilterDTO
    {
        public ShiftCenterType CenterType { get; set; } = ShiftCenterType.Polyclinic;
        public int? CityId { get; set; }
        public int? HospitalId { get; set; }
        public int? ClinicId { get; set; }
        public int? SpecialityId { get; set; }
        public int? SubSpecialityId { get; set; }
        public List<int> Expertises { get; set; }
        public string FilterString { get; set; }
        public bool HaveTurns { get; set; }
        public int? ServiceId { get; set; }
        public bool? ConsultancyEnabled { get; set; }
        public int? InsuranceId { get; set; }
    }

    public class DoctorDetailsDTO : DoctorListItemDTO
    {
        public TurnModel FirstAvailableTurn { get; set; }
        public long Rank { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string ReservationType { get; set; }
        public string Notification { get; set; }
        public List<string> Photos { get; set; }
        public List<string> PhotosThumbs { get; set; }
        public List<string> Expertises { get; set; }
        public List<string> Grades { get; set; }
        public List<ShiftCenterPhoneModel> Phones { get; set; }
        public List<DoctorCenterModel> WorkingCenters { get; set; }
        public DoctorScheduleInfoDTO Schedules { get; set; }
    }

    public class DoctorReservationStatusDTO : BaseDTO
    {
        public int CenterServiceId { get; set; }
        public bool HasAvailableTurn { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public ReservationType ReservationType { get; set; }
        public string FirstTurnDate { get; set; }
        public List<TurnModel> BookableTurns { get; set; }

        /// <summary>
        /// This is for doctors who are not in the system and we want to allow users to request turnovers.
        /// </summary>
        public bool CanRequestTurn { get; set; } = false;
    }

    public class DateBookableTurnsDTO
    {
        public int TotalCount { get; set; }
        public List<TurnModel> BookableTurns { get; set; }
    }

    public class CenterTypeDTO
    {
        public string Title { get; set; }
        public string IconPath { get; set; }
        public ShiftCenterType CenterType { get; set; }
    }
}
