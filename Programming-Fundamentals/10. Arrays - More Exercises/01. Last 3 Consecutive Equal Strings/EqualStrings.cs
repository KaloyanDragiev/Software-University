namespace _01.Last_3_Consecutive_Equal_Strings
{
    using System;

    public class EqualStrings
    {
        public static void Main()
        {
            var givenStrings = Console.ReadLine().Split();
            var stringCounter = 1;
            var counter = givenStrings.Length - 1;
            for (int index = counter; index >= 1; index--)
            {
                if (givenStrings[index] == givenStrings[index - 1])
                {
                    stringCounter++;
                }
                else
                {
                    stringCounter = 1;
                }
                if (stringCounter == 3)
                {
                    Console.WriteLine("{0} {0} {0}", givenStrings[index]);
                    return;
                }
            }
        }
    }
}
