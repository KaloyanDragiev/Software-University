namespace _06.Sum_Reversed_Numbers
{
    using System;
    using System.Linq;

    public class SumReversedNumbers
    {
        public static void Main()
        {
            var currentSequence = Console.ReadLine().Split().ToList();
            var sumReversetNumbers = 0;
            var numberAsString = string.Empty;
            var convertedNumber = 0;
            var iterations = currentSequence.Count;
            for (int index = 0; index < iterations; index++)
            { 
                currentSequence[index].Reverse().ToString(); 
                Console.WriteLine(currentSequence[index]);
                //convertedNumber = int.Parse(numberAsString);
                sumReversetNumbers += convertedNumber;
            }
            Console.WriteLine(sumReversetNumbers);
        }
    }
}
