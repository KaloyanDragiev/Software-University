namespace _02._02.Number_Checker
{
    using System;
   
    public class NumberChecker
    {
        public static void Main()
        {
            string enteredNumber = Console.ReadLine();

            Console.WriteLine(enteredNumber.Contains(".")? "floating-point" : "integer");
        }
    }
}
