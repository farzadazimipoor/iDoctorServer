namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class QueueApiModel
    {
        public string PatientUserId { get; set; }
        
        public string PatientName { get; set; }
        
        public string PatientMobile { get; set; }
        public int AppointmentId { get; set; }
        
        public string AppointmentDate { get; set; }
        
        public string AppointmentTime { get; set; }
    }
}