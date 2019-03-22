namespace _05.DistanceOfTheStars
{
    using System;
 
    public class DistanceOfTheStars
    {
        public static void Main()// Memory: 7.55 MB, Time: 0.015 s

        {
            decimal nearestStar = 4.22m * 9450000000000m;
            Console.WriteLine(nearestStar.ToString("e2"));
            decimal galaxyCenter = 26000m * 9450000000000m;
            Console.WriteLine(galaxyCenter.ToString("e2"));
            decimal MilkyWay = 100000m * 9450000000000m;
            Console.WriteLine(MilkyWay.ToString("e2"));
            decimal universe = 46500000000m * 9450000000000m;
            Console.WriteLine(universe.ToString("e2"));
        }
    }
}
