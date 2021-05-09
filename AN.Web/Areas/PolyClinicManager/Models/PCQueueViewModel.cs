using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models
{
    public class PCQueueViewModel
    {
        public string PatientUserId { get; set; }
        [Display(Name ="PatientName", ResourceType = typeof(Core.Resources.UI.AdminPanel.PanelResource))]
        public string PatientName { get; set; }
        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.Global.Global))]
        public string PatientMobile { get; set; }
        public int AppointmentId { get; set; }
        [Display(Name = "Date", ResourceType = typeof(Core.Resources.Global.Global))]
        public string AppointmentDate { get; set; }
        [Display(Name = "Time", ResourceType = typeof(Core.Resources.Global.Global))]
        public string AppointmentTime { get; set; }
    }
}