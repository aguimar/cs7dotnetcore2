using System.Text.RegularExpressions;
using static System.Console;

namespace WorkingWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter your age: ");
            string input = ReadLine();
            var agerChecker = new Regex(@"^\d+$");
            if (agerChecker.IsMatch(input))
            {
                WriteLine("Thank you!");
            }
            else 
            {
                WriteLine($"This is not a valid age: {input}");
            }
        }
    }
}
