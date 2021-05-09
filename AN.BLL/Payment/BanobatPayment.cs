using AN.Core.Models;

namespace AN.BLL.Payment
{
    public class BanobatPayment
    {
        protected long prePaymentAmount;
        protected long appointmentAmount;

        public BanobatPayment()
        {
            prePaymentAmount = 0;     //Rials
            appointmentAmount = 0; //Rials
        }



        /// <summary>
        /// دریافت وضعیت پرداخت برای هر نوبتی
        /// </summary>
        /// <param name="userPatientId">بیماری که نوبت را رزرو میکند</param>
        /// <param name="serviceSupplyId">پزشک یا خدمتی که نوبت برای ان رزرو می شود</param>
        /// <returns>وضعیت پرداخت شامل قیمت و دلیل پرداخت وجه</returns>
        public Pay GetPaymentStatus(string userMobile, int serviceSupplyId)
        {
            // CALCULATE PAYMENT STATUS HERE

            if(serviceSupplyId == 8787)
            {
                appointmentAmount = 1000;
            }

            return new Pay { PrePaymentAmount = prePaymentAmount, AppointmentAmount = appointmentAmount };
        }
    }
}
