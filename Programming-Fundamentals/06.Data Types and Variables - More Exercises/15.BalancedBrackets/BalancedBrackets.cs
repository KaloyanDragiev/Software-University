namespace _15.BalancedBrackets
{
    using System;
   
    public class BalancedBrackets
    {
        public static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            string result = "BALANCED";

            string brackets = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                if (str == "(" || str == ")")
                {
                    brackets += str;
                }
            }

            if (brackets.Length % 2 == 1)
            {
                result = "UNBALANCED";
            }

            for (int j = 0; j < brackets.Length; j++)
            {
                if (j % 2 == 0 && brackets[j] == ')')
                {
                    result = "UNBALANCED";
                    break;
                }
                if (j % 2 == 1 && brackets[j] == '(')
                {
                    result = "UNBALANCED";
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
