namespace _09.Multiplication_Table
{
    using System;
  
    public class MultiplicationTable
    {
        public static void Main()
        {
            byte number = byte.Parse(Console.ReadLine());

            for (byte i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}
