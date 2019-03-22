namespace _02._1.CircleArea
{
    using System;
  
    public class Program
    {
        public static void Main()
        {
            double r = double.Parse(Console.ReadLine());

            Console.WriteLine("{0:F12}", Math.PI * r * r);
        }
    }
}
