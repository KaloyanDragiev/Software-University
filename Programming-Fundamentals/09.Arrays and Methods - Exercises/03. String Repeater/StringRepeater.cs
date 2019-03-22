namespace _03.String_Repeater
{
    using System;

    public class StringRepeater
    {
        public static void Main()
        {
            string testString = Console.ReadLine();
            byte repeatCount = byte.Parse(Console.ReadLine());

            Repeat(testString, repeatCount); 
        }

        public static void Repeat(string testString, byte repeatCount)
        {
            for (int count = 0; count < repeatCount; count++)
            {
                Console.Write(testString);
            }
        }
    }
}
