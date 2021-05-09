using AN.Core.Domain;
using System.Linq;

namespace AN.Web.Areas.Admin.Models
{
    public class ReportsViewModel
    {

    }


    public class DoctorAppointmentsViewModel
    {
        public string DoctorName { get; set; }

        public int AppointmentsCount { get; set; }
    }


    public class ObjResult
    {
        public ShiftCenter Polyclinic { get; set; }
        public Person Manager { get; set; }
        public IQueryable<Appointment> Appointments { get; set; }
           
    }

    public class PolyclinicsWithPendingAppointsModel
    {
        public ShiftCenter Polyclinic { get; set; }
        public string Manager { get; set; }
        public string Mobile { get; set; }
        public int Count { get; set; }
    }
}