namespace _02.Max_Method
{
    using System;
   
    public class MaxMethod
    {
        public static void Main()
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double thrid = double.Parse(Console.ReadLine());
            double max = GetMax(first, second);
            max = GetMax(max, thrid);
            Console.WriteLine(max);
        }

        private static double GetMax(double num1, double num2)
        {
            if (num1 < num2)
            {
                return num2;
            }
            return num1;
        }
    }
}
