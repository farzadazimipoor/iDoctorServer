using AN.Core;
using AN.Core.Enums;
using System.Globalization;
using System.Threading;

namespace AN.Web.Helper
{
    public class CultureHelper
    {    
        // Properties  
        public static string CurrentCulture
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;

                return currentCulture.Name;                         
            }
            set
            {
                var enCulture = new CultureInfo(SupportedLangs.EN);

                var newCulture = new CultureInfo(value)
                {
                    DateTimeFormat = enCulture.DateTimeFormat
                };

                Thread.CurrentThread.CurrentCulture = newCulture;

                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
        }

        public static string CurrentCultureName => Thread.CurrentThread.CurrentCulture.Name ?? SupportedLangs.KU;

        public static Lang Lang => SupportedLangs.GetLang(CurrentCultureName);
    }
}