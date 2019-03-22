namespace _12.Variable_in_Hexadecimal_Format
{
    using System;
  
    public class VariableinHexadecimalFormat
    {
        public static void Main()
        {
            string hexNumber = Console.ReadLine();
            int inDecimal = Convert.ToInt32(hexNumber, 16);
            Console.WriteLine(inDecimal);
        }
    }
}
