using AN.Core;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AN.Web.App_Code
{
    /// <summary>
    /// We must send each of this langs with reaust header
    /// </summary>
    public class LanguageMessageHandler : DelegatingHandler
    {       
        private readonly List<string> _supportedLanguages = new List<string> { SupportedLangs.KU, SupportedLangs.AR, SupportedLangs.EN };

        private bool SetHeaderIfAcceptLanguageMatchesSupportedLanguage(HttpRequestMessage request)
        {
            foreach (var lang in request.Headers.AcceptLanguage)
            {
                if (_supportedLanguages.Contains(lang.Value))
                {
                    SetCulture(request, lang.Value);
                    return true;
                }
            }

            return false;
        }

        private bool SetHeaderIfGlobalAcceptLanguageMatchesSupportedLanguage(HttpRequestMessage request)
        {
            foreach (var lang in request.Headers.AcceptLanguage)
            {
                var globalLang = lang.Value.Substring(0, 2);
                if (_supportedLanguages.Any(t => t.StartsWith(globalLang)))
                {
                    SetCulture(request, _supportedLanguages.FirstOrDefault(i => i.StartsWith(globalLang)));
                    return true;
                }
            }

            return false;
        }

        private void SetCulture(HttpRequestMessage request, string lang)
        {
            request.Headers.AcceptLanguage.Clear();

            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(lang));

            var enCulture = new CultureInfo(SupportedLangs.EN);

            var currentCulture = new CultureInfo(lang)
            {
                DateTimeFormat = enCulture.DateTimeFormat
            };

            Thread.CurrentThread.CurrentCulture = currentCulture;

            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!SetHeaderIfAcceptLanguageMatchesSupportedLanguage(request))
            {
                // Whoops no localization found. Lets try Globalisation
                if (!SetHeaderIfGlobalAcceptLanguageMatchesSupportedLanguage(request))
                {
                    // no global or localization found
                    SetCulture(request, SupportedLangs.KU);
                }
            }

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}