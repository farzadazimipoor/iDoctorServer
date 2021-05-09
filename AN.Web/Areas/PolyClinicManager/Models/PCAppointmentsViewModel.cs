using AN.Core;
using AN.Core.Enums;
using AN.Core.ViewModels;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class PCAppointmentsViewModel
    {

    }

    public class PCListAppointmentsViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }        

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public AppointmentStatus Status { get; set; }

        public AppointmentUserModel User { get; set; }         
    }


    public class AppointmentUserModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string CallNumber { get; set; }        
    }

    public class ProccessAppointmentModel
    {
        public int?  Id { get; set; }
        public PersonInfoViewModel Person { get; set; }
        public TreatmentHistoryViewModel TreatmentHistory { get; set; }
    }     
}