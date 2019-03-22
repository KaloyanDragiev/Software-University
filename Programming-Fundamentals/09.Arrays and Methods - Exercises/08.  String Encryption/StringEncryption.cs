namespace _08.String_Encryption
{
    using System;

    public class StringEncryption
    {
        public static void Main()
        {
            char currentChar = ' ';
            string encrypted = string.Empty;
            int commingChars = int.Parse(Console.ReadLine());
            for (int count = 0; count < commingChars; count++)
            {
                currentChar = char.Parse(Console.ReadLine());
                encrypted += EncryptChar(currentChar);
            }

            Console.WriteLine(encrypted);
        }

        private static string EncryptChar(char currentChar)
        {
            string askii = ((int)currentChar).ToString();
            string second = askii[0].ToString();
            string third = askii[askii.Length - 1].ToString();
            int first = int.Parse(askii) + int.Parse(third); 
            int last = int.Parse(askii) - int.Parse(second);
            return (char)first + second + third + (char)last;
        }
    }
}
