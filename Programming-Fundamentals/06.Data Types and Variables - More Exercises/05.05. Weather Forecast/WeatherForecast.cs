namespace _05._05.Weather_Forecast
{
    using System;

    public class WeatherForecast
    {
        public static void Main()
        {
            string numberToParse = Console.ReadLine();

            sbyte sbyteNumber = 0;

            int intNumber = 0;

            long longNumber = 0;

            if (sbyte.TryParse(numberToParse, out sbyteNumber))
            {
                Console.WriteLine("Sunny");
            }
            else if (int.TryParse(numberToParse, out intNumber))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(numberToParse, out longNumber))
            {
                Console.WriteLine("Windy");
            }
            else
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
