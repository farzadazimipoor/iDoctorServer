namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMDoctorsViewModel
    {
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int PendingAppointments { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public string Polyclinic { get; set; }
        public int ServiceSupplyId { get; set; }
    }
}