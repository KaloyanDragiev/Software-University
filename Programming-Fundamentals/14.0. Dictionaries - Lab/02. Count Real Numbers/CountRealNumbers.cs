namespace _02.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountRealNumbers
    {
        public static void Main()
        {
            var enteredStrings = Console.ReadLine().ToLower().Split(' ').Select(double.Parse).ToArray();
            var stringsCollection = new SortedDictionary<double, int>();
            for (int index = 0; index < enteredStrings.Length; index++)
            {
                if (!stringsCollection.ContainsKey(enteredStrings[index]))
                {
                    stringsCollection[enteredStrings[index]] = 0;
                }
                stringsCollection[enteredStrings[index]]++;
            }
            foreach (var item in stringsCollection)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
