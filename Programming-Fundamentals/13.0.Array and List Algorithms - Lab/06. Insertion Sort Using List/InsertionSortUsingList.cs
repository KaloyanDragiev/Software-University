namespace _06.Insertion_Sort_Using_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InsertionSortUsingList
    {
        static List<int> givvenSequence;

        public static void Main()
        {
            givvenSequence = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            SortByDescending();
            PrintResult();
        }

        private static void SortByDescending()
        {
            for (int index = 1; index < givvenSequence.Count; index++)
            {
                if (givvenSequence[index - 1] < givvenSequence[index])
                {
                    var max = givvenSequence[index];
                    givvenSequence.Remove(givvenSequence[index]);
                    for (int counter = 0; counter < givvenSequence.Count; counter++)
                    {
                        if (givvenSequence[counter] < max)
                        {
                            givvenSequence.Insert(counter, max);
                        }
                    }
                    index--;
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", givvenSequence));
        }
    }
}
