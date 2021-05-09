namespace AN.Core
{
    public static class GlobalUtils
    {
        public static string FaNum2EN(string str)
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
    }
}
