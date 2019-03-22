namespace _11.Count_of_Given_Element_in_Array
{
    using System;

    public class CountGivenElement
    {
        public static void Main()
        {
            var currentArray = Console.ReadLine().Split();
            var matchSymbol = Console.ReadLine();
            var counter = 0;
            for (int index = 0; index < currentArray.Length; index++)
            {
                if (currentArray[index] == matchSymbol)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
