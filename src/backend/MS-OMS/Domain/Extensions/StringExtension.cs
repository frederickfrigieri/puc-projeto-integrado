using System.Text.RegularExpressions;

namespace Domain.Extensions
{
    public static class StringExtension
    {
        public static string SomenteNumeros(this string value)
        {
            return string.Join("", Regex.Split(value, @"[^\d]"));
        }
    }
}
