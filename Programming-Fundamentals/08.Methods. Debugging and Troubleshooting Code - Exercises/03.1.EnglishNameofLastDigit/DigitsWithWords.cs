namespace _03._1.EnglishNameofLastDigit
{
    using System;
   
    public class DigitsWithWords
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            byte index = (byte)number.Length;
            string symbol = number[index - 1].ToString();
            byte digit = ParseByte(symbol);

            PrintDigitWithWord(digit);
        }

        private static byte ParseByte(string symbol)
        {
            return byte.Parse(symbol);
        }

        public static void PrintDigitWithWord(byte digit)
        {
            string[] digits = new string[]
            {"zero", "one", "two", "three",
             "four", "five", "six", "seven", "eight", "nine"};

            Console.WriteLine(digits[digit]);
        }
    }
}
