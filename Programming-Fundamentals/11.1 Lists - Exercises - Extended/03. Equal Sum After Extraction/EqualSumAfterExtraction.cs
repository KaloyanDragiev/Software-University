namespace _03.Equal_Sum_After_Extraction
{
    using System;
    using System.Linq;

    public class EqualSumAfterExtraction
    {
        public static void Main()
        {
            var firstSequence = Console.ReadLine().Split()/*.Select(int.Parse)*/.ToList();
            var secondSequence = Console.ReadLine().Split()/*.Select(int.Parse)*/.ToList();
            var iterations = firstSequence.Count;
            for (int count = 0; count < iterations; count++)
            {
                if (secondSequence.Contains(firstSequence[count]))
                {
                    secondSequence.RemoveAll(x => x == firstSequence[count]);
                }
            }

            var firstSequenceSum = 0;//firstSequence.Sum();
            for (int index = 0; index < iterations; index++)
            {
                firstSequenceSum += Convert.ToInt16(firstSequence[index]);
            }

            var secondSequenceSum = 0;//secondSequence.Sum();
            iterations = secondSequence.Count;
            for (int index = 0; index < iterations; index++)
            {
                secondSequenceSum += Convert.ToInt16(secondSequence[index]);
            }
            Console.WriteLine(firstSequenceSum == secondSequenceSum ? 
                $"Yes. Sum: {firstSequenceSum}" : 
                $"No. Diff: {Math.Abs(firstSequenceSum - secondSequenceSum)}");
        }
    }
}
