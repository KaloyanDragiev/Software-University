namespace _04.Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        static void Main()
        {
            var currentSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var longestIncreasingSequence = LongestIncreasingSequence(currentSequence);
            Console.WriteLine(string.Join(" ", longestIncreasingSequence));
        }

        static int[] LongestIncreasingSequence(int[] currentSequence)
        {
            var sequenceLengths = new int[currentSequence.Length];
            var previewsIndexes = new int[currentSequence.Length];
            var currentLongLength = 0;
            var lastIndex = -1;

            var iterations = currentSequence.Length;
            for (int index = 0; index < iterations; index++)
            {
                sequenceLengths[index] = 1;
                previewsIndexes[index] = -1;

                var numFromIndex = currentSequence[index];
                for (int count = 0; count < index; count++)
                {
                    var currentNumber = currentSequence[count];
                    if (numFromIndex > currentNumber && sequenceLengths[count] + 1 > sequenceLengths[index])
                    {
                        sequenceLengths[index] = sequenceLengths[count] + 1;
                        previewsIndexes[index] = count;
                    }
                }

                if (sequenceLengths[index] > currentLongLength)
                {
                    currentLongLength = sequenceLengths[index];
                    lastIndex = index;
                }
            }
            var returnLongestsequence = new List<int>();
            while (lastIndex != -1)
            {
                var nextNumber = currentSequence[lastIndex];
                returnLongestsequence.Add(nextNumber);
                lastIndex = previewsIndexes[lastIndex];
            }
            returnLongestsequence.Reverse();
            return returnLongestsequence.ToArray();
        }
    }       
}