namespace _05.Char_Rotation
{
    using System;

    public class CharRotation
    {
        public static void Main()
        {
            var symbols = Console.ReadLine();
            var numbers = Console.ReadLine().Split();
            var currentNumber = 0;
            var sumSymbolsNumbers = 0;
            for (int index = 0; index < symbols.Length; index++)
            {
                currentNumber = Convert.ToInt32(numbers[index]);
                if (currentNumber % 2 == 0)
                {
                    sumSymbolsNumbers = symbols[index] - currentNumber;
                    Console.Write((char)sumSymbolsNumbers);
                }
                else
                {
                    sumSymbolsNumbers = symbols[index] + currentNumber;
                    Console.Write((char)sumSymbolsNumbers);
                }
            }
        }
    }
}
