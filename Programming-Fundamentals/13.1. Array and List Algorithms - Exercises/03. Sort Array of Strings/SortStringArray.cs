namespace _03.Sort_Array_of_Strings
{
    using System;

    public class SortStringArray
    {
        public static void Main()
        {
            var unsortedStringArray = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int counter = 0; ; counter++)
            {
                var swaped = false;
                for (int index = 0; index < unsortedStringArray.Length - 1; index++)
                {
                    if (unsortedStringArray[index].CompareTo(unsortedStringArray[index + 1]) > 0)
                    {
                        swaped = true;
                        var temporaryString = unsortedStringArray[index];
                        unsortedStringArray[index] = unsortedStringArray[index + 1];
                        unsortedStringArray[index + 1] = temporaryString;
                    }
                }
                if (!swaped)
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", unsortedStringArray));
        }
    }
}
