namespace _04.Numbers_in_Reversed_Order
{
    using System;
   
    public class ReversedNumbers
    {
        public static void Main()
        {
            string number = Console.ReadLine();

            PrintReversed(number);
        }

        public static void PrintReversed(string number)
        {
            string reversed = Reverst(number);

            Console.WriteLine(reversed); ;
        }

        private static string Reverst(string number)
        {
            string result = string.Empty;
            int counter = number.Length - 1;
            for (int i = counter; i >= 0; i--)
            {
                result += number[i];
            }
            return result;
        }
    }
}
