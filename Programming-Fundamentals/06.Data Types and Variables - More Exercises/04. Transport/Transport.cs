namespace _04.Transport
{
    using System;
   
    public class Transport
    {
        public static void Main()
        {
            int peoples = int.Parse(Console.ReadLine());

            double result = Math.Ceiling(peoples / 24.0);

            Console.WriteLine(result);
        }
    }
}
