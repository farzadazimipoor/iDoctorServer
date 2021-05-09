using System.Collections.Generic;

namespace AN.Core.ViewModels
{
    public class CenterAppointmentsDashboardModel
    {
        public int AllAppointmentsCount { get; set; }
        public int TodayAppointmentsCount { get; set; }
        public int PendingAppointsCount { get; set; }
        public int DoneAppointsCount { get; set; }
        public int CanceledAppointsCount { get; set; }
        public List<(string Date, int Counts)> DaysAppoints { get; set; }
    }    
}
