namespace _11.Convert_Speed_Units
{
    using System;
  
    public class Speed
    {
        public static void Main()
        {
            float distanceInMeters = int.Parse(Console.ReadLine());
            float hours = int.Parse(Console.ReadLine());
            float minutes = int.Parse(Console.ReadLine());
            float seconds = int.Parse(Console.ReadLine());

            // mile = 1.609;

            // print the speed in, 
            // meters per second => distanse / totalSeconds <
            // kilometers per hour,  
            // miles per hour

            float totalSeconds = hours * 60 * 60 + minutes * 60 + seconds;
            float distanceMetersPerSecond = distanceInMeters / totalSeconds;
            Console.WriteLine(distanceMetersPerSecond);

            float kilometers = distanceInMeters / 1000f;
            float totalHours = (seconds / 60 + minutes) / 60 + hours;
            float distanceKilometersPerHour = kilometers / totalHours;
            Console.WriteLine(kilometers / totalHours);

            float miles = kilometers / 1.609f;
            float distanceMilesPerHour = miles / totalHours;
            Console.WriteLine(distanceMilesPerHour);
        }
    }
}
