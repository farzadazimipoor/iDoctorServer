using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Web.Models
{
    public class ReserveTurnViewModel
    {       
        public int DoctorId { get; set; }
        public int HealthServiceId { get; set; }
        public ReservationType ReservationType { get; set; }
        public DoctorDetailsViewModel DoctorDetails { get; set; }
        public TurnItemModel FirstTurn { get; set; }
        public SelectiveReserveViewModel SelectiveTurn { get; set; }
        public List<SelectListModel> HealthServices { get; set; }
    }

    public class TurnItemModel
    {
        public string Date { get; set; }
        public string DayOfWeek { get; set; }       
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

    public class SelectiveReserveViewModel
    {      
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public List<string> ActiveDates { get; set; }
    }

    public class SelectListModel
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }

    public class FinalBookTurnDTO
    {
        public int DoctorId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Mobile { get; set; }
        public int PolyclinicHealthServiceId { get; set; }
    }

    public class FinalBookResultDTO
    {
        public string Message { get; set; }
        public long AppointmentId { get; set; }
        public int QueueNumber { get; set; }               
    }
}