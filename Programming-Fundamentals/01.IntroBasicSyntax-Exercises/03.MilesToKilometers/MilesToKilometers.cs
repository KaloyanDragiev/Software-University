namespace _03.MilesToKilometers
{
    using System;

    public class MilesToKilometers
    {
        public static void Main()
        {
            double inpitInMiles = double.Parse(Console.ReadLine());

            double kilometers = inpitInMiles * 1.60934;

            Console.WriteLine("{0}", kilometers.ToString("F2"));
        }
    }
}