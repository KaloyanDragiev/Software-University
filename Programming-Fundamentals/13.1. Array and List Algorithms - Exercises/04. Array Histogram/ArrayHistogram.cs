namespace _04.Array_Histogram
{
    using System;
    using System.Linq;

    public class ArrayHistogram
    {
        public static void Main()
        {
            var stringArray = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stringArrayElements = new string[stringArray.Length];
            var stringArrayCounter = new int[stringArray.Length];
            var divider = 0.0;
            var stringArrayCounterIndex = 0;
            var previewusString = string.Empty;
            for (int firstIndex = 0; firstIndex < stringArray.Length; firstIndex++)
            {
                var equalStringCounter = 0;
                for (int secondIndex = firstIndex; secondIndex < stringArray.Length; secondIndex++)
                {
                    if (stringArray[firstIndex] == stringArray[secondIndex] && 
                        !stringArrayElements.Contains(stringArray[secondIndex]))
                    {
                        divider++;
                        equalStringCounter++;
                    }
                    previewusString = stringArray[firstIndex];
                }
                stringArrayElements[stringArrayCounterIndex] = stringArray[firstIndex];
                stringArrayCounter[stringArrayCounterIndex] = equalStringCounter;
                stringArrayCounterIndex++;
            }
            SortStringsArrays(stringArrayCounter, stringArrayElements);
            for (int index = 0; index < stringArray.Length; index++)
            {
                if (stringArrayCounter[index] > 0)
                {
                    Console.WriteLine("{0} -> {1} times ({2:F2}%)",
                    stringArrayElements[index], stringArrayCounter[index],
                    stringArrayCounter[index] / divider * 100);
                }
            }
        }

        private static void SortStringsArrays(int[] stringArrayCounter, string[] stringArrayElements)
        {
            for (int counter = 0; ; counter++)
            {
                var swaped = false;
                for (int index = 0; index < stringArrayCounter.Length - 1; index++)
                {
                    if (stringArrayCounter[index].CompareTo(stringArrayCounter[index + 1]) < 0)
                    {
                        swaped = true; 
                        var temporaryNumber = stringArrayCounter[index];
                        var temporaryString = stringArrayElements[index];
                        stringArrayCounter[index] = stringArrayCounter[index + 1];
                        stringArrayElements[index] = stringArrayElements[index + 1];
                        stringArrayCounter[index + 1] = temporaryNumber;
                        stringArrayElements[index + 1] = temporaryString;
                    }
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
    }
}
