namespace _13.Vowel_or_Digit
{
    using System;
    using System.Collections.Generic;
  
    public class VowelDigit
    {
        public static void Main()
        {
            string symbol = Console.ReadLine();

            string vowels = "AEIOUYaeiouy";

            string digits = "0123456789";

            if (vowels.Contains(symbol))
            {
                Console.WriteLine("vowel");
            }
            else if (digits.Contains(symbol))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
