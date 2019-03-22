namespace _12.Test_Numbers
{
    using System;
    
    public class TestNumbers
    {
        public static void Main()
        {
            int firstNumberNameN = int.Parse(Console.ReadLine());

            int secondNumberNameM = int.Parse(Console.ReadLine());

            int testNumber = int.Parse(Console.ReadLine());

            int temporaryResult = 0;

            int sum = 0;

            int combinationsCounter = 0;

            for (int indexN = firstNumberNameN; indexN >= 1; indexN--)
            {
                for (int indexM = 1; indexM <= secondNumberNameM; indexM++)
                {
                    combinationsCounter++;

                    temporaryResult = indexN * indexM * 3;

                    sum += temporaryResult;

                    if (testNumber <= sum)
                    {
                        break;
                    }
                }
                if (testNumber <= sum)
                {
                    break;
                }
            }

            Console.WriteLine($"{combinationsCounter} combinations");

            string result = sum >= testNumber ? " >= " + testNumber.ToString() : string.Empty;

            Console.WriteLine($"Sum: {sum}" + result);
        }
    }
}
