namespace _14.Equal_Sequence_of_Elements_in_Array
{
    using System;

    public class EqualElements
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split();
            var length = sequence.Length;
            var matchElement = Convert.ToInt32(sequence[0]);
            var isEqual = 0;
            for (int index = 1; index < length; index++)
            {
                isEqual = Convert.ToInt32(sequence[index]);
                if (isEqual > matchElement || isEqual < matchElement)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
