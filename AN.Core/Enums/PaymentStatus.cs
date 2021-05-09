namespace AN.Core.Enums
{

    /// <summary>
    /// وضعیت پرداخت هزینه نوبت
    /// </summary>
    public enum PaymentStatus
    {


        /// <summary>
        /// کلا از طریق سیستم رایگان اعلام شده است
        /// </summary>
        Free = 0,




        /// <summary>
        /// با توجه به تعداد 
        /// </summary>
        FreeForPatient = 1,




        /// <summary>
        /// نوبت رایگان نبوده و منتظر پرداخت می باشد
        /// </summary>
        NotPayed = 2,



        /// <summary>
        /// نوبت رایگان نبوده و هزینه آن نیز پرداخت شده است
        /// </summary>
        Payed = 3

      
    }
}
