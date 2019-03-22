namespace _07.Primes_in_Given_Range
{
    using System;
   
    public class PrimesGivenRange
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            if (start == 0 || start == 1)
            {
                start = 2;
            }
            Console.Write(start == 2? "2, " : "");
            start += start > 1 && start % 2 == 0 ? 1 : 0;
            PrintPrimeNumbers(start, end);
        }

        public static void PrintPrimeNumbers(int start, int end)
        {
            bool isFirstPrime = true;
            for (int i = start; i <= end; i += 2)
            {
                bool isPrime = IsPrimeNumber(i);
                if (isPrime)
                {
                    Console.Write(isFirstPrime? "" + i: ", " + i);
                    isFirstPrime = false;
                }
            }
            Console.WriteLine();
        }

        private static bool IsPrimeNumber(int i)
        {
            bool isPrime = true;
            int counter = (int)Math.Ceiling(Math.Sqrt(i));
            for (int j = 2; j <= counter; j++)
            {
                if (i % j == 0) { isPrime = false; break; }
            }
            return isPrime;
        }
    }
}
