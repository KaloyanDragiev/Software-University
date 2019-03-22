namespace _15.Substring
{
    using System;
  
    public class Substring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            char search = 'p';
            bool isMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    isMatch = true;

                    int endIndex = count + 1;

                    if (endIndex >= text.Length - i - 1)
                    {
                        endIndex = text.Length - i ;
                    }

                    string matchedString = text.Substring(i, endIndex);
                    Console.WriteLine(matchedString);
                    i += count;
                }
            }

            if (!isMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
