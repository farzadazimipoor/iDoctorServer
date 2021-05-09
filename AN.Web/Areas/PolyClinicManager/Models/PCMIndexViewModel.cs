using AN.Web.Models;
using System.Collections.Generic;

namespace AN.Web.Areas.PolyClinicManager.Models
{

    public class PCMIndexViewModel
    {        
        public TodayQueueDashboard TodayQueue { get; set; }
        public int AllAppointmentsCount { get; set; }
        public int TodayAppointmentsCount { get; set; }
        public int PendingAppointsCount { get; set; }
        public int DoneAppointsCount { get; set; }
        public int CanceledAppointsCount { get; set; }
        public int PendingAppointsPercent { get; set; }
        public int DoneAppointsPercent { get; set; }
        public int CanceledAppointsPercent { get; set; }
        public List<DayAppointsStatistics> DaysAppoints { get; set; }

    }
   

    public class TodayQueueDashboard
    {
        public int Count { get; set; }
        public List<DashboardQueuePatient> Patients { get; set; }
    }


    public class DashboardQueuePatient
    {
        public string Name { get; set; }
        public string StartTime { get; set; }
    }



    public class PCDoctorStatusModel
    {
        public string DoctorName { get; set; }
        public int? NumberOfAppointments { get; set; }
        public bool? IsAutomaticScheduleEnabled { get; set; } = false;
        public bool? IsTodayEnable { get; set; }
    }

}