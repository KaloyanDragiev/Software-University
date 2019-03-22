namespace _02.Binary_Search
{
    using System;
    using System.Linq;

    public class BinarySearch
    {
        public static void Main()
        {
            var givenElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var target = Convert.ToInt32(Console.ReadLine());

            var linearSearchIterations = LinearSearchig(givenElements, target);

            var binarySearchIterations = BinarySearching(givenElements, target);

            if (linearSearchIterations < givenElements.Length + 1)
            {
                Console.WriteLine("Yes");

                if (linearSearchIterations > 0)
                {
                    Console.WriteLine($"Linear search made {linearSearchIterations} iterations");
                }
                if (binarySearchIterations > 0)
                {
                    Console.WriteLine($"Binary search made {binarySearchIterations} iterations");
                }
                return;
            }
            else
            {
                Console.WriteLine("No");

                if (linearSearchIterations > 0)
                {
                    Console.WriteLine($"Linear search made {linearSearchIterations - 1} iterations");
                }
                if (binarySearchIterations > 0)
                {
                    Console.WriteLine($"Binary search made {binarySearchIterations} iterations");
                }
                return;
            }
        }

        private static int LinearSearchig(int[] givenElements, int target)
        {
            for (int i = 0; i < givenElements.Length; i++)
            {
                if (givenElements[i] == target)
                {
                    return i + 1;
                }
            }
            return givenElements.Length + 1;
        }

        private static int BinarySearching(int[] givenElements, int target)
        {
            givenElements = Sorting(givenElements);

            var firstIndex = 0;

            var lastIndex = givenElements.Length - 1;

            var counter = 0;

            while (firstIndex < lastIndex)
            {
                counter++;

                var averageIndex = (firstIndex + lastIndex) / 2;

                if (givenElements[averageIndex] == target)
                {
                    return counter;
                }
                else if (givenElements[averageIndex] > target)
                {
                    lastIndex = averageIndex - 1;
                }
                else if (givenElements[averageIndex] < target)
                {
                    firstIndex = averageIndex + 1;
                }
            }
            return ++counter;
        }

        private static int[] Sorting(int[] givenElements)
        {
            for (int infinietly = 0; ; infinietly++)
            {
                var wasSwapped = false;

                for (int index = 1; index < givenElements.Length; index++)
                {
                    if (givenElements[index] < givenElements[index - 1])
                    {
                        var temporaryElement = givenElements[index];

                        givenElements[index] = givenElements[index - 1];

                        givenElements[index - 1] = temporaryElement;

                        wasSwapped = true;
                    }
                }
                if (!wasSwapped)
                {
                    return givenElements;
                }
            }
        }
    }
}