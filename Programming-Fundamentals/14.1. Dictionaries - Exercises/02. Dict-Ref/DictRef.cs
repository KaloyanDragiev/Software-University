namespace _02.Dict_Ref
{
    using System;
    using System.Collections.Generic;

    public class DictRef
    {
        public static void Main()
        {
            var nameValueCollection = new Dictionary<string, string>();
            for (int infiniatly = 0; ; infiniatly++)
            {
                var enteredData = Console.ReadLine()
                    .Split(new[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (enteredData[0] == "end")
                {
                    Print(nameValueCollection);
                    return;
                }

                var name = enteredData[0];
                var value = 0;
                if (Int32.TryParse(enteredData[1], out value))
                {
                    if (!nameValueCollection.ContainsKey(name))
                    {
                        nameValueCollection[name] = string.Empty;
                    }
                    nameValueCollection[name] = value.ToString();
                }
                else
                {
                    var valueAsString = enteredData[1];
                    if (nameValueCollection.ContainsKey(valueAsString))
                    {
                        valueAsString = nameValueCollection[valueAsString];
                        nameValueCollection[name] = valueAsString;
                    }
                }
            }
        }

        static void Print(Dictionary<string, string> nameValueCollection)
        {
            foreach (var item in nameValueCollection)
            {
                var name = item.Key;
                var value = item.Value;
                Console.WriteLine($"{name} === {value}");
            }
        }
    }
}