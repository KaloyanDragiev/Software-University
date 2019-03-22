using System;

class ExchangeIfGreater
{
    static void Main()
    {
        int swap = 0;
        int a = int.Parse(Console.ReadLine());//2
        int b = int.Parse(Console.ReadLine());//1
        if (a > b)
        {
            swap = b;
            b = a;
            a = swap;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
