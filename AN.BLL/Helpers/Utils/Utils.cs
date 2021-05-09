using AN.Core;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AN.BLL.Helpers
{
    public static class Utils
    {
        public static string GetUniqueKey(int size = 8, bool includeLetters = true)
        {
            var crypto = new RNGCryptoServiceProvider();
            var source = "1234567890";
            if (includeLetters)
            {
                source = $"abcdefghijklmnopqrstuvwxyz{source}";
            }
            var chars = source.ToCharArray();
            var data = new byte[1];
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

        public static bool IsNumeric(string text)
        {
            return Double.TryParse(text, out double test);
        }

        public static string ConvertDayOfWeek(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Saturday":
                    return Global.Saturday;
                case "Sunday":
                    return Global.Sunday;
                case "Monday":
                    return Global.Monday;
                case "Tuesday":
                    return Global.Tuesday;
                case "Wednesday":
                    return Global.Wednesday;
                case "Thursday":
                    return Global.Thursday;
                case "Friday":
                    return Global.Friday;
                default:
                    return dayOfWeek;
            }
        }

        public static string ConvertDayOfWeek(string dayOfWeek, CultureInfo culture)
        {
            return Global.ResourceManager.GetString(dayOfWeek, culture);
        }

        public static DayOfWeek ConvertStringToDayOfWeek(string dayofweek)
        {
            switch (dayofweek)
            {
                case "Saturday":
                    return DayOfWeek.Saturday;
                case "Sunday":
                    return DayOfWeek.Sunday;
                case "Monday":
                    return DayOfWeek.Monday;
                case "Tuesday":
                    return DayOfWeek.Tuesday;
                case "Wednesday":
                    return DayOfWeek.Wednesday;
                case "Thursday":
                    return DayOfWeek.Thursday;
                case "Friday":
                    return DayOfWeek.Friday;
                default:
                    return DayOfWeek.Friday;
            }
        }


        public static string EnNum2Ku(string str)
        {
            return str.Replace("0", "۰")
                      .Replace("1", "۱")
                      .Replace("2", "۲")
                      .Replace("3", "۳")
                      .Replace("4", "۴")
                      .Replace("5", "۵")
                      .Replace("6", "۶")
                      .Replace("7", "۷")
                      .Replace("8", "۸")
                      .Replace("9", "۹");
        }

        public static string KuNum2EN(string str)
        {
            return str.Replace("۰", "0")
                      .Replace("۱", "1")
                      .Replace("۲", "2")
                      .Replace("۳", "3")
                      .Replace("۴", "4")
                      .Replace("۵", "5")
                      .Replace("۶", "6")
                      .Replace("۷", "7")
                      .Replace("۸", "8")
                      .Replace("۹", "9");
        }

        public static DateTime GetWeekEndDateTime()
        {
            // :: Start time must be : 00:00:00
            var today = DateTime.Parse(DateTime.Now.ToShortDateString() + " 00:00:00");
            DateTime weekEnd;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    weekEnd = today.AddDays(6);
                    break;
                case DayOfWeek.Sunday:
                    weekEnd = today.AddDays(5);
                    break;
                case DayOfWeek.Monday:
                    weekEnd = today.AddDays(4);
                    break;
                case DayOfWeek.Tuesday:
                    weekEnd = today.AddDays(3);
                    break;
                case DayOfWeek.Wednesday:
                    weekEnd = today.AddDays(2);
                    break;
                case DayOfWeek.Thursday:
                    weekEnd = today.AddDays(1);
                    break;
                case DayOfWeek.Friday:
                    weekEnd = today;
                    break;
                default:
                    weekEnd = today;
                    break;
            }

            return weekEnd;
        }

        public static string GetMonthName(DateTime dateTime)
        {
            var monthName = dateTime.ToString("MMM", CultureInfo.InvariantCulture);

            return monthName;
        }


        //public static string GetUserOS(string userAgent)
        //{
        //    // get a parser with the embedded regex patterns
        //    var uaParser = Parser.GetDefault();
        //    ClientInfo c = uaParser.Parse(userAgent);
        //    return c.OS.Family;
        //}



        //public static string GetIPAddress()
        //{
        //    var context = HttpContext.Current;
        //    var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    if (!string.IsNullOrEmpty(ipAddress))
        //    {
        //        var addresses = ipAddress.Split(',');
        //        if (addresses.Length != 0)
        //        {
        //            return addresses[0];
        //        }
        //    }

        //    return context.Request.ServerVariables["REMOTE_ADDR"];
        //}



        /// <summary>
        /// Split list to smaller lists with size N
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="locations"></param>
        /// <param name="nSize"></param>
        /// <returns></returns>
        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }


        /// <summary>
        /// Every X minute RetriveIPAJob executed
        /// </summary>
        public static int SchedulerIntervalMinutes => 2;


        /// <summary>
        /// An inprogress appointment expired after X minutes
        /// </summary>
        public static int ExpiredIpaMinutes => 5;

        /// <summary>
        /// Expiration time for inprogress appointment in miliseconds
        /// </summary>
        public static int ExpiredIpaMiliSeconds => (ExpiredIpaMinutes * 60) * 1000;


        /// <summary>
        /// زمان موردنیاز جهت پرداخت وجه نوبت
        /// </summary>
        public static int TimeToPaymentMinutes => 10;

        public static int TimeToPaymentMiliSeconds => (TimeToPaymentMinutes * 60) * 1000;

        public static TimeSpan MorningShiftFrom => new TimeSpan(6, 0, 0);

        public static TimeSpan MorningShiftTo => new TimeSpan(14, 0, 0);

        public static TimeSpan EveningShiftFrom => new TimeSpan(14, 0, 0);

        public static TimeSpan EveningShiftTo => new TimeSpan(23, 0, 0);

        public static int AutomaticScheduleTimeHour => 00;

        public static int AutomaticScheduleTimeMinute => 00;


        public static int AppointmentsReminderTimeHour => 19;

        public static int AppointmentsReminderTimeMinute => 30;


        /// <summary>
        /// مشخص می کند که تا چند روز آینده زمانبندی همیشگی مطب برای پزشک اعمال شود
        /// </summary>
        public static int AutomaticScheduleDaysAfter => 15;


        /// <summary>
        /// بازه زمانی اجرای وظیفه، تغیر وضعیت نوبت ها به انجام شده، را مشخص می کند
        /// هر چند دقیقه یک بار این وظیفه اجرا شده و نوبت هایی که زمان آنها گذشته و توسط
        /// منشی یا بیمار لغو نشده اند را انجام شده در نظر میگیرد
        /// </summary>
        public static int DoneAppointmentsSchedulerIntervalMinutes => 15;


        /// <summary>
        /// تعداد نوبت های رایگانی که هر بیمار میتواند رزرو کند
        /// </summary>
        public static int FreeAppointmentsCount => 2;


        /// <summary>
        /// مشخص میکند که آیا پرداخت برای سیستم نوبت دهی فعال باشد یا خیر؟
        /// </summary>
        public static bool IsPaymentEnabled => true;


        /// <summary>
        /// قیمت هر نوبت را نشان می دهد
        /// </summary>
        public static long AppointmentPrice => 1000;


        public static string GetFilePath(string fileName, string path)
        {
            var count = 1;

            var fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);
            var newFullPath = Path.Combine(path, fileName);

            while (File.Exists(newFullPath))
            {
                var tempFileName = $"{fileNameOnly}({count++})";
                newFullPath = Path.Combine(path, tempFileName + extension);
            }

            return newFullPath;
        }

        public static ScheduleShift GetScheduleShift(DateTime start, DateTime end)
        {

            if (start.Hour >= Defaults.MorningStart.Hour && start.Hour < Defaults.MorningEnd.Hour)
                return ScheduleShift.Morning;
            return ScheduleShift.Evening;
        }

    }
}
