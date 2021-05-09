using System;

namespace AN.BLL.Extensions
{
    public static class StringExtensions
    {
        public static string TruncateLongString(this string str, int maxLength, string postFix = "...")
        {
            if (string.IsNullOrEmpty(str)) return str;

            var subString = str.Substring(0, Math.Min(str.Length, maxLength));

            return !string.IsNullOrEmpty(postFix) ? $"{subString}{postFix}" : subString;
        }
    }
}
