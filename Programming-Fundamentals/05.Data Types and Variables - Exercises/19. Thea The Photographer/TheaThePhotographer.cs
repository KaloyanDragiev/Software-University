namespace _19.Thea_The_Photographer
{
    using System;

    public class TheaThePhotographer
    {
        public static void Main()
        {
            long amountOfThePictures = long.Parse(Console.ReadLine());

            long timeToFilterPerPicture = long.Parse(Console.ReadLine());

            long filterFactorInPersent = long.Parse(Console.ReadLine());

            long uploadTimePerPicture = long.Parse(Console.ReadLine());

            double percent = filterFactorInPersent / 100.0;

            long totalUsefullPictures = (long)Math.Ceiling(amountOfThePictures * percent);

            long totalFilteringTime = amountOfThePictures * timeToFilterPerPicture;

            long totalUploadTime = totalUsefullPictures * uploadTimePerPicture;

            long totalReadyTime = totalUploadTime + totalFilteringTime;

            long days = totalReadyTime / (24 * 60 * 60);

            long rest = totalReadyTime % (24 * 60 * 60);

            long hours = rest / (60 * 60);

            rest = rest % (60 * 60);

            long minutes = rest / 60;

            long seconds = rest % 60;

            Console.WriteLine($"{days}:{hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}