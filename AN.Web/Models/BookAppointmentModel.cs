using AN.Core.Enums;

namespace AN.Web.Areas.Public.Models
{
    public class BookAppointmentModel
    {
        public int ServiceSupplyId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Mobile { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }       
        public bool ExistUser { get; set; }
        public string ReservationTime { get; set; }       
        public string Captcharesponse { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int? PolyclinicHealthServiceId { get; set; }
        public string MyCaptcha { get; set; }
    }
}