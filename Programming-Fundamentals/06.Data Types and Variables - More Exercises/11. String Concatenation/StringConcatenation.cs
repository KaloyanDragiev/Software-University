namespace _11.String_Concatenation
{
    using System;
   
    public class StringConcatenation
    {
        public static void Main()
        {
            string delimiter = Console.ReadLine();
            string evenOrOddPossitions = Console.ReadLine();
            byte numberOfIternations = byte.Parse(Console.ReadLine());

            string outputResult = string.Empty;
            int wordsCounter = 0;

            bool isEven = evenOrOddPossitions == "even" ? true : false;

            for (int possition = 1; possition <= numberOfIternations; possition++)
            {
                string currentWord = Console.ReadLine();

                if (isEven && possition % 2 == 0)
                {
                    wordsCounter++;
                    outputResult += wordsCounter == 1 ? currentWord : delimiter + currentWord;
                }
                else if (!isEven && possition % 2 == 1)
                {
                    wordsCounter++;
                    outputResult += wordsCounter == 1 ? currentWord : delimiter + currentWord;
                }
            }

            Console.WriteLine(outputResult);
        }
    }
}
