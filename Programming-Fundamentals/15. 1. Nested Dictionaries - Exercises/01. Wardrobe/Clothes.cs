using System;
using System.Collections.Generic;
using System.Linq;

public class Clothes
{
    public static void Main()
    {
        var garderobe = new Dictionary<string, Dictionary<string, int>>();

        var collorClothesCounter = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < collorClothesCounter; count++)
        {
            var currentCollorClothes = Console.ReadLine()
                .Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
            var collor = currentCollorClothes[0];
            var clothes = currentCollorClothes.Skip(1);

            if (!garderobe.ContainsKey(collor))
            {
                garderobe[collor] = new Dictionary<string, int>();
            }
            foreach (var item in clothes)
            {
                if (!garderobe[collor].ContainsKey(item))
                {
                    garderobe[collor][item] = 0;
                }
                garderobe[collor][item]++;
            }
        }

        var findByCollorAndKind = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var byCollor = findByCollorAndKind[0];
        var byKind = findByCollorAndKind[1];

        foreach (var collor in garderobe)
        {
            Console.WriteLine($"{collor.Key} clothes:");
            foreach (var clothe in collor.Value)
            {
                if (collor.Key == byCollor && clothe.Key == byKind)
                {
                    Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    continue;
                }
                Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
            }
        }
    }
}
