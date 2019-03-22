namespace _02.Average_Character_Delimiter
{
    using System;

    public class AverageCharacterDelimiter
    {
        public static void Main()
        {
            var givenSequence = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var arrayToString = string.Join(string.Empty, givenSequence);
            var averageSymbolSum = 0.0;
            var symbolCounter = arrayToString.Length;
            for (int counter = 0; counter < symbolCounter; counter++)
            {
                averageSymbolSum += arrayToString[counter];
            }
            Math.Ceiling(averageSymbolSum /= symbolCounter);
            var delimiter = (char)averageSymbolSum;
            Console.WriteLine(string.Join($"{delimiter.ToString().ToUpper()}", givenSequence));
        }
    }
}
