namespace Articles.Web.Extensions
{
    public static class StringExtensions
    {
        public static string Short(this string str, int maxLength = 20)
        {
            if (str == null || str.Length <= maxLength)
            {
                return str;
            }

            string shortStr = str.Substring(0, maxLength - 3) + "...";
            return shortStr;
        }
    }
}