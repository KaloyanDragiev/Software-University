namespace _03.Exchange_Variable_Values
{
    using System;
   
    public class ExchangeVariableValues
    {
        public static void Main()//Memory: 7.43 MB, Time: 0.015 s
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string c = string.Empty;

            c = a;

            a = b;

            b = c;

            Console.WriteLine(a);

            Console.WriteLine(b);
        }
    }
}
