namespace _06.Strings_And_Objects
{
    using System;
  
    public class StringsAndObjects
    {
        public static void Main()
        {
            string first = "Hello";

            string last = "World";

            object sum = first + " " + last;

            string result = sum.ToString();

            Console.WriteLine(result);
        }
    }
}
