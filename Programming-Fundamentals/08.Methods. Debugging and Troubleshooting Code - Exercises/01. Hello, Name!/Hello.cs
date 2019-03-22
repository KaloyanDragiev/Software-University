namespace _01.Hello__Name_
{
    using System;
    
    public class Hello
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            Greeting(name);
        }

        private static void Greeting(string name)
        {
            Console.WriteLine("Hello, {0}!", name); ;
        }
    }
}
