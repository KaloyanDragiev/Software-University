namespace _02.Smallest_Element_in_Array
{
    using System;
    using System.Linq;

    public class SmallestElement
    {
        static int[] givenSequence;

        public static void Main()
        {
            givenSequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var wontedElement = Console.ReadLine();
            Console.WriteLine(Min());
        }

        static Int32 Min()
        {
            var minElement = int.MaxValue;
            for (int index = 0; index < givenSequence.Length; index++)
            {
                var currentElement = givenSequence[index];
                if (minElement > currentElement)
                {
                    minElement = currentElement;
                }
            }
            return minElement;
        }
    }
}