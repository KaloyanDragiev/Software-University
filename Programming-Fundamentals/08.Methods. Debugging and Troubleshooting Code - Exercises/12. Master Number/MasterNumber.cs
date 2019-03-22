namespace _12.Master_Number
{
    using System;
   
    public class MasterNumber
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            bool containsEvenDigit = true;
            bool isDigitsSumSevenDevisible = true;
            bool isSimetric = true;

            for (int count = 232; count <= number; count++)
            {
                containsEvenDigit = ContainsEvenDigit(count);
                isDigitsSumSevenDevisible = IsDigitsSumSevenDevisible(count);
                isSimetric = IsSimetric(count);

                if (containsEvenDigit && isDigitsSumSevenDevisible && isSimetric)
                {
                    Console.WriteLine(count);
                }
            }
        }

        private static bool ContainsEvenDigit(int count)
        {
            int countEvenDigits = 0;
            while (count > 0)
            {
                if (count % 2 == 0) { countEvenDigits++; break; }
                count = count / 10;
            }
            return countEvenDigits > 0 ? true : false;
        }

        private static bool IsDigitsSumSevenDevisible(int count)
        {
            int digitsSum = count % 10;
            while (count > 0)
            {
                count = count / 10;
                digitsSum += count % 10;
            }
            return digitsSum % 7 == 0 ? true : false;
        }

        private static bool IsSimetric(int count)
        {
            int number = count;
            int reversedNum = 0;
            while (number > 0)
            {
                int remainder = number % 10;
                reversedNum = reversedNum * 10 + remainder;
                number /= 10;
            }
            return reversedNum == count ? true : false;
        }

    }
}
