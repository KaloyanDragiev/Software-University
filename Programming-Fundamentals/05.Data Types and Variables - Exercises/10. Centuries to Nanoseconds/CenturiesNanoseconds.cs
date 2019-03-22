namespace _10.Centuries_to_Nanoseconds
{
    using System;
   
    public class CenturiesNanoseconds
    {
        public static void Main()
        {
            //years = centuries * 100;
            //days = years * 365.2422;
            //hours = days * 24;
            //minutes = hours * 60;
            //seconds = minutes * 60;
            //milliseconds = seconds * 1000;
            //microseconds = milliseconds * 1000;
            //nanoseconds = microseconds * 1000;
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            long minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong milliseconds = seconds * 1000;
            decimal microseconds = milliseconds * 1000;
            decimal nanoseconds = microseconds * 1000;
            Console.Write($"{centuries} centuries = ");
            Console.Write($"{years} years = ");
            Console.Write($"{days} days = ");
            Console.Write($"{hours} hours = ");
            Console.Write($"{minutes} minutes = ");
            Console.Write($"{seconds} seconds = ");
            Console.Write($"{milliseconds} milliseconds = ");
            Console.Write($"{microseconds} microseconds = ");
            Console.Write($"{nanoseconds} nanoseconds");
        }
    }
}
