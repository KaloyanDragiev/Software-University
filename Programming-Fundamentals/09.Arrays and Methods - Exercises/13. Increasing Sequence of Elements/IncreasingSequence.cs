namespace _13.Increasing_Sequence_of_Elements
{
    using System;

    public class IncreasingSequence
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split(' ');
            var length = sequence.Length;
            var sequenceNumber = 0;
            var matchNumber = 0;
            for (int index = 0; index < length; index++)
            {
                sequenceNumber = Convert.ToInt32(sequence[index]);
                if (sequenceNumber > matchNumber)
                {
                    matchNumber = sequenceNumber;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
