using AN.Web.Models;
using System.Collections.Generic;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMIndexViewModel
    {
        public int PoliClinicsCount { get; set; }
        public int DoctorsCount { get; set; }
        public int TodayAppointsCount { get; set; }
        public int AppointmentsCount { get; set; }
        public int PendingAppointsCount { get; set; }
        public int DoneAppointsCount { get; set; }
        public int CanceledAppointsCount { get; set; }
        public int PendingAppointsPercent { get; set; }
        public int DoneAppointsPercent { get; set; }
        public int CanceledAppointsPercent { get; set; }
        public List<DayAppointsStatistics> DaysAppoints { get; set; }
        public int KioskAppointmentsCount { get; set; }
        public int WebsiteAppointmentsCount { get; set; }
        public int AndroidAppAppointmentsCount { get; set; }
        public int ReserveOutsideAppointmentsCount { get; set; }
        public int SMSAppointmentsCount { get; set; }
    }    
}