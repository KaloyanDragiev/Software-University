namespace _14.ASCII_String
{
    using System;
  
    public class ASCIIString
    {
        public static void Main()
        {
            byte commingLines = byte.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int counter = 0; counter < commingLines; counter++)
            {
                byte currentSymbol = byte.Parse(Console.ReadLine());

                result += (char)currentSymbol;
            }

            Console.WriteLine(result);
        }
    }
}
