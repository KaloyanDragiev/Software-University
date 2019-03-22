namespace _05.Fibonacci_Numbers
{
    using System;

    public class FibonacciNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Fibonacci(number);
            }            
        }

        public static void Fibonacci(int n)
        {
            int firstnumber = 0;
            int secondnumber = 1;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }
            Console.WriteLine(result);
        }
    }
}
