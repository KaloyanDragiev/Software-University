namespace _12.Count_Occurrences_of_Larger_Numbers
{
    using System;

    public class CountLargerNumbers
    {
        public static void Main()
        {
            var realNumbers = Console.ReadLine().Split(' ');
            var matchNumber = Convert.ToDouble(Console.ReadLine());
            var length = realNumbers.Length;
            var currentNumber = 0.0;
            var matchCounter = 0;
            for (int index = 0; index < length; index++)
            {
                currentNumber = Convert.ToDouble(realNumbers[index]);
                if (currentNumber > matchNumber)
                {
                    matchCounter++;
                }
            }
            Console.WriteLine(matchCounter);
        }
    }
}
