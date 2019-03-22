namespace _04.Phone
{
    using System;
    using System.Linq;

    public class PhoneII
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var names = Console.ReadLine().Split();
            var action = Console.ReadLine().Split();
            var callOrMessage = string.Empty;
            var nameOrNumber = string.Empty;
            var isName = true;
            var currentName = string.Empty;
            var currentNumber = string.Empty;
            var duration = string.Empty;
            var digitsSum = 0; 
            var index = 0;
            while (action[0] != "done")
            {
                nameOrNumber = action[1];
                if (numbers.Contains(nameOrNumber))
                {
                    isName = false;
                    index = IndexOf(nameOrNumber, numbers);
                    currentNumber = numbers[index];
                    currentName = names[index];
                }
                else if (names.Contains(nameOrNumber))
                {
                    isName = true;
                    index = IndexOf(nameOrNumber, names);
                    currentName = names[index];
                    currentNumber = numbers[index];
                }

                callOrMessage = action[0];
                digitsSum = SumDigits(currentNumber);
                if (callOrMessage == "call")
                {
                    duration = digitsSum % 2 == 0 ? GetDuration(digitsSum) : "no answer";
                    Console.WriteLine("calling {0}...", isName ? currentNumber : currentName);
                    Console.WriteLine(duration);
                }
                else
                {
                    duration = digitsSum % 2 == 0 ? "meet me there" : "busy";
                    Console.WriteLine("sending sms to {0}...", isName ? currentNumber : currentName);
                    Console.WriteLine(duration);
                }

                action = Console.ReadLine().Split(' ').ToArray();
            }
        }

        private static string GetDuration(int digitsSum)
        {
            var minutes = digitsSum / 60;
            var seconds = digitsSum % 60;
            var duration = $"call ended. duration: {minutes:00}:{seconds:00}";
            return duration;
        }

        private static int IndexOf(string nameOrNumber, string[] givenArray)
        {
            var index = 0;
            var counter = givenArray.Length;
            for (index = 0; index < counter; index++)
            {
                if (givenArray[index] == nameOrNumber)
                {
                    break;
                }
            }
            return index;
        }

        private static int SumDigits(string currentNumber)
        {
            var sumDigits = 0;
            var counter = currentNumber.Length;
            for (int index = 0; index < counter; index++)
            {
                if (currentNumber[index] >= '0' && currentNumber[index] <= '9')
                {
                    sumDigits += Convert.ToInt16(currentNumber[index].ToString());
                }
            }
            return sumDigits;
        }
    }
}
