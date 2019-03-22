namespace _03._1.ExactSumOfRealNumbers
{
    using System;
   
    public class ExactSumOfRealNumbers
    {
        public static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());

            decimal result = 0m;

            for (int i = 0; i < n; i++)
            {
                result += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(result);
        }
    }
}
