namespace _09.Triangle_Formations
{
    using System;
  
    public class Program
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            string isValidTriangle = a + b > c && a + c > b && b + c > a ?
                "Triangle is valid." : "Invalid Triangle.";

            string isRightTriangle = isValidTriangle == "Triangle is valid." && a * a + b * b == c * c ?
              "Triangle has a right angle between sides a and b" :
            isValidTriangle == "Triangle is valid." && a * a + c * c == b * b ?
              "Triangle has a right angle between sides a and c" :
            isValidTriangle == "Triangle is valid." && b * b + c * c == a * a ?
              "Triangle has a right angle between sides b and c" :
              isValidTriangle == "Triangle is valid." ? "Triangle has no right angles" : "";

            Console.WriteLine($"{isValidTriangle}\n{isRightTriangle}");
        }
    }
}
