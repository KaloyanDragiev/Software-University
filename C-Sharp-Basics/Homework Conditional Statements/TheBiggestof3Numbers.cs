using System;

class TheBiggestof3Numbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        if (a>b && a>c)
        {
            Console.WriteLine(a);
        }
        else if (c>b && c>a)
        {
            Console.WriteLine(c);
        }
        else if (b > a && b > c)
        {
            Console.WriteLine(b);
        }
    }
}
