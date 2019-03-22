namespace _04.Nth_Digit
{
    using System;

    public class NthDigit
    {
        public static void Main()
        {
            int currentNumber = int.Parse(Console.ReadLine());
            int digitIndex = int.Parse(Console.ReadLine());

            int digit = GetDigit(currentNumber, digitIndex);

            Console.WriteLine(digit);
            //PrintNthDigit(currentNumber, digitIndex);
        }

        private static int GetDigit(int currentNumber, int digitIndex)
        {
            for (int i = 1; i < digitIndex; i++)
            {
                currentNumber /= 10;
            }
            return currentNumber % 10;
        }

        //private static void PrintNthDigit(string currentNumber, byte digitIndex)
        //{
        //    byte nthDigit = byte.Parse(currentNumber[currentNumber.Length - digitIndex].ToString());
        //    Console.WriteLine(nthDigit); ;
        //}
    }
}
