using System;
using System.Collections.Generic;

public class RecordUniqueNames
{
    public static void Main()
    {
        var uniqueNamesCollection = new HashSet<string>();

        var nextGivenNamesCounter = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < nextGivenNamesCounter; count++)
        {
            var currentName = Console.ReadLine();
            uniqueNamesCollection.Add(currentName);
        }

        foreach (var name in uniqueNamesCollection)
        {
            Console.WriteLine(name);
        }
    }
}
