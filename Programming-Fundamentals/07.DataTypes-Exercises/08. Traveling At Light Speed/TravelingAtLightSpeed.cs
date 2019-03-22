namespace _08.Traveling_At_Light_Speed
{
    using System;
   
    public class TravelingAtLightSpeed
    {
        public static void Main()
        {
            double ly = double.Parse(Console.ReadLine());

            double timeToConvert = 9450000000000 / 300000 * ly;

            TimeSpan time = TimeSpan.FromSeconds(timeToConvert);

            double weeks = time.Days / 7;
            double days = time.Days % 7;
            double hours = time.Hours;
            double minutes = time.Minutes;
            double seconds = time.Seconds;

            Console.WriteLine($"{weeks} weeks");
            Console.WriteLine($"{days} days");
            Console.WriteLine($"{hours} hours");
            Console.WriteLine($"{minutes} minutes");
            Console.WriteLine($"{seconds} seconds");
        }
    }
}
