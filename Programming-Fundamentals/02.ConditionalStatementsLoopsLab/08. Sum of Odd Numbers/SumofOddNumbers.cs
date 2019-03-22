namespace _08.Sum_of_Odd_Numbers
{
    using System;
   
    public class SumofOddNumbers
    {
        public static void Main()
        {
            int oddNumbersCount = int.Parse(Console.ReadLine());

            int sumOddNumbers = 0;

            for (int odd = 1; odd <= oddNumbersCount * 2 - 1; odd += 2)
            {
                Console.WriteLine(odd);

                sumOddNumbers += odd;
            }

            Console.WriteLine($"Sum: {sumOddNumbers}");
        }
    }
}
