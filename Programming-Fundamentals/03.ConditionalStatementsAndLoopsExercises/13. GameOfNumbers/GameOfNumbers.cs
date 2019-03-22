namespace _13.GameOfNumbers
{
    using System;
   
    public class GameOfNumbers
    {
        public static void Main()
        {
            int firstNumberNameN = int.Parse(Console.ReadLine());

            int secondNumberNameM = int.Parse(Console.ReadLine());

            int magicalNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            int combinationsCounter = 0;

            string output = string.Empty;

            bool isFound = false;

            for (int indexN = firstNumberNameN; indexN <= secondNumberNameM; indexN++)
            {
                for (int indexM = firstNumberNameN; indexM <= secondNumberNameM; indexM++)
                {
                    combinationsCounter++;

                    sum = indexN + indexM;

                    if (sum == magicalNumber)
                    {
                        output = $"Number found! {indexN} + {indexM} = {sum}";

                        isFound = true;
                    }
                }
            }

            output = isFound ? output : $"{combinationsCounter} combinations - neither equals {magicalNumber}";

            Console.WriteLine(output);
        }
    }
}
