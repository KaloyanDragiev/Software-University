﻿namespace _04.SocialMediaPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SocialMediaPosts
    {
        public static void Main()
        {
            var socialMediaPosts = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();

            var enteredLine = Console.ReadLine().Split(' ').ToList();
            while (enteredLine[0] != "drop")
            {
                var postCount = string.Empty;
                var post = string.Empty;
                var comentator = string.Empty;

                if (enteredLine[0] == "post")
                {
                    postCount = enteredLine[1];
                    if (!socialMediaPosts.ContainsKey(postCount))
                    {
                        socialMediaPosts[postCount] = new Dictionary<string, Dictionary<string, List<string>>>();
                    }
                    socialMediaPosts[postCount]["Likes"] = new Dictionary<string, List<string>>();
                    socialMediaPosts[postCount]["Likes"]["like"] = new List<string>();

                    socialMediaPosts[postCount]["Dislikes"] = new Dictionary<string, List<string>>();
                    socialMediaPosts[postCount]["Dislikes"]["dislike"] = new List<string>();

                    socialMediaPosts[postCount]["comment"] = new Dictionary<string, List<string>>();
                }
                else if (enteredLine[0] == "like")
                {
                    postCount = enteredLine[1];
                    socialMediaPosts[postCount]["Likes"]["like"].Add("1");
                }
                else if (enteredLine[0] == "dislike")
                {
                    postCount = enteredLine[1];
                    socialMediaPosts[postCount]["Dislikes"]["dislike"].Add("1");
                }
                else if (enteredLine[0] == "comment")
                {
                    postCount = enteredLine[1];
                    comentator = enteredLine[2];
                    if (!socialMediaPosts[postCount]["comment"].ContainsKey(comentator))
                    {
                        socialMediaPosts[postCount]["comment"][comentator] = new List<string>();
                    }
                    for (int i = 3; i < enteredLine.Count; i++)
                    {
                        socialMediaPosts[postCount]["comment"][comentator].Add(enteredLine[i]);
                    }
                }

                enteredLine = Console.ReadLine().Split(' ').ToList();
            }

            foreach (var key in socialMediaPosts.Keys)
            {
                Console.Write($"Post: {key}");
                foreach (var item in socialMediaPosts[key].Keys)
                {
                    if (item != "comment")
                    {
                        Console.Write($" | {item}: ");
                        foreach (var keys in socialMediaPosts[key][item])
                        {
                            Console.Write($"{keys.Value.Count}");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Comments:");
                        foreach (var keys in socialMediaPosts[key][item])
                        {
                            Console.WriteLine($"*  {keys.Key}: {string.Join(" ", keys.Value)}");
                        }
                    }
                    if (socialMediaPosts[key][item].Count == 0)
                    {
                        Console.WriteLine("None");
                    }
                }
            }
        }
    }
}