using AN.Core;
using AN.Core.Enums;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{

    public class AppointmentApiModel
    {

        public int Id { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public AppointmentStatus Status { get; set; }

        public AppointmentPatient Patient { get; set; }

    }


    public class AppointmentPatient
    {
        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string CallNumber { get; set; }

    }


    public class AppointsForDateApiModel
    {
        public string Time { get; set; }
        public bool IsFree { get; set; }   
        public int AppointmentId { get; set; }    
    }


    public class SetAppointmentStatusModel
    {
        public int? PolyClinicId { get; set; }
        public int? AppointmentId { get; set; }
        public AppointmentStatus? Status { get; set; }
        /// <summary>
        /// این مورد برای نوبت های منتظر انجامی می باشد که لغو می شوند
        /// تا بفهمیم آیا نوبت بعد از لغو دوباره به لیست نوبت های خالی برگردد یا خیر؟
        /// </summary>
        public bool AllowReserveAgain { get; set; }
    }


    public class AppointmentsFilterModel
    {
        /// <summary>
        ///  0 = All
        ///  1 = Pending
        ///  2 = Done
        ///  3 = Canceled
        /// </summary>
        public int? CategoryId { get; set; } = 0;

        public string DateFrom { get; set; }

        public string DateTo { get; set; }
    }

}