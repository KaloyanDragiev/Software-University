namespace _06.Power_Plants
{
    using System;
    using System.Linq;

    public class PowerPlants
    {
        public static void Main()
        {
            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ctr = -1;
            var days = 0;
            var sum = 0;
            var value = 0;

            for (int count = 0; ; count++)
            {
                ctr++;
                sum = 0;
                for (int index = 0; index < plants.Length; index++)
                {
                    plants[index] = days == index ? plants[index] : plants[index] - 1;
                    value = plants[index] <= 0 ? plants[index] = 0 : plants[index] = plants[index];
                    sum += value;
                }
                days++;
                days = days == plants.Length ? days = 0 : days += 0;
                if (days % plants.Length == 0)
                {
                    for (int index = 0; index < plants.Length; index++)
                    {
                        plants[index] = plants[index] > 0 ? plants[index] += 1 : plants[index] += 0;
                    }
                }
                if (sum == 0)
                {
                    break;
                }
            }
            var seasons = ctr / plants.Length == 1 ? "season" : "seasons";
            Console.WriteLine($"survived {ctr + 1} days ({ctr / plants.Length} {seasons})");

        }
    }
}
