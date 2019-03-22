namespace MyTemplate1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EqualElements
    {
        public static void Main()
        {
            var givenSequence = Console.ReadLine().Split().ToList();
            var resultSequence = new List<string>();
            for (var i = 0; i < givenSequence.Count; i++)
            {
                var tempMaxSequence = new List<string>();
                tempMaxSequence.Add(givenSequence[i]);
                for (var j = i + 1; j < givenSequence.Count; j++)
                {
                    if (givenSequence[j] == givenSequence[i])
                    {
                        tempMaxSequence.Add(givenSequence[j]);
                    }
                    else
                    {
                        break;
                    }
                }
                if (tempMaxSequence.Count() > resultSequence.Count())
                {
                    resultSequence = tempMaxSequence;
                }
            }
            Console.WriteLine(string.Join(" ", resultSequence));
        }
    }
}
