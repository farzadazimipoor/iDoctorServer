namespace Identity.Core.Models
{
    public class AppSettings
    {
        public AwronoreSettings AwronoreSettings { get; set; }
    }

    public class AwronoreSettings
    {
        /// <summary>
        /// OTP(Verify Token) timeout in seconds
        /// </summary>
        public int OtpTimeOut { get; set; }
        public KurtenameSmsOptions KurtenameSmsOptions { get; set; }
    }

    public class KurtenameSmsOptions
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string SourceAddress { get; set; }
        public bool Unicode { get; set; }
    }
}
