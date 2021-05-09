namespace AN.Core.Enums
{
    public enum HealthCenterType
    {
        /// <summary>
        /// اگر پزشکی در مطبی باشد که مستقل نباشد و مربوط به بیمارستان خاصی باشد
        /// </summary>
        Hospital = 0,

        /// <summary>
        /// اگر پزشکی در مطبی باشد که مستقل نباشد و مربوط به یک کلینیک مستقل باشد
        /// </summary>
        Clinic = 1,

        /// <summary>
        /// اگر پزشک فقط در یک مطب مستقل سرویس ارایه دهد
        /// </summary>
        Polyclinic = 2
    }
}
