namespace _06._06.Catch_the_Thief
{
    using System;
   
    public class CatchtheThief
    {
        public static void Main()
        {
            string numeralType = Console.ReadLine();

            byte interation = byte.Parse(Console.ReadLine());

            decimal equalToMaxValue = 0;

            if (numeralType == "sbyte") { equalToMaxValue = sbyte.MaxValue; }

            if (numeralType == "int") { equalToMaxValue = int.MaxValue; }

            if (numeralType == "long") { equalToMaxValue = long.MaxValue; }

            long currentNumber = long.Parse(Console.ReadLine());

            long cloesestNumber = currentNumber;

            for (int index = 1; index < interation; index++)
            {
                currentNumber = long.Parse(Console.ReadLine());

                if (Math.Abs(equalToMaxValue - currentNumber) < Math.Abs(equalToMaxValue - cloesestNumber))
                {
                    cloesestNumber = currentNumber;
                }
            }

            Console.WriteLine(cloesestNumber);
        }
    }
}
