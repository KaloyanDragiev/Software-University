namespace _05.Integer_to_Base
{
    using System;

    public class IntegerToBase
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int toBase = int.Parse(Console.ReadLine());

            string result = TakeResult(number, toBase);
            Console.WriteLine(result);
        }

        private static string TakeResult(int number, int toBase)
        {
            string result = string.Empty;
            while (number > 0)
            {
                int rem = number % toBase;
                result = rem + result;
                number /= toBase;
            }
            return result;
        }
    }
}
