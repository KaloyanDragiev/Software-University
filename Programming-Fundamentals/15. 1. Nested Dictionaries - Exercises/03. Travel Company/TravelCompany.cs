using System;
using System.Collections.Generic;

public class TravelCompany
{
    public static void Main()
    {
        var destinationsTransportKindPlaces = new Dictionary<string, Dictionary<string, int>>();
        var destinationTrahsportPeople = Console.ReadLine();
        while (destinationTrahsportPeople != "ready")
        {
            var splited = destinationTrahsportPeople
                .Split(new[] { ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var destination = splited[0];
            var transportAndQuantity = splited;

            if (!destinationsTransportKindPlaces.ContainsKey(destination))
            {
                destinationsTransportKindPlaces[destination] = new Dictionary<string, int>();
            }
            for (int index = 1; index < transportAndQuantity.Length; index += 2)
            {
                var transport = transportAndQuantity[index];
                var places = Convert.ToInt32(transportAndQuantity[index + 1]);

                if (!destinationsTransportKindPlaces[destination].ContainsKey(transport))
                {
                    destinationsTransportKindPlaces[destination][transport] = 0;
                }
                destinationsTransportKindPlaces[destination][transport] = places;
            }

            destinationTrahsportPeople = Console.ReadLine();
        }

        var peoplesToDestinations = new Dictionary<string, int>();
        destinationTrahsportPeople = Console.ReadLine();
        while (destinationTrahsportPeople != "travel time!")
        {
            var splited = destinationTrahsportPeople
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var destination = splited[0];
            var peoples = Convert.ToInt32(splited[1]);

            var placesTo = 0;
            foreach (var places in destinationsTransportKindPlaces[destination])
            {
                placesTo += places.Value;
            }
            if (peoples <= placesTo)
            {
                Console.WriteLine($"{destination} -> all {peoples} accommodated");
            }
            else
            {
                Console.WriteLine($"{destination} -> all except {peoples - placesTo} accommodated");
            }

            destinationTrahsportPeople = Console.ReadLine();
        }
    }
}
