namespace _12.Number_Checker
{
    using System;
  
    public class NumberChecker
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int number = 0;

            if (int.TryParse(input, out number))
            {
                Console.WriteLine("It is a number.");
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
