namespace _01.Time_Since_Birthday
{
    using System;
 
    public class TimeSinceBirthday
    {
        public static void Main()
        {
            double years = int.Parse(Console.ReadLine());

            Console.Write($"{years} years = {years * 365} days = {years * 365 * 24} hours = {years * 365 * 24 * 60} minutes.");
        }
    }
}
