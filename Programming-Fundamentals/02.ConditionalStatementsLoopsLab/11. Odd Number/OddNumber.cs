namespace _11.Odd_Number
{
    using System;
   
    public class OddNumber
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            while (true)
            {
                if (Math.Abs(number) % 2 == 1)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}"); break;
                }
                else
                {
                    Console.WriteLine("Please write an odd number.");
                }

                number = int.Parse(Console.ReadLine());
            }
        }
    }
}
