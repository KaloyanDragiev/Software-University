namespace _01.Hello__Name_
{
    using System;

    public class HelloName
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            GreetingByName(name);
        }

        private static void GreetingByName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
