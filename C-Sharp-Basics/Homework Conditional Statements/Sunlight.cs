using System;

class Problem3Sunlight
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());//3
        int e = 1;
        int r = (3 * n - 5) / 2;//2
        Console.WriteLine("{0}*{0}", new string('.', (n * 3 - 1) / 2));
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', e), new string('.', r));
            e++;
            r--;
        }
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (n)), new string('*', (n)));
        }
        Console.WriteLine("{0}", new string('*', 3 * n));
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (n)), new string('*', (n)));
        }

        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', e), new string('.', r));
            e--;
            r++;
        }
        Console.WriteLine("{0}*{0}", new string('.', (n * 3 - 1) / 2));
    }
}
//    3
//....*....
//.*..*..*.
//..*.*.*..
//...***...
//*********
//...***...
//..*.*.*..
//.*..*..*.
//....*....
