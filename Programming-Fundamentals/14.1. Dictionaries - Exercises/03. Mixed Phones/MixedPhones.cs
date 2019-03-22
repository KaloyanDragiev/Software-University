namespace _03.Mixed_Phones
{
    using System;
    using System.Collections.Generic;

    public class MixedPhones
    {
        public static void Main()
        {
            var nameValueCollection = new SortedDictionary<string, string>();
            var name = string.Empty;
            var number = string.Empty; ;
            for (int infiniatly = 0; ; infiniatly++)
            {
                var enteredData = Console.ReadLine()
                    .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (enteredData[0] == "Over")
                {
                    Print(nameValueCollection);
                    return;
                }

                var value = 0L;
                if (Int64.TryParse(enteredData[0], out value))
                {
                    name = enteredData[1];
                    number = value.ToString(); 
                }
                else
                {
                    name = enteredData[0];
                    number = Int64.Parse(enteredData[1]).ToString();
                }

                if (!nameValueCollection.ContainsKey(name))
                {
                    nameValueCollection[name] = string.Empty;
                }
                nameValueCollection[name] = number;
            }
        }

        static void Print(SortedDictionary<string, string> nameValueCollection)
        {
            foreach (var item in nameValueCollection)
            {
                var name = item.Key;
                var value = item.Value;
                Console.WriteLine($"{name} -> {value}");
            }
        }
    }
}
