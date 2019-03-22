using System;
using System.Collections.Generic;
using System.Linq;

public class ForumTopics
{
    static Dictionary<string, HashSet<string>> forumHistogram = new Dictionary<string, HashSet<string>>();

    public static void Main()
    {
        var forumHistogram = new Dictionary<string, HashSet<string>>();
        var currentLine = Console.ReadLine();
        while (currentLine != "filter")
        {
            var splited = currentLine.Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            var topic = splited[0];
            var tags = splited.Skip(1).ToArray();

            if (!forumHistogram.ContainsKey(topic))
            {
                forumHistogram[topic] = new HashSet<string>();
            }
            AddRange(forumHistogram, topic, tags);

            currentLine = Console.ReadLine();
        }

        var filters = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        PrintMatchedTopics(forumHistogram, filters);
    }

    static void AddRange(Dictionary<string, HashSet<string>> forumHistogram, string topic, string[] tags)
    {
        foreach (var tag in tags)
        {
            forumHistogram[topic].Add($"#{tag}");
        }
    }

    static void PrintMatchedTopics(
        Dictionary<string, HashSet<string>> forumHistogram, string[] filters)
    {
        foreach (var topic in forumHistogram)
        {
            var contains = true;
            foreach (var tag in filters)
            {
                if (!topic.Value.Contains($"#{tag}"))
                {
                    contains = false;
                }
            }
            if (contains)
            {
                Console.WriteLine($"{topic.Key} | {string.Join(", ", topic.Value)}");
            }
        }
    }
}
