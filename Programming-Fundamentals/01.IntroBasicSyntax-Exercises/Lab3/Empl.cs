namespace Lab3
{
    using System;

    public class Empl
    {
        public static void Main()
        {
            Console.WriteLine("Name: {0}", Console.ReadLine());

            Console.WriteLine("Age: {0}", Console.ReadLine());

            Console.WriteLine("Employee ID: {0}", int.Parse(Console.ReadLine()).ToString("00000000"));

            Console.WriteLine("Salary: {0:F2}", double.Parse(Console.ReadLine()));
        }
    }
}
