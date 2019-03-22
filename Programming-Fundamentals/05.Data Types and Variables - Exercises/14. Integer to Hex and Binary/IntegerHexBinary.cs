namespace _14.Integer_to_Hex_and_Binary
{
    using System;
   
    public class IntegerHexBinary
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hex = Convert.ToString(number, 16).ToUpper();
            Console.WriteLine(hex);

            string bin = Convert.ToString(number, 2);
            Console.WriteLine(bin);
        }
    }
}
