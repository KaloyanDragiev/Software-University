namespace _09.Longer_Line
{
    using System;
   
    public class LongerLine
    {
        public static void Main()
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            double X4 = double.Parse(Console.ReadLine());
            double Y4 = double.Parse(Console.ReadLine());
            double X3 = double.Parse(Console.ReadLine());
            double Y3 = double.Parse(Console.ReadLine());

            double firstLine = LineLengt(X1, Y1, X2, Y2);
            double secondLine = LineLengt(X3, Y3, X4, Y4);

            double firstPoint = DistanceToZero(X1, Y1);
            double secondPoint = DistanceToZero(X2, Y2);
            double thirdPoint = DistanceToZero(X3, Y3);
            double forthPoint = DistanceToZero(X4, Y4);

            string firstLineCordinates = firstPoint <= secondPoint ?
                $"({X1}, {Y1})({X2}, {Y2})" : $"({X2}, {Y2})({X1}, {Y1})";

            string secondLineCordinates = thirdPoint < forthPoint ?
                $"({X3}, {Y3})({X4}, {Y4})" : $"({X4}, {Y4})({X3}, {Y3})";

            string longerLine = firstLine >= secondLine ? firstLineCordinates : secondLineCordinates;
          
            Console.WriteLine(longerLine);
        }

        private static double LineLengt(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x2 - x1), 2) + Math.Pow(Math.Abs(y2 - y1), 2));
        }

        private static double DistanceToZero(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }4
}
