namespace _03.Search_for_a_Number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SearchNumber
    {
        public static void Main()
        {
            var currentSequense = Console.ReadLine().Split().ToList();
            var action = Console.ReadLine().Split();

            var toTake = Convert.ToInt32(action[0]);
            var toSkip = Convert.ToInt32(action[1]);
            var toSearch = action[2];

            ////currentSequense = currentSequense.Take(toTake).ToList();
            ////currentSequense = currentSequense.Skip(toSkip).ToList();
            ////var hasElement = currentSequense.Contains(toSearch);
            //var hasElement = currentSequense.Take(toTake).Skip(toSkip).ToList().Contains(toSearch);
            currentSequense = Take(currentSequense, toTake);           
            currentSequense = Skip(currentSequense, toSkip);
            for (int index = 0; index < currentSequense.Count; index++)
            {
                if (currentSequense[index] == toSearch)
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }
            Console.WriteLine(/*hasElement? "YES!" : */"NO!");
        }

        public static List<string> Skip(List<string> currentSequense, int toSkip)
        {
            var newSequence = new List<string>();
            for (int index = toSkip; index < currentSequense.Count; index++)
            {
                newSequence.Add(currentSequense[index]);
            }
            return newSequence;
        }

        private static List<string>Take(List<string> currentSequense, int toTake)
        {
            var newSequence = new List<string>();
            for (int index = 0; index < toTake; index++)
            {
                newSequence.Add(currentSequense[index]);
            }
            return newSequence;
        }
    }
}
