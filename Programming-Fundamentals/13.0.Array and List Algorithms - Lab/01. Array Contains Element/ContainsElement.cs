namespace _01.Array_Contains_Element
{
    using System;

    public class ContainsElement
    {
        static string[] givenSequence;

        public static void Main()
        {
            givenSequence = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wontedElement = Console.ReadLine();
            Console.WriteLine(Contains(wontedElement) ? "yes" : "no");
        }

        static bool Contains(string wontedElement)
        {
            for (int index = 0; index < givenSequence.Length; index++)
            {
                var currentElement = givenSequence[index];
                if (currentElement == wontedElement)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
