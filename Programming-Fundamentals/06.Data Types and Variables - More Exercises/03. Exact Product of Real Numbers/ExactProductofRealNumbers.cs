namespace _03.Exact_Product_of_Real_Numbers
{
    using System;
  
    public class ExactProductofRealNumbers
    {
        public static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());

            decimal result = 0.0000000000000000000000000000m;

            decimal number = decimal.Parse(Console.ReadLine());

            result = number;

            for (int i = 1; i < n; i++)
            {
                number = decimal.Parse(Console.ReadLine());

                result *= number;
            }

            Console.WriteLine(result);
        }
    }
}
