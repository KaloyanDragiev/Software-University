namespace _05.Sort_Array_Using_Insertion_Sort
{
    using System;
    using System.Linq;

    public class InsertionSort
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
            for (int counter = 0; counter < givenSequence.Length; counter++)
            {
                for (int index = counter; index > 0; index--)
                {
                    if (givenSequence[index - 1] > givenSequence[index])
                    {
                        Swap(ref givenSequence[index - 1], ref givenSequence[index]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return givenSequence;
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            var temporaryNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temporaryNumber;
        }
    }
}
