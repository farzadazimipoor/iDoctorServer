using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class SettingsApiModel
    {
       
    }

    public class NotificationSettingsApiModel
    {
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string FcmId { get; set; }
        public bool IsOn { get; set; }
        public int NotificationType { get; set; }
    }
}