namespace _06.Interval_of_Numbers
{
    using System;
   
    public class IntervalNumbers
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int secondNumber = int.Parse(Console.ReadLine());

            int startNumber = Math.Min(firstNumber, secondNumber);

            int endNumber = Math.Max(firstNumber, secondNumber);

            for (int index = startNumber; index <= endNumber; index++)
            {
                Console.WriteLine(index);
            }
        }
    }
}
