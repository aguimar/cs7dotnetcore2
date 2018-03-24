using System.Text.RegularExpressions;
namespace Packt.CS7
{
    public static class StringExtensions
    {
        public static bool isValidEmail(this string input)
        {
            // use simple regular expression to check
            // that the input string is a valid email
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}