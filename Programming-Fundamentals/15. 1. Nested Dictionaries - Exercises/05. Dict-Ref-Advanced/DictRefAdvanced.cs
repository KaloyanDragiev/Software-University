using System;
using System.Collections.Generic;
using System.Linq;

public class DictRefAdvanced
{
    public static void Main()
    {
        var keysWithValues = new Dictionary<string, List<string>>();
        var curentLine = Console.ReadLine();
        while (curentLine != "end")
        {
            var splited = curentLine.Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
            var key = splited[0];
            var values = splited.Skip(1).ToList();

            var number = 0;
            var isValue = int.TryParse(values[0], out number);
            if (!isValue && !keysWithValues.ContainsKey(values[0]))
            {
                curentLine = Console.ReadLine();
                continue;
            }
            if (!isValue && keysWithValues.ContainsKey(values[0]))
            {
                values = keysWithValues[values[0]];
            }

            if (!keysWithValues.ContainsKey(key))
            {
                keysWithValues[key] = new List<string>();
            }
            keysWithValues[key].AddRange(values);

            curentLine = Console.ReadLine();
        }

        foreach (var item in keysWithValues)
        {
            Console.Write($"{item.Key} === ");
            var isFirst = true;
            foreach (var value in item.Value)
            {
                if (isFirst)
                {
                    isFirst = false;
                    Console.Write(value);
                    continue;
                }
                Console.Write(", {0}", value.TrimStart());
            }
            Console.WriteLine();
        }
    }
}
