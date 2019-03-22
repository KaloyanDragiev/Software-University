namespace _01._Odd_Occurrences
{
    using System;
    using System.Collections.Generic;

    public class OddOccurrences
    {
        public static void Main()
        {
            var enteredStrings = Console.ReadLine().ToLower().Split(' ');
            var stringsCollection = new Dictionary<string, int>();
            for (int index = 0; index < enteredStrings.Length; index++)
            {
                if (!stringsCollection.ContainsKey(enteredStrings[index]))
                {
                    stringsCollection[enteredStrings[index]] = 0;
                }
                stringsCollection[enteredStrings[index]]++;
            }
            var isFirst = true;
            foreach (var item in stringsCollection)
            {
                if (item.Value % 2 == 1 && isFirst)
                {
                    Console.Write(item.Key);
                    isFirst = false;
                }
                else if (item.Value % 2 == 1 && !isFirst)
                {
                    Console.Write($", {item.Key}");
                }
            }
            Console.WriteLine();
        }
    }
}
