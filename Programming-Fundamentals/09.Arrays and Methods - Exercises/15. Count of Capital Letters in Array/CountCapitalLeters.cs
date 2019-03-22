namespace _15.Count_of_Capital_Letters_in_Array
{
    using System;

    public class CountCapitalLeters
    {
        public static void Main()
        {
            var sentence = Console.ReadLine().Split(' ');
            var elsementsCount = sentence.Length;
            var capitalLetersCounter = 0;
            var elsement = ' ';
            var isChar = true;
            for (int index = 0; index < elsementsCount; index++)
            {
                isChar = char.TryParse(sentence[index], out elsement);
                if (elsement >= 'A' && elsement <= 'Z')
                {
                    capitalLetersCounter++;
                }
            }
            Console.WriteLine(capitalLetersCounter);
        }
    }
}
