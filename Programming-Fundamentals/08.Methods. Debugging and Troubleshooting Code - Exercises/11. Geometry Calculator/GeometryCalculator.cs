namespace _11.Geometry_Calculator
{
    using System;
   
    public class GeometryCalculator
    {
        public static void Main()
        {
            string figure = Console.ReadLine().ToLower();

            double side = double.Parse(Console.ReadLine());
            double figureArea = 0;
            if (figure == "square" || figure == "circle")
            {
               figureArea = SqareCircleArea(figure, side);
            }
            else
            {
                figureArea = TriangleRectangleArea(figure, side);
            }

            Console.WriteLine($"{figureArea:F2}");
        }

        private static double TriangleRectangleArea(string figure, double side)
        {
            double secondProprty = double.Parse(Console.ReadLine());
            return figure == "triangle" ? (side * secondProprty) / 2 : side * secondProprty;
        }

        private static double SqareCircleArea(string figure, double side)
        {
            return figure == "circle" ? Math.PI * side * side : side * side; 
        }

    }
}
