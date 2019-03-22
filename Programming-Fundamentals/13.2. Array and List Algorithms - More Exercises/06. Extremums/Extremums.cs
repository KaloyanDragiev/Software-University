namespace _06.Extremums
{
    using System;

    public class Extremums
    {
        public static void Main()
        {
            var enteredNumbers = ConvertToIntegers(Console.ReadLine());
            var minNumbers = new int[enteredNumbers.Length];
            var maxNumbers = new int[enteredNumbers.Length];
            string command = Console.ReadLine();
            GetMinAndMaxNumbers(enteredNumbers, minNumbers, maxNumbers);
            if (command == "Max")
            {
                Print(maxNumbers);
            }
            else
            {
                Print(minNumbers);
            }
        }

        private static void Print(int[] numbers)
        {
            var sum = 0;
            for (int index = 0; index < numbers.Length; index++)
            {
                if (index == 0)
                {
                    Console.Write(numbers[index]);
                    sum += numbers[index];
                    continue;
                }
                Console.Write($", {numbers[index]}");
                sum += numbers[index];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }

        private static void GetMinAndMaxNumbers(int[] enteredNumbers, int[] minNumbers, int[] maxNumbers)
        {
            for (int index = 0; index < enteredNumbers.Length; index++)
            {
                var minNumber = Spin("min", enteredNumbers[index]);
                minNumbers[index] = minNumber;
                var maxNumber = Spin("max", enteredNumbers[index]);
                maxNumbers[index] = maxNumber;
            }
        }

        private static int Spin(string inValue, int number)
        {
            var currentNumber = number.ToString().ToCharArray();
            var returnedNumber = number;

            for (int count = 0; count < currentNumber.Length; count++)
            {
                var temporarySymbol = currentNumber[0];
                var temporaryNumber = string.Empty;
                for (int index = 0; index < currentNumber.Length - 1; index++)
                {
                    currentNumber[index] = currentNumber[index + 1];
                    temporaryNumber += currentNumber[index];
                }
                currentNumber[currentNumber.Length - 1] = temporarySymbol;
                temporaryNumber += currentNumber[currentNumber.Length - 1];

                number = Convert.ToInt32(temporaryNumber);
                if (inValue == "max" && number > returnedNumber)
                {
                    returnedNumber = number;
                }
                else if (inValue == "min" && number < returnedNumber)
                {
                    returnedNumber = number;
                }
            }
            return returnedNumber;
        }

        static int[] ConvertToIntegers(string input)
        {
            var temporaryArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var endArray = new int[temporaryArray.Length];
            for (int index = 0; index < temporaryArray.Length; index++)
            {
                endArray[index] = Convert.ToInt32(temporaryArray[index]);
            }
            return endArray;
        }
    }
}
