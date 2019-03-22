namespace _08.Center_Point
{
    using System;
   
    public class CenterPoint
    {
        public static void Main()
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            double firstPoint = DistanceToZero(X1, Y1);
            double secondPoint = DistanceToZero(X2, Y2);

            Console.WriteLine(firstPoint < secondPoint ? $"({X1}, {Y1})" : $"({X2}, {Y2})");
        }

        private static double DistanceToZero(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
