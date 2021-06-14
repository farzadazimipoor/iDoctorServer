using AN.Core.Enums;
using System;
using System.Collections.Generic;

namespace AN.Core.DTO.Turn
{
    public class FinalBookTurnDTO
    {
        public int ServiceSupplyId { get; set; }
        public int CenterServiceId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? OfferId { get; set; } = null;
        /// <summary>
        /// This is for doctors who are not in the system and we want to allow users to request turnovers.
        /// </summary>
        public bool IsRequested { get; set; } = false;
        public double Xlongitude { get; set; }
        public double Ylatitude { get; set; }
    }   

    public class FinalBookTurnResultDTO
    {
        public bool IsSucceeded { get; set; }
        public int TurnId { get; set; }
        public int QueueNumber { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string TrackingCode { get; set; }
        public string OfferCode { get; set; } = string.Empty;
        /// <summary>
        /// This is for doctors who are not in the system and we want to allow users to request turnovers.
        /// </summary>
        public bool IsRequested { get; set; } = false;
    }

    public class UserTurnsFilterDTO
    {
        public string UserMobile { get; set; }
        public string FilterString { get; set; }
        public AppointmentStatus? Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public ShiftCenterType? CenterType { get; set; }
    }

    public class UserTurnItemDTO : BaseDTO
    {
        public string DayOfWeek { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAvatar { get; set; }
        public string DoctorExpertiseCategory { get; set; }
        public double DoctorRank { get; set; }
        public int ServiceSupplyId { get; set; }
        public bool IsRated { get; set; }
        public double? AverageRating { get; set; }
        public string TrackingCode { get; set; }
        public int CenterServiceId { get; set; }
        public string Service { get; set; }
    }

    public class UserTurnsResultDTO
    {
        public long TotalCount { get; set; }
        public List<UserTurnItemDTO> Turns { get; set; }
    }

    public class TurnTimePeriodDTO
    {
        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public TimePeriodType Type { get; set; }

        public int Duration { get; set; }

        public string TypeName { get; set; }
    }
}
