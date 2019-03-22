namespace _16.Comparing_floats
{
    using System;
   
    public class ComparingFloats
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());

            double b = double.Parse(Console.ReadLine());

            if (Math.Abs(Math.Abs(a) - Math.Abs(b)) < 0.000001)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
