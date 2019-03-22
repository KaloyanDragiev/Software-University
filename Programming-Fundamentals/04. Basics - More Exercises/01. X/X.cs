namespace _01.X
{
    using System;
  
    public class X
    {
        public static void Main()
        {
            int XRepetingTimes = int.Parse(Console.ReadLine());

            int midSpace = XRepetingTimes;

            int firstSpace = 0;

            for (int i = 1; i <= XRepetingTimes; i++)
            {
                if (i <= XRepetingTimes / 2)
                {
                    Console.WriteLine("{1}x{0}x", new string(' ', midSpace - 2), new string(' ', firstSpace));

                    midSpace -= 2;

                    firstSpace++;
                }
                if (i == XRepetingTimes / 2 + 1)
                {
                    Console.WriteLine(new string(' ', XRepetingTimes / 2) + "x");

                    firstSpace--;
                }
                if (i > XRepetingTimes / 2 + 1)
                {
                    Console.WriteLine("{1}x{0}x", new string(' ', midSpace), new string(' ', firstSpace));

                    midSpace += 2;

                    firstSpace--;
                }
            }
        }
    }
}
