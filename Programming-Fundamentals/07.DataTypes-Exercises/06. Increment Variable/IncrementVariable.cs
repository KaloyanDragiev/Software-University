using System;
namespace IncrementVariable
{
    public class searchOverflows
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int overflows = n / (byte.MaxValue + 1);
            int result = n % (byte.MaxValue + 1);

            Console.WriteLine(n >= byte.MaxValue + 1 ? result : n);
            if (overflows > 0) Console.WriteLine($"Overflowed {overflows} times");
        }
    }
}