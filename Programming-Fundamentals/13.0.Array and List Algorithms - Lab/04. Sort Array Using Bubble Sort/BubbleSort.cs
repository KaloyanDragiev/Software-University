namespace _04.Sort_Array_Using_Bubble_Sort
{
    using System;
    using System.Linq;

    public class BubbleSort
    {
        static Int32[] givenSequence;

        public static void Main()
        {
            givenSequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Int32.Parse).ToArray();

            Console.WriteLine(string.Join(" ", SortedArray()));
        }

        static Int32[] SortedArray()
        {
            for (int counter = 0; ; counter ++)
            {
                var wasSwapped = false;
                for (int index = 1; index < givenSequence.Length; index++)
                {
                    var temporaryElement = 0;
                    if (givenSequence[index - 1] > givenSequence[index])
                    {
                        temporaryElement = givenSequence[index - 1];
                        givenSequence[index - 1] = givenSequence[index];
                        givenSequence[index] = temporaryElement;
                        wasSwapped = true;
                    }
                }
                if (!wasSwapped)
                {
                    return givenSequence;
                }
            }
        }
    }
}
