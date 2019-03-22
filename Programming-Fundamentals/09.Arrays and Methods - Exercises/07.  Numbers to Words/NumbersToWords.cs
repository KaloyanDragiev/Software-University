namespace _07.Numbers_to_Words
{
    using System;

    public class NumbersToWords
    {
        public static void Main()
        {
            string currentNumber = string.Empty;
            int commingNumbers = int.Parse(Console.ReadLine());
            for (int count = 0; count < commingNumbers; count++)
            {
                currentNumber = Console.ReadLine();
                if (int.Parse(currentNumber) > 999 || int.Parse(currentNumber) < -999)
                {
                    Console.WriteLine(int.Parse(currentNumber) > 999 ? "too large" : "too small");
                }
                else if (int.Parse(currentNumber) > 99 || int.Parse(currentNumber) < -99)
                {
                    PrintNumberInWords(currentNumber);
                }
            }
        }

        public static void PrintNumberInWords(string currentNumber)
        {
            string[,] numbers = 
            { { "", "one", "two", "three", "four","five", "six", "seven", "eight", "nine", },
            { "", "ten", "twenty", "thirty", "forty","fifty", "sixty","seventy", "eighty", "ninety" },
            { "ten ", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
              "eighteen", "nineteen"} };

            int numberLenght = currentNumber.Length;
            int hundreds = ParseLenght(currentNumber, numberLenght, 0, 1);
            int tens = ParseLenght(currentNumber, numberLenght, 1, 2);
            int digits = ParseLenght(currentNumber, numberLenght, 2, 3);

            string numberAsWords = numberLenght > 3 ? "minus " : string.Empty;
            numberAsWords += Hundreds(numbers, hundreds, tens, digits, numberLenght);
            numberAsWords += Tens(numbers, tens, digits);

            Console.WriteLine(numberAsWords);
        }

        private static int ParseLenght(string currentNumber, int numberLenght, int v1, int v2)
        {
            int index = numberLenght > 3 ? v2 : v1;
            return int.Parse(currentNumber[index].ToString());
        }

        private static string Hundreds(string[,] numbers, int h, int t, int d, int numberLenght)
        {
            string hundred = numbers[0, h];
            return hundred += t == 0 && d == 0 ? "-hundred " : "-hundred and";
        }

        private static string Tens(string[,] numbers, int t, int d)
        {
            return t > 1 ? $" {numbers[1, t]}" + $" {numbers[0, d]}" : 
                  t == 1 ? $" {numbers[2, d]}" : $" {numbers[0, d]}";
        }
    }
}
