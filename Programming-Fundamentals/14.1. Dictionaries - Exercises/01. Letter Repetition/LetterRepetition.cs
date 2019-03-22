namespace _01.Letter_Repetition
{
    using System;
    using System.Collections.Generic;

    public class LetterRepetition
    {
        public static void Main()
        {
            var number = int.Parse("1");
            var letterCollection = new Dictionary<char, byte>();
            var enteredString = Console.ReadLine();
            for (int index = 0; index < enteredString.Length; index++)
            {
                if (!letterCollection.ContainsKey(enteredString[index]))
                {
                    letterCollection[enteredString[index]] = 0;
                }
                letterCollection[enteredString[index]]++;
            }
            foreach (var item in letterCollection)
            {
                var key = item.Key;
                var value = item.Value;
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
