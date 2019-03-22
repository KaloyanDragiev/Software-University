namespace _02.RectangleArea
{
    using System;
   
    public class RectangleArea
    {
        public static void Main()
        {
            double rectangelWidth = double.Parse(Console.ReadLine());

            double rectangelHeight = double.Parse(Console.ReadLine());

            double rectangleArea = rectangelWidth * rectangelHeight;

            Console.WriteLine("{0}", rectangleArea.ToString("F2"));
        }
    }
}
