namespace _14.FactorialTrailingZeroes
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            ushort number = ushort.Parse(Console.ReadLine());
            BigInteger factoriel = new BigInteger(1);
            for (int i = 1; i <= number; i++)
            {
                factoriel = BigInteger.Multiply(factoriel, i);
            }

            int counter = 0;
            string bigNumber = factoriel.ToString();
            for (int i = bigNumber.Length; i > 0; i--)
            {
                if (bigNumber[i - 1] == '0')
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
