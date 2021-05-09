using AN.Core.Enums;

namespace AN.Core
{
    public static class SupportedLangs
    {
        public static string KU => "ku-Arab";
        public static string AR => "ar-SA";
        public static string EN => "en-US";

        public static string[] GetAllLangs
        {
            get
            {
                return new[]
                {
                    KU,
                    AR,
                    EN
                };
            }
        }

        public static Lang GetLang(string lang)
        {
            return lang == EN ? Lang.EN : (lang == KU ? Lang.KU : Lang.AR);
        }

        public static string GetLocaleCode(this Lang lang)
        {
            return lang == Lang.EN ? EN : lang == Lang.KU ? KU : AR;
        }
    }
}
