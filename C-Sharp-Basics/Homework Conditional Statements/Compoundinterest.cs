using System;

class Problem1Compoundinterest
{
    static void Main()
    {
        int y = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        double i = double.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        //2600 * (1 + 0.07) 2 = 2600 * 1.07 2 = 2600 * 1.1449 = 2976.74.
        //y * (1 + i)
        Console.WriteLine(y * (Math.Sqrt(1 + i)));
    }
}
