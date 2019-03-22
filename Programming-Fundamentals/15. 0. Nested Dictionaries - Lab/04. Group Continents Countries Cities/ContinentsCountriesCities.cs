using System;
using System.Collections.Generic;
using System.Linq;

public class ContinentsCountriesCities
{
    public static void Main()
    {
        var groupedContinentsCountryesTowns = 
            new SortedDictionary<string, SortedDictionary<string, HashSet<string>>>();

        var counterGroupedContinentsCountryesTowns = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < counterGroupedContinentsCountryesTowns; count++)
        {
            var givenContinentCountryWithTown = Console.ReadLine().Split(' ');
            var continent = givenContinentCountryWithTown[0];
            var country = givenContinentCountryWithTown[1];
            var town = givenContinentCountryWithTown[2];

            if (!groupedContinentsCountryesTowns.ContainsKey(continent))
            {
                groupedContinentsCountryesTowns[continent] = 
                    new SortedDictionary<string, HashSet<string>>();
            }
            if (!groupedContinentsCountryesTowns[continent].ContainsKey(country))
            {
                groupedContinentsCountryesTowns[continent][country] = new HashSet<string>();
            }
            groupedContinentsCountryesTowns[continent][country].Add(town);
        }

        foreach (var continent in groupedContinentsCountryesTowns)
        {
            Console.WriteLine($"{continent.Key}:");
            foreach (var country in continent.Value)
            {
                Console.Write($"  {country.Key} -> ");
                var isFirstTown = true;
                var sortedTowns = country.Value.OrderBy(x => x);
                foreach (var town in sortedTowns)
                {
                    if (isFirstTown)
                    {
                        Console.Write(town);
                        isFirstTown = false;
                        continue;
                    }
                    Console.Write(", {0}", town);
                }
                Console.WriteLine();
            }
        }
    }
}
