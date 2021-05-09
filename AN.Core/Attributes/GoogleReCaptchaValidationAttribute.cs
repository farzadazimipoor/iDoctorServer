using AN.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;

namespace AN.Core.Attributes
{
    public class GoogleReCaptchaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Lazy<ValidationResult> errorResult = new Lazy<ValidationResult>(() => new ValidationResult("Google reCAPTCHA validation failed", new string[] { validationContext.MemberName }));

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                throw new AwroNoreException(Enums.AwroNoreErrorCode.ReCaptchaRequired, "Google reCAPTCHA is required");
            }

            IConfiguration configuration = (IConfiguration)validationContext.GetService(typeof(IConfiguration));
            string reCaptchResponse = value.ToString();
            string reCaptchaSecret = configuration.GetValue<string>("GoogleReCaptcha:SecretKey");
            using (var httpClinet = new HttpClient())
            {
                var httpResponse = httpClinet.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={reCaptchaSecret}&response={reCaptchResponse}").Result;
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new AwroNoreException(Enums.AwroNoreErrorCode.ReCaptchaNotValid, "Google reCAPTCHA validation failed");
                }
                string jsonResponse = httpResponse.Content.ReadAsStringAsync().Result;
                dynamic jsonData = JObject.Parse(jsonResponse);
                if (jsonData.success != true.ToString().ToLower())
                {
                    throw new AwroNoreException(Enums.AwroNoreErrorCode.ReCaptchaNotValid, "Google reCAPTCHA validation failed");
                }
            }

            return ValidationResult.Success;
        }
    }
}
