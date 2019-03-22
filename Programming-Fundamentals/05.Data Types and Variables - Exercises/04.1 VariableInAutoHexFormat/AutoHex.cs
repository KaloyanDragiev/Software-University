namespace _04._1_VariableInAutoHexFormat
{
    using System;

    public class AutoHex
    {
        public static void Main()
        {
            string hexNumber = Console.ReadLine();

            int inDecimal = Convert.ToInt32(hexNumber, 16);

            Console.WriteLine(inDecimal);
        }
    }
}
