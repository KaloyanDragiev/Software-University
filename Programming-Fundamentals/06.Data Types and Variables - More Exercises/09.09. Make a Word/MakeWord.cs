namespace _09._09.Make_a_Word
{
    using System;
   
    public class MakeWord
    {
        public static void Main()
        {
            byte interations = byte.Parse(Console.ReadLine());

            string endWord = string.Empty;

            for (int input = 0; input < interations; input++)
            {
                endWord += Console.ReadLine();
            }

            Console.WriteLine($"The word is: {endWord}");
        }
    }
}
