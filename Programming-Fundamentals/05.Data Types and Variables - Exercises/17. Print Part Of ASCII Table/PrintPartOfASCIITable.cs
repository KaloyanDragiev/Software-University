namespace _17.Print_Part_Of_ASCII_Table
{
    using System;
    
    public class PrintPartOfASCIITable
    {
        public static void Main()
        {
            byte startIndex = byte.Parse(Console.ReadLine());
            byte endIndex = byte.Parse(Console.ReadLine());

            for (byte index = startIndex; index <= endIndex; index++)
            {
                Console.Write((char)index + " ");
            }
        }
    }
}
