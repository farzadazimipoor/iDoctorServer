namespace AN.Core.Models
{
    public class Pay
    {
        /// <summary>
        /// مبلغ پیش پرداخت پزشک
        /// </summary>
        public long PrePaymentAmount { get; set; } = 0;

        /// <summary>
        /// مبلغ هزینه رزرو نوبت
        /// </summary>
        public long AppointmentAmount { get; set; }
    }
}
