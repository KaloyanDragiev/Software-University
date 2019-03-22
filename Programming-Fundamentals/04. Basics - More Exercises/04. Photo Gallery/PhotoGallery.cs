namespace _04.Photo_Gallery
{
    using System;
   
    public class PhotoGallery
    {
        public static void Main()
        {
            int imgID = int.Parse(Console.ReadLine());

            int dd = int.Parse(Console.ReadLine());

            int MM = int.Parse(Console.ReadLine());

            int YYYY = int.Parse(Console.ReadLine());

            int hh = int.Parse(Console.ReadLine());

            int mm = int.Parse(Console.ReadLine());

            int photoSize = int.Parse(Console.ReadLine());

            int photoWidth = int.Parse(Console.ReadLine());

            int photoHeight = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: DSC_{imgID:0000}.jpg");

            Console.WriteLine($"Date Taken: {dd:00}/{MM:00}/{YYYY:0000} {hh:00}:{mm:00}");

            double size = 0;

            string sizeExtention = string.Empty;

            if (photoSize > 1000000)
            {
                size = photoSize / 1000000.0;

                sizeExtention = "MB";
            }
            else if (photoSize > 1000)
            {
                size = photoSize / 1000;

                sizeExtention = "KB";
            }
            else
            {
                size = photoSize;

                sizeExtention = "B";
            }

            Console.WriteLine($"Size: {size}{sizeExtention}");

            string type = string.Empty;

            if (photoWidth > photoHeight)
            {
                type = "landscape";
            }
            else if (photoWidth == photoHeight)
            {
                type = "square";
            }
            else
            {
                type = "portrait";
            }

            Console.WriteLine($"Resolution: {photoWidth}x{photoHeight} ({type})");
        }
    }
}
