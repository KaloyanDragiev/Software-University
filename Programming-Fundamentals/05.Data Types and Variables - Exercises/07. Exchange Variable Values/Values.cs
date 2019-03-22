namespace _07.Exchange_Variable_Values
{
    using System;
   
    public class Values
    {
        public static void Main()
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            Console.WriteLine("Before:");

            Console.WriteLine($"a = {a}");

            Console.WriteLine($"b = {b}");

            string c = string.Empty;

            c = a;

            a = b;

            b = c;

            Console.WriteLine("After:");

            Console.WriteLine($"a = {a}");

            Console.WriteLine($"b = {b}");
        }
    }
}
