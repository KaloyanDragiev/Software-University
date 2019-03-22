namespace _09.Largest_Element_in_Array
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var counter = Convert.ToInt32(Console.ReadLine());
            var currentNumber = 0;
            var maxValue = 0;
            for (int count = 0; count < counter; count++)
            {
                currentNumber = Convert.ToInt32(Console.ReadLine());
                if (currentNumber > maxValue)
                {
                    maxValue = currentNumber;
                }
            }
            Console.WriteLine(maxValue);
        }
    }
}
