namespace DigitsWithWords
{
    using System;
 
    public class Digits
    {
        public static void Main() // 80 / 100
        {
            int number = int.Parse(Console.ReadLine());

            int digit = GetLastDigit(number);
          
            PrintDigit(digit);
        }

        public static int GetLastDigit(int number)
        {
            return number % 10;
        }

        public static void PrintDigit(int digit)
        {
            string[] digits = new string[] 
            {"zero", "one", "two", "three",
             "four", "five", "six", "seven", "eight", "nine"};

            Console.WriteLine(digits[digit]);
        }
    }
}
