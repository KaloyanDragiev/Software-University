namespace _14.Magic_Letter
{
    using System;
   
    public class MagicLetter
    {
        public static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());

            char lastLetter = char.Parse(Console.ReadLine());

            char controlLetter = char.Parse(Console.ReadLine());

            for (char i = firstLetter; i <= lastLetter; i++)
            {
                for (char j = firstLetter; j <= lastLetter; j++)
                {
                    for (char l = firstLetter; l <= lastLetter; l++)
                    {
                        if (i != controlLetter && j != controlLetter && l != controlLetter)
                        {
                            Console.Write($"{i}{j}{l} ");
                        }
                    }
                }
            }
        }
    }
}
