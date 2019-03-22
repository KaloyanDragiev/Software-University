namespace _05.Word_in_Plural
{
    using System;

    public class WordPlural
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            if (word[word.Length - 1] == 'y')
            {
                word = word.Remove(word.Length - 1, 1);

                word += "ies";
            }
            else if (word[word.Length - 1] == 'o' || word[word.Length - 1] == 'h' ||
                
                word[word.Length - 1] == 's' || word[word.Length - 1] == 'x' ||

                word[word.Length - 1] == 'z')
            {
                word += "es";
            }
            else
            {
                word += "s";
            }

            Console.WriteLine(word);
        }
    }
}
