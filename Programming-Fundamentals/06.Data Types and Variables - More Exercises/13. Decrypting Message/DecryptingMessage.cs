namespace _13.Decrypting_Message
{
    using System;
   
    public class DecryptingMessage
    {
        public static void Main()
        {
            byte keyToEncoding = byte.Parse(Console.ReadLine());
            byte linesCount = byte.Parse(Console.ReadLine());

            string encodingMesage = string.Empty; 

            for (int line = 0; line < linesCount; line++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());

                encodingMesage += (char)(currentSymbol + keyToEncoding);
            }

            Console.WriteLine(encodingMesage);
        }
    }
}
