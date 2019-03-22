namespace _02.Min_Method
{
    using System;

    public class MinMethod
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int nextNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());

            int minNumber = GetMinValue(firstNumber, nextNumber);
            minNumber = GetMinValue(minNumber, lastNumber);

            Console.WriteLine(minNumber);
        }

        private static int GetMinValue(int firstNumber, int nextNumber)
        {
            return firstNumber <= nextNumber? firstNumber: nextNumber;
        }
    }
}
