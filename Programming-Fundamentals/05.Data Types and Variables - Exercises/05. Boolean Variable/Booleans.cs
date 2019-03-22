namespace _05.Boolean_Variable
{
    using System;
    
    public class Booleans
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            bool isBoolean = Convert.ToBoolean(input);

            Console.WriteLine(isBoolean == true? "Yes": "No");
        }
    }
}
