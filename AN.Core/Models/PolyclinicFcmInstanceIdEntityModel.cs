using AN.Core.Enums;

namespace AN.Core.Models
{
    public partial class PolyclinicFcmInstanceIdEntityModel
    {
        public string FcmId { get; set; }
        public bool IsOn { get; set; } = true;
        public PolyclinicManagerNotificationSendingType SendingType { get; set; } = PolyclinicManagerNotificationSendingType.SEND_FOR_EACH_APPOINTMENT;

    }
}
