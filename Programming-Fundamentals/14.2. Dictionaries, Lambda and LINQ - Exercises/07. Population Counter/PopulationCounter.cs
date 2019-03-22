using System;
using System.Collections.Generic;
using System.Linq;

public class PopulationCounter
{
    static Dictionary<string, Dictionary<string, long>> populationByCountryAndTown =
    new Dictionary<string, Dictionary<string, long>>();

    public static void Main()
    {
        for (int count = 0; ; count++)
        {
            var currentOperation = Console.ReadLine().Split('|');
            var town = currentOperation[0];
            if (town == "report")
            {
                break;
            }
            var country = currentOperation[1];
            var population = Convert.ToInt32(currentOperation[2]);

            if (!populationByCountryAndTown.ContainsKey(country))
            {
                populationByCountryAndTown[country] = new Dictionary<string, long>();
            }
            if (!populationByCountryAndTown[country].ContainsKey(town))
            {
                populationByCountryAndTown[country][town] = 0;
            }
            populationByCountryAndTown[country][town] += population;
        }
        populationByCountryAndTown =
            populationByCountryAndTown
            .OrderByDescending(country => country.Value.Values.Sum())
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var country in populationByCountryAndTown)
        {
            var totalPopulation = country.Value.Values.Sum();
            Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

            var towns = country.Value.OrderByDescending(town => town.Value);
            foreach (var town in towns)
            {
                Console.WriteLine("=>{0}: {1}", town.Key, town.Value);
            }
        }
    }
}