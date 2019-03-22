namespace _04.Variable_in_Hex_Format
{
    using System;
    using System.Collections.Generic;

    public class ManuelHexFormat
    {
        public static void Main()
        {
            List<string> hex = new List<string>()

                {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E","F" };

            string hexNumber = Console.ReadLine();

            int power = 0;

            int result = 0;

            for (int i = hexNumber.Length; i > 2; i--)
            {
                int digit = hex.IndexOf(hexNumber[i - 1].ToString());

                result += digit * (int)Math.Pow(16, power);

                power++;
            }

            Console.WriteLine(result);
        }
    }
}
