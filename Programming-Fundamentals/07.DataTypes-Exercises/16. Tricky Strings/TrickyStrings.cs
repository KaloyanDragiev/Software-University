namespace _16.Tricky_Strings
{
    using System;
   
    public class TrickyStrings
    {
        public static void Main()
        {
            string delimiter = Console.ReadLine();

            byte linesCounter = byte.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int counter = 1; counter <= linesCounter; counter++)
            {
                string currentString = Console.ReadLine();

                result += counter != linesCounter ? currentString + delimiter : currentString;
            }

            Console.WriteLine(result);
        }
    }
}
