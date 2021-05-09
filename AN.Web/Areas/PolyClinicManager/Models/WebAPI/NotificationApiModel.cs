using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class NotificationApiModel
    {

    }

    public class AddFcmInstanceIdModel
    {
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string InstanceId { get; set; }
    }
}