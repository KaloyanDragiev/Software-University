using System;
using System.Collections.Generic;

public class CitiesContinentCountry
{
    public static void Main()
    {
        var continentsByCountryesAndTowns = new Dictionary<string, Dictionary<string, List<string>>>();

        var givenContinentsByCountryesAndTowns = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < givenContinentsByCountryesAndTowns; count++)
        {
            var nextContinentByCountryAndTowns = Console.ReadLine().Split(' ');
            var continent = nextContinentByCountryAndTowns[0];
            var country = nextContinentByCountryAndTowns[1];
            var town = nextContinentByCountryAndTowns[2];

            if (!continentsByCountryesAndTowns.ContainsKey(continent))
            {
                continentsByCountryesAndTowns[continent] = new Dictionary<string, List<string>>();
            }
            if (!continentsByCountryesAndTowns[continent].ContainsKey(country))
            {
                continentsByCountryesAndTowns[continent][country] = new List<string>();
            }
                continentsByCountryesAndTowns[continent][country].Add(town);
        }

        foreach (var continent in continentsByCountryesAndTowns)
        {
            Console.WriteLine("{0}:", continent.Key);
            foreach (var country in continent.Value)
            {
                var isFirst = true;
                Console.Write($"  {country.Key} -> ");
                foreach (var town in country.Value)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        Console.Write(town);
                        continue;
                    }
                    Console.Write(", {0}", town);
                }
                Console.WriteLine();
            }
        }
    }
}
