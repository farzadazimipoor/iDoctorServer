namespace AN.Core.Enums
{
    public enum AwroNoreErrorCode
    {
        AwroNoreException = 700,

        /// <summary>
        /// شماره موبایل قبلا برای شخص دیگری ثبت شده است
        /// </summary>
        ExistMobileNumber = 701,

        /// <summary>
        /// زمانبندی معتبر یافت نشد
        /// </summary>
        NoValidScheduleFound = 702,

        /// <summary>
        /// هنگام تلاش برای دریافت توکن جهت ارسال به کاربر با خطا مواجه می شویم
        /// </summary>
        NoTokenObtained = 703,

        /// <summary>
        /// پزشک فعال نمی باشد
        /// </summary>
        DoctorIsNotAvailable = 704,

        /// <summary>
        /// زمان نوبت گذشته و امکان رزرو آن وجود ندارد
        /// </summary>
        TurnTimePastTime = 705,

        /// <summary>
        /// تاریخ انتخاب شده خارج از بازه زمانی روزهای فعال پزشک می باشد
        /// </summary>
        DateOutOfAvailableDatesRange = 706,

        /// <summary>
        /// BOOKING RESTRICTION HOURS
        /// زمان انتخاب نوبت برای تاریخ موردنظر گذشته است
        /// ساعات محدودیت رزرو
        /// </summary>
        ReservationTimePastForDate = 707,

        /// <summary>
        /// نوبت در حال رزرو می باشد
        /// </summary>
        TurnIsInProgress = 708,

        /// <summary>
        /// بیمار برای تاریخ موردنظر برای یک پزشک نوبت رزرو کرده است
        /// </summary>
        HaveAppointmentForDate = 709,

        /// <summary>
        /// اولین نوبت خالی قابل رزرو در یک تاریخ مشخص یافت نشد
        /// </summary>
        FirstEmptyTurnNotFoundInDate = 710,

        /// <summary>
        /// کلانیتی که به وب سرویس دسترسی پیدا کرده است معتبر نمی باشد
        /// </summary>
        ClientIsNotValid = 711,

        /// <summary>
        /// خدمتی برای مطب یافت نشد
        /// </summary>
        NoHealthServiceFounded = 712,

        /// <summary>
        /// مقدار فیلد ایمیل کاربر خالی می باشد.هنگام بازیابی رمز عبور برای کاربر باید حتما ایمیل خالی نباشد
        /// </summary>
        UserEmailIsNull = 713,

        /// <summary>
        /// برای کاربر شماره موبایل تعریف نشده است
        /// </summary>
        UserMobileIsNull = 714,

        /// <summary>
        /// هنگام ثبت نام یا بازیابی رمز عبور کاربران از طریق اپلیکیشن برنامه اقدام به ورود خودکار میکند. اگر ورود خودکار با خطا مواجه شود؟
        /// </summary>
        AutoLoginFailed = 715,

        /// <summary>
        /// کد امنیتی ارسال شده به تلفن همراه معتبر نمی باشد
        /// </summary>
        SecurityCodeNotValid = 716,

        /// <summary>
        /// پزشک نوبت خالی ندارد
        /// </summary>
        AllTurnsReserved = 717,

        DeleteUsedItem = 718,

        AccessDenied = 719,

        ReCaptchaRequired = 720,

        ReCaptchaNotValid = 721,

        DatabaseConnectionError = 722
    }
}
