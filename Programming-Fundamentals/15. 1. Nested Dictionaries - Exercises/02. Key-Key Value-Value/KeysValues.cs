using System;
using System.Collections.Generic;
using System.Linq;

public class KeysValues
{
    public static void Main()
    {
        var collectionFromKeysValues = new Dictionary<string, List<string>>();
        var key = Console.ReadLine();
        var value = Console.ReadLine();
        var lines = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < lines; count++)
        {
            var currentLine = Console.ReadLine().Split(new[] { ' ', ';' });
            var givenKey = currentLine[0];
            var givenValues = currentLine.Skip(1);
            if (givenKey.Contains(key))
            {
                if (!collectionFromKeysValues.ContainsKey(givenKey))
                {
                    collectionFromKeysValues[givenKey] = new List<string>();
                }
                foreach (var vallue in givenValues)
                {
                    if (value.Contains(vallue) || vallue.Contains(value))
                    {
                        collectionFromKeysValues[givenKey].Add(vallue);
                    }
                }
            }
        }

        foreach (var item in collectionFromKeysValues)
        {
            Console.WriteLine("{0}:", item.Key);
            foreach (var element in item.Value)
            {
                Console.WriteLine("-{0}", element);
            }
        }
    }
}
