namespace _09.Refactor_Special_Numbers
{
    using System;
    
    public class RefactorSpecialNumbers
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int digitsSum = 0; int tempNumber = 0; bool isSpecial = false;

            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                tempNumber = currentNumber;

                while (currentNumber > 0)
                {
                    digitsSum += currentNumber % 10;

                    currentNumber = currentNumber / 10;
                }

                isSpecial = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);

                Console.WriteLine($"{tempNumber} -> {isSpecial}");

                digitsSum = 0;

                currentNumber = tempNumber;
            }
        }
    }
}
