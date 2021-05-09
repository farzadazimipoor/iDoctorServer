namespace Identity.Core.Enums
{
    public enum AwronoreIdentityErrorCode
    {
        Unknown = 700,

        /// <summary>
        /// User try to get another otp before timeout
        /// </summary>
        OtpHasBeenSent = 701,

        CaptchaResponseRequired = 702,

        CaptchaResponseValidationFailed = 703,

        DeleteUsedItem = 704
    }
}
