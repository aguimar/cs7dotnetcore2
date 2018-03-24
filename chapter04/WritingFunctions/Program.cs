using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table");
            for (int row = 0; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = { row * number}");
            }
        }

        static void RunTimesTable() {
            Write("Enter a number between 0 and 255: ");
            if (byte.TryParse(ReadLine(), out byte number)) {
                TimesTable(number);
            } else {
                WriteLine("You did not enter a valid number!");
            }
        }

        static string CardinalToOrdinal(int number) {
            switch (number) {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    string numberAsText = number.ToString();
                    char lastDigit= numberAsText[numberAsText.Length - 1];
                    string suffix = string.Empty;
                    switch(lastDigit) {
                        case '1':
                            suffix = "st";
                            break;
                        case '2':
                            suffix = "nd";
                            break;
                        case '3':
                            suffix = "rd";
                            break;
                        default:
                            suffix = "th";
                            break;
                    }
                return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal() {
            for (int i = 0; i <= 40; i++)
            {
                Write($"{CardinalToOrdinal(i)} ");
            }
        }

        static int Factorial(int number) {
            if (number < 1) {
                return 0;
            } else if (number == 1) {
                return 1;
            } else {
                return number*Factorial(number-1);
            }
        }

        static void RunFactorial() {
            Write("Enter a number: ");
            if( int.TryParse(ReadLine(), out int number)) {
                WriteLine($"{number:N0}! = {Factorial(number):N0}");
            } else {
                WriteLine("You did not enter a valid number!");
            }
        }

        static void Main(string[] args) {
            //RunCardinalToOrdinal();
            RunFactorial();
        }

    }
}
