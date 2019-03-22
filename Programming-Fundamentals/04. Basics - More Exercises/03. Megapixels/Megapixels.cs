namespace _03.Megapixels
{
    using System;
  
    public class Megapixels
    {
        public static void Main()
        {
            int photoWidth = int.Parse(Console.ReadLine());

            int photoHeight = int.Parse(Console.ReadLine());

            double cameraMP = photoWidth * photoHeight / 1000000.0;

            Console.WriteLine($"{photoWidth}x{photoHeight} => {Math.Round(cameraMP, 1)}MP");
        }
    }
}
