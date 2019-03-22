namespace _06.Prime_Checker
{
    using System;

    public class PrimeChecker
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            if (number == 0 || number == 1)
            {
                Console.WriteLine(false);
            }
            else
            {
                isPrimme(number);
            }
        }

        private static void isPrimme(long number)
        {
            bool isPrime = true;
            int counter = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = 2; i <= counter; i++)
            {
                if (number % i == 0 && number != i)
                {
                    isPrime = false;
                    break;
                }
            }
        }
    }
}