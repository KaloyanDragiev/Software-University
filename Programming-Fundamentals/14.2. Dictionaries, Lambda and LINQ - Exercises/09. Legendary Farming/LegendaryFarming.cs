using System;
using System.Collections.Generic;
using System.Linq;

public class LegendaryFarming
{
    static Dictionary<string, int> itemsWithTheirValues = new Dictionary<string, int>()
        {
            { "shards", 0 },
            { "motes", 0 },
            { "fragments", 0 }
        };

    public static void Main()
    {
        while (true)
        {
            var nextLine = Console.ReadLine().ToLower().Split(' ');

            var obtainedResource = DivideAndRuleTheNextLine(nextLine);
            if (obtainedResource == "shards")
            {
                PrintWinnerWith(obtainedResource); return;
            }
            else if (obtainedResource == "motes")
            {
                PrintWinnerWith(obtainedResource); return;
            }
            else if (obtainedResource == "fragments")
            {
                PrintWinnerWith(obtainedResource); return;
            }
        }
    }

    static string DivideAndRuleTheNextLine(string[] nextLine)
    {
        for (int index = 1; index < nextLine.LongLength; index += 2)
        {
            var resource = nextLine[index];
            var quantity = Convert.ToInt32(nextLine[index - 1]);

            ParseToTheDictionary(resource, quantity);

            if (CheckForObtaintedLegendaryItem("shards"))
            {
                return "shards";
            }
            else if (CheckForObtaintedLegendaryItem("motes"))
            {
                return "motes";
            }
            else if (CheckForObtaintedLegendaryItem("fragments"))
            {
                return "fragments";
            }
        }
        return string.Empty;
    }

    static void ParseToTheDictionary(string resource, int quantity)
    {
        if (!itemsWithTheirValues.ContainsKey(resource))
        {
            itemsWithTheirValues[resource] = 0;
        }
        itemsWithTheirValues[resource] += quantity;
    }

    static bool CheckForObtaintedLegendaryItem(string resource)
    {
        if (itemsWithTheirValues.ContainsKey(resource))
        {
            if (itemsWithTheirValues[resource] >= 250)
            {
                return true;
            }
        }
        return false;
    }

    static void PrintWinnerWith(string obtainedResource)
    {
        var winnerWithObtainedResource = new Dictionary<string, string>()
        {
            { "shards", "Shadowmourne" },
            { "motes", "Dragonwrath" },
            { "fragments", "Valanyr" }
        };

        Console.WriteLine($"{winnerWithObtainedResource[obtainedResource]} obtained!");

        itemsWithTheirValues[obtainedResource] -= 250;

        var gutsResources = itemsWithTheirValues
            .Where(x => x.Key == "shards" || x.Key == "motes" || x.Key == "fragments")
            .OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        Print(gutsResources);

        var juncs = itemsWithTheirValues
           .Where(x => x.Key != "shards" && x.Key != "motes" && x.Key != "fragments")
           .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        Print(juncs);
    }

    private static void Print(Dictionary<string, int> dictionary)
    {
        foreach (var item in dictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
