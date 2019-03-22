namespace _07._07.Sentence_the_Thief
{
    using System;
  
    public class SentencetheThief
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

            int divider = cloesestNumber < 0 ? 128 : 127;

            double sentence = Math.Abs(Math.Ceiling((double)Math.Abs(cloesestNumber) / divider));

            Console.WriteLine(sentence > 1 ? 

                $"Prisoner with id {cloesestNumber} is sentenced to {sentence} years" :

                $"Prisoner with id {cloesestNumber} is sentenced to {sentence} year");
        }
    }
}
