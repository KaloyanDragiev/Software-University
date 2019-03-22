using System;

namespace NumberAsWords
{
    class NumberWord
    {
        static string[] one = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeeen", "eighteen", "nineteen" };
        static string[] ten = new string[] { null, null, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        static void Main()
        {
            int a;
            if (int.TryParse(Console.ReadLine(), out a))
            {
                if (a > 999 || a < 0)
                {
                    Console.Error.WriteLine("the number is either too big or negative");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.Error.WriteLine("invalid number");
                Environment.Exit(1);
            }

            int hundreds = a / 100;
            int tens = (a / 10) % 10;
            int ones = a % 10;
            string wordRepresentation = "";

            if (hundreds == 0)
            {
                if (tens == 0)
                {
                    wordRepresentation = one[ones];
                }
                else
                {
                    if (tens == 1)
                    {
                        wordRepresentation = teens[ones];
                    }
                    else
                    {
                        wordRepresentation = ten[tens];
                        if (ones > 0)
                        {
                            wordRepresentation += " " + one[ones];
                        }
                    }
                }
            }
            else
            {
                wordRepresentation = one[hundreds] + " hundred";
                if (tens == 0)
                {
                    if (ones != 0)
                    {
                        wordRepresentation += " and " + one[ones];
                    }
                }
                else
                {
                    if (tens == 1)
                    {
                        wordRepresentation += " and " + teens[ones];
                    }
                    else
                    {
                        wordRepresentation += " and " + ten[tens];
                        if (ones > 0)
                        {
                            wordRepresentation += " " + one[ones];
                        }
                    }
                }
            }

            Console.WriteLine("{0} = {1}", a, wordRepresentation);
        }
    }
}