namespace _04._1.Elevator
{
    using System;
 
    public class elevator
    {
        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());

            int capacity = int.Parse(Console.ReadLine());

            int result = (int)Math.Ceiling((double)people / capacity);

            Console.WriteLine(result);
        }
    }
}
