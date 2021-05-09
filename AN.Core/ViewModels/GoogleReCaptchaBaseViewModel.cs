using Microsoft.AspNetCore.Mvc;

namespace AN.Core.ViewModels
{
    public class GoogleReCaptchaBaseViewModel
    {
        // [Required]
        // [GoogleReCaptchaValidation]
        [BindProperty(Name = "g-recaptcha-response")]
        public string GoogleReCaptchaResponse { get; set; }
    }
}
