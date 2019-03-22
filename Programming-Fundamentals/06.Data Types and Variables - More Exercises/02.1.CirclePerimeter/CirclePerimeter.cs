namespace _02._1.CirclePerimeter
{
    using System;
  

    public class CirclePerimeter
    {
        public static void Main()
        {
            //Console.WriteLine("{0:F12}", double.Parse(Console.ReadLine()) * Math.PI * 2);

            double r = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * r;

            Console.WriteLine(perimeter.ToString("F12"));
        }
    }
}
