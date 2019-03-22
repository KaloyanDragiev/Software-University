namespace _04.Float_or_Integer
{
    using System;
  
    public class FloatorInteger
    {
        public static void Main()//Memory: 7.60 MB, Time: 0.015 s
        {
            double input = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Round(input));
        }
    }
}
