using System;
using System.Collections.Generic;
using System.Linq;

public class Aggregator
{
    static SortedDictionary<string, SortedDictionary<string, int>> agregatedLogs =
        new SortedDictionary<string, SortedDictionary<string, int>>();

    public static void Main()
    {
        var followigLogs = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < followigLogs; count++)
        {
            var currentOperation = Console.ReadLine().Split(' ');
            var user = currentOperation[1];
            var IP = currentOperation[0];
            var duration = Convert.ToInt32(currentOperation[2]);

            if (!agregatedLogs.ContainsKey(user))
            {
                agregatedLogs[user] = new SortedDictionary<string, int>();
            }
            if (!agregatedLogs[user].ContainsKey(IP))
            {
                agregatedLogs[user][IP] = 0;
            }
            agregatedLogs[user][IP] += duration;
        }

        foreach (var user in agregatedLogs)
        {
            var durationSum = user.Value.ToDictionary(x => x.Key, x => x.Value).Values.Sum();
            Console.Write($"{user.Key}: {durationSum} [");
            var isFirst = true;
            foreach (var IP in user.Value)
            {
                if (isFirst)
                {
                    Console.Write(IP.Key);
                    isFirst = false;
                    continue;
                }
                Console.Write(", {0}", IP.Key);
            }
            Console.WriteLine("]");
        }
    }
}
