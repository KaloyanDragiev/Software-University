namespace _15.Calculator
{
    using System;
   
    public class Calculator
    {
        public static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine(operators == "+" ? $"{num1} + {num2} = {num1 + num2}" :
                operators == "-" ? $"{num1} - {num2} = {num1 - num2}" :
                operators == "*" ? $"{num1} * {num2} = {num1 * num2}" :
                $"{num1} / {num2} = {num1 / num2}");
        }
    }
}
