namespace _03.Mirror_Image
{
    using System;

    public class MirrorImage
    {
        public static void Main()
        {
            var currentArray = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var indexer = Console.ReadLine();
            for (int infiniatly = 0; ; infiniatly++)
            {
                if (indexer == "Print")
                {
                    break;
                }
                else
                {
                    var indexFromReversing = Convert.ToInt32(indexer);

                    var startLeftIndex = 0;
                    var toEndIndex = indexFromReversing - 1;
                    var reverseLeftSide = SideReversing(currentArray, startLeftIndex, toEndIndex);

                    startLeftIndex = indexFromReversing + 1;
                    toEndIndex = currentArray.Length - 1;
                    var reverseRightSide = SideReversing(currentArray, startLeftIndex, toEndIndex);
                }

                indexer = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", currentArray));
        }

        private static string[] SideReversing(string[] currentArray, int start, int end)
        {
            var reverseIndex = 0;
            for (int index = start; index <= end; index += 2)
            {
                var temporaryElement = currentArray[start + reverseIndex];
                currentArray[start + reverseIndex] = currentArray[end - reverseIndex];
                currentArray[end - reverseIndex] = temporaryElement;
                reverseIndex++;
            }
            return currentArray;
        }
    }
}
