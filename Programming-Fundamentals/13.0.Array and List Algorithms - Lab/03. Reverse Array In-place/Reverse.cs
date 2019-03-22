namespace _03.Reverse_Array_In_place
{
    using System;

    public class Sort
    {
        public string[] SequenceToSorting { get; set; }
    }

    public class Reverse
    {
            static string[] givenSequence;

        public static void Main()
        {
            givenSequence = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var wontedElement = Console.ReadLine();
            Console.WriteLine(string.Join(" ", ReverseArray()));
        }

        static string[] ReverseArray()
        {
            for (int index = 0; index < givenSequence.Length / 2; index++)
            {
                var currentElement = givenSequence[index];
                givenSequence[index] = givenSequence[givenSequence.Length - 1 - index];
                givenSequence[givenSequence.Length - 1 - index] = currentElement;
            }
            return givenSequence;
        }
    }
}
