using AN.Core.Enums;
using System;

namespace AN.BLL.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetLocalizedDayOfWeek(this DayOfWeek dayOfWeek, Lang lang)
        {
            if (lang == Lang.EN) return dayOfWeek.ToString();

            if (lang == Lang.KU)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Friday:
                        return "هەینی";
                    case DayOfWeek.Monday:
                        return "دووشەممە";
                    case DayOfWeek.Saturday:
                        return "شەممە ";
                    case DayOfWeek.Sunday:
                        return "یەکشەممە";
                    case DayOfWeek.Thursday:
                        return "پێنجشەمە";
                    case DayOfWeek.Tuesday:
                        return "سێشەممە";
                    case DayOfWeek.Wednesday:
                        return "چوارشەممە";
                    default:
                        return dayOfWeek.ToString();
                }
            }
            else if (lang == Lang.AR)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Friday:
                        return "الجمعة";
                    case DayOfWeek.Monday:
                        return "الإثنين";
                    case DayOfWeek.Saturday:
                        return "السبت";
                    case DayOfWeek.Sunday:
                        return "الأحد";
                    case DayOfWeek.Thursday:
                        return "الخميس";
                    case DayOfWeek.Tuesday:
                        return "الثلاثاء";
                    case DayOfWeek.Wednesday:
                        return "الأربعاء";
                    default:
                        return dayOfWeek.ToString();
                }
            }

            return dayOfWeek.ToString();
        }
    }
}
