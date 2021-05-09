using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace AN.Web.Helper
{
    public static class GoogleCaptchaHelper
    {
        public static IHtmlContent GoogleReCaptcha(this IHtmlHelper htmlHelper, string siteKey, string callback = null)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.Attributes.Add("class", "g-recaptcha");
            tagBuilder.Attributes.Add("data-sitekey", siteKey);
            if (callback != null && string.IsNullOrWhiteSpace(callback))
            {
                tagBuilder.Attributes.Add("data-callback", callback);
            }
            using (var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                var htmlOutput = writer.ToString();
                return htmlHelper.Raw(htmlOutput);
            }
        }
    }
}
