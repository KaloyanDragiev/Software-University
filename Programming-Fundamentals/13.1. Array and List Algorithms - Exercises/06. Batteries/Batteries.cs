namespace _06.Batteries
{
    using System;
    using System.Linq;

    public class Batteries
    {
        public static void Main()
        {
            var batteries = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            var usagePerHour = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            var stressTime = int.Parse(Console.ReadLine());

            StatusForEachBatteri(batteries, usagePerHour, stressTime);
        }

        private static void StatusForEachBatteri(
            double[] batteries, double[] usagePerHour, int stressTime)
        {
            var counter = 1;
            for (int index = 0; index < batteries.Length; index++)
            {
                var balance = batteries[index] - usagePerHour[index] * stressTime;
                var percent = balance / batteries[index] * 100;
                if (balance > 0)
                {
                    Console.WriteLine($"Battery {counter}: {balance:0.00} mAh ({percent:0.00})%");
                }
                else
                {
                    var lasted = Math.Ceiling(batteries[index] / usagePerHour[index]);
                    Console.WriteLine($"Battery {counter}: dead (lasted {lasted} hours)");
                }
                counter++;
            }
        }
    }
}
