namespace _11._5_Different_Numbers
{
    using System;

    public class DifferentNumbers
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber || secondNumber - firstNumber < 4)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int a = firstNumber; a <= secondNumber; a++)
                {
                    for (int b = firstNumber; b <= secondNumber; b++)
                    {
                        for (int c = firstNumber; c <= secondNumber; c++)
                        {
                            for (int d = firstNumber; d <= secondNumber; d++)
                            {
                                for (int e = firstNumber; e <= secondNumber; e++)
                                {
                                    if (a < b && b < c && c < d && d < e)
                                    {
                                        Console.WriteLine($"{a} {b} {c} {d} {e}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
           
        }
    }
}
