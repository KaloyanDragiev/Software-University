namespace _17.Altitude
{
    using System;

    public class Altitude
    {
        public static void Main()
        {
            var altitude = Console.ReadLine().Split(' ');
            var interations = altitude.Length;
            var currentValue = 0L;
            var result = Convert.ToInt64(altitude[0]);
            for (int index = 1; index < interations; index = index + 2)
            {
                currentValue = Convert.ToInt64(altitude[index + 1]);
                if (altitude[index] == "up")
                {
                    result += currentValue;
                }
                else if (altitude[index] == "down")
                {
                    result -= currentValue;
                }

                if (result <= 0)
                {
                    Console.WriteLine("crashed");
                    return;
                }
            }
            Console.WriteLine("got through safely. current altitude: {0}m", result);
        }
    }
}
