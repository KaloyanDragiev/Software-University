using System;
using System.Collections.Generic;
using System.Linq;

public class UserLogs
{
    static SortedDictionary<string, Dictionary<string, int>> usersHistogram =
        new SortedDictionary<string, Dictionary<string, int>>();

    public static void Main()
    {
        var currentUserActivity = Console.ReadLine().Split(' ');
        while (currentUserActivity[0] != "end")
        {

            var user = currentUserActivity[2].Split('=').Last();
            var IP = currentUserActivity[0].Split('=').Last();
            var message = currentUserActivity[1].Split('\'').Last();

            if (!usersHistogram.ContainsKey(user))
            {
                usersHistogram[user] = new Dictionary<string, int>();
            }
            if (!usersHistogram[user].ContainsKey(IP))
            {
                usersHistogram[user][IP] = 0;
            }
            usersHistogram[user][IP] += 1;

            currentUserActivity = Console.ReadLine().Split(' ');
        }

        foreach (var user in usersHistogram)
        {
            Console.WriteLine($"{user.Key}: ");
            var counter = user.Value.Count - 1;
            foreach (var IP in user.Value)
            {
                if (counter == 0)
                {
                    Console.WriteLine($"{IP.Key} => {IP.Value}.");
                    break;
                }
                Console.Write($"{IP.Key} => {IP.Value}, ");
                counter--;
            }
        }
    }
}