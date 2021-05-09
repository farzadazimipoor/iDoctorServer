using AN.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class IndexViewModel : CommonViewModel
    {
        public int HospitalsCount { get; set; }
        public int ClinicsCount { get; set; }
        public int PoliClinicsCount { get; set; }
        public int AllAppointmentsCount { get; set; }
        public int InProgressAppointmentsCount { get; set; }
        public int DoneAppointmentsountCount { get; set; }
        public int PendingAppointmentsCount { get; set; }
        public int CanceledAppointmentsCount { get; set; }
        public int AllUsersCount { get; set; }
        public int OnlineUsers { get; set; }
        public int TodayVisits { get; set; }
        public int TotallVisits { get; set; }
        public int UniquVisitors { get; set; }
        public ChannelReservationStatisticsViewModel ChannelReservationStatistics { get; set; } = new ChannelReservationStatisticsViewModel();
    }

    public class LatestReservedAppointment
    {
        public string ReservationDateTime { get; set; }
        public string VisitDateTime { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }

    public class CountryVisitsModel
    {
        public string CountryCode { get; set; }
        public int Visitors { get; set; }
    }

    public class BrowserVisitsTableViewModel
    {
        public string BrowserName { get; set; }
        public int BrowserViewCount { get; set; }
        public int TottalVisits { get; set; }
    }

    public class OsVisitsTableViewModel
    {
        public string OsName { get; set; }
        public int OsViewCount { get; set; }
        public int TottalVisits { get; set; }
    }

    public class ChannelReservationStatisticsViewModel
    {
        public int KioskAppointmentsCount { get; set; }
        public int WebsiteAppointmentsCount { get; set; }
        public int AndroidAppAppointmentsCount { get; set; }
        public int ReserveOutsideAppointmentsCount { get; set; }
        public int SMSAppointmentsCount { get; set; }
        public int VoipAppointmentsCount { get; set; }
        public int USSDAppointmentsCount { get; set; }
    }

    public class BlockedIpViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "IP", ResourceType = typeof(Core.Resources.Global.Global))]
        public string IpAddress { get; set; }
    }

}