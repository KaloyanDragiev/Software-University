namespace _06.Stuck_Zipper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StuckZipper
    {
        public static void Main()
        {
            var firstSequence = Console.ReadLine().Split().ToList();
            var lastSequence = Console.ReadLine().Split().ToList();

            var firstMinLength = FindMinLength(firstSequence);
            var lastMinLength = FindMinLength(lastSequence);
            var minLength = Math.Min(firstMinLength, lastMinLength);

            firstSequence.RemoveAll(x => Math.Abs(Convert.ToInt32(x)).ToString().Length > minLength);
            lastSequence.RemoveAll(x => Math.Abs(Convert.ToInt32(x)).ToString().Length > minLength);

            if (firstSequence.Count > lastSequence.Count)
            {
                var counter = 0;
                InsertAndPrint(firstSequence, lastSequence, counter);
                return;
            }
            else
            {
                var counter = 1;
                InsertAndPrint(lastSequence, firstSequence, counter);
                return;
            }
        }

        private static Int32 FindMinLength(List<string> currentSequence)
        {
            var minNumber = int.MaxValue;
            var currentNumber = 0;
            var iterations = currentSequence.Count;
            for (int index = 0; index < iterations; index++)
            {
                currentNumber = Math.Abs(Convert.ToInt32(currentSequence[index])).ToString().Length;
                if (minNumber >= currentNumber)
                {
                    minNumber = currentNumber;
                }
            }
            return minNumber;
        }
        private static void InsertAndPrint(List<string> firstSequence, List<string> lastSequence, int counter)
        {
            var iterations = lastSequence.Count;
            for (int index = 0; index < iterations; index++)
            {
                firstSequence.Insert(counter, lastSequence[index]);
                counter += 2;
            }
            Console.WriteLine(string.Join(" ", firstSequence));
        }

    }
}
