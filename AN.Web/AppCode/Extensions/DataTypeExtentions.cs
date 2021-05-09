using System;

namespace AN.Web.AppCode.Extensions
{
    public static class DataTypeExtentions
    {
        public static string RemoveLines(this Guid guid)
        {
            return guid.ToString().Replace("-", "");
        }

        public static string RemoveLines(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Replace("-", "");
            }
            else
            {
                return input;
            }
        }
    }
}
