namespace _08.SMS_Typing
{
    using System;
   
    public class SMSTyping
    {
        public static void Main()
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            int offset = 0;

            int index = 0;

            string[] letters = new string[26];

            int count = 0;

            for (char i = 'a'; i < letters.Length + 'a'; i++)
            {
                letters[count] = i.ToString();

                count++;
            }

            string result = string.Empty;

            for (int i = 0; i < countOfNumbers; i++)
            {
                int code = int.Parse(Console.ReadLine());

                offset = (code % 10 - 2) * 3;

                if (code % 10 == 9 || code % 10 == 8)
                {
                    offset += 1;
                }

                index = offset + code.ToString().Length - 1;

                if (code % 10 < 2)
                {
                    result += " ";

                    continue;
                }

                result += letters[index];
            }

            Console.WriteLine(result);
        }
    }
}
