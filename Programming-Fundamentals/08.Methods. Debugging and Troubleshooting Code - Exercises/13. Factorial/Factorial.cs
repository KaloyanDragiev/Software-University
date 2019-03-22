namespace _13.Factorial
{
    using System;
    using System.Numerics;
   
    public class Factorial
    {
        public static void Main()
        {
            ushort number = ushort.Parse(Console.ReadLine());
            BigInteger factoriel = new BigInteger(1);
            for (int i = 1; i <= number; i++)
            {
                factoriel = BigInteger.Multiply(factoriel, i);
            }
            Console.WriteLine(factoriel);
        }
    }
}