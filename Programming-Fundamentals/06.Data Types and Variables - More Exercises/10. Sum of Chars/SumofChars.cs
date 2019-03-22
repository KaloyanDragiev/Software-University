namespace _10.Sum_of_Chars
{
    using System;
   
    public class SumofChars
    {
        public static void Main()
        {
            byte interations = byte.Parse(Console.ReadLine());

            int ASCIISum = 0;

            for (int input = 0; input < interations; input++)
            {
                ASCIISum += char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {ASCIISum}");
        }
    }
}
