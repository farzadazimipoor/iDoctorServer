using AN.Core;
using AN.Core.Enums;
using System;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMMessageViewModel
    {
        public string RecipientName { get; set; }
        public string RecipientNumber { get; set; }
        public DateTime SendingDate { get; set; }
        public string PolyclinicName { get; set; }
        public string DoctorName { get; set; }
        public long DeliveryStatus { get; set; }
        public MessageActionAbout About { get; set; }
    }
}