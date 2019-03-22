namespace _10.Cube_Properties
{
    using System;
   
    public class CubeProperties
    {
        public static void Main()
        {
            //face, space, volume or area
            double cubeSide = double.Parse(Console.ReadLine());

            string property = Console.ReadLine();

            double result = 0;

            if (property == "area")
            {
                result = cubeSide * cubeSide * 6;
                Console.WriteLine($"{result:F2}");
            }
            else if (property == "space")
            {
                result = Math.Sqrt(cubeSide * cubeSide * 3);
                Console.WriteLine($"{result:F2}");
            }
            else if (property == "volume")
            {
                result = cubeSide * cubeSide * cubeSide;
                Console.WriteLine($"{result:F2}");
            }
            else if (property == "face")
            {
                result = Math.Sqrt(cubeSide * cubeSide * 2);
                Console.WriteLine($"{result:F2}");
            }
        }
    }
}
