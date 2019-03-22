namespace _06.Filter_Base
{
    using System;
    using System.Collections.Generic;

    public class FilterBase
    {
        public static void Main()
        {
            var usersByAge = new Dictionary<string, string>();
            var usersBySelary = new Dictionary<string, double>();
            var usersByPlace = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "filter base")
            {
                var temporary = input.Split(' ');
                var name = temporary[0];
                var action = temporary[temporary.Length - 1];

                var integer = 0;
                var flotingpoint = 0.0;

                if (int.TryParse(action, out integer))
                {
                    usersByAge[name] = action;
                }
                else if (double.TryParse(action, out flotingpoint))
                {
                    usersBySelary[name] = flotingpoint;
                }
                else
                {
                    usersByPlace[name] = action;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            if (input == "Age")
            {
                foreach (var item in usersByAge)
                {
                    Console.WriteLine($"Name: {item.Key}\nAge: {item.Value}");
                    Console.WriteLine("====================");
                }
            }
            else if (input == "Salary")
            {
                foreach (var item in usersBySelary)
                {
                    Console.WriteLine($"Name: {item.Key}\nSalary: {item.Value.ToString("0.00")}");
                    Console.WriteLine("====================");
                }
            }
            else
            {
                foreach (var item in usersByPlace)
                {
                    Console.WriteLine($"Name: {item.Key}\nPosition: {item.Value}");
                    Console.WriteLine("====================");
                }
            }
        }
    }
}