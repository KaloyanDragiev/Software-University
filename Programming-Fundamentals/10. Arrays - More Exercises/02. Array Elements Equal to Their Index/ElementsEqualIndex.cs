namespace _02.Array_Elements_Equal_to_Their_Index
{
    using System;

    public class ElementsEqualIndex
    {
        public static void Main()
        {
            var givenNumbers = Console.ReadLine().Split();
            var currentNumber = 0;
            var counter = givenNumbers.Length;
            for (int index = 0; index < counter; index++)
            {
                currentNumber = Convert.ToInt32(givenNumbers[index]);
                if (index == currentNumber)
                {
                    Console.Write("{0} ", currentNumber);
                }
            }
        }
    }
}
