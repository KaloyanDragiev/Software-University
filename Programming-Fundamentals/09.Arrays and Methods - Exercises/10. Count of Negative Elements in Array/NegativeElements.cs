namespace _10.Count_of_Negative_Elements_in_Array
{
    using System;

    public class NegativeElements
    {
        public static void Main()
        {
            var counter = 0;
            var counterLines = Convert.ToInt32(Console.ReadLine());
            var currentNumber = 0;
            for (int i = 0; i < counterLines; i++)
            {
                currentNumber = Convert.ToInt32(Console.ReadLine());
                if (currentNumber < 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
