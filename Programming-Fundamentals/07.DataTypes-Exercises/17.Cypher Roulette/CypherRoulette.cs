namespace _17.Cypher_Roulette
{
    using System;
   
    public class CypherRoulette
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            string endStr = string.Empty;
            string tempStr = string.Empty;
            string nowStr = string.Empty;

            for (int a = 0; a < n; a++)
            {
                string nextStr = Console.ReadLine();
                nowStr = nextStr;

                if (nextStr == "spin")
                {
                    counter++;
                    nowStr = string.Empty;
                    a--;
                }
                if (tempStr == nextStr)
                {
                    endStr = string.Empty;
                    nowStr = string.Empty;
                    if (nextStr == "spin")
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0)
                {
                    endStr = nowStr + endStr;
                }
                else
                {
                    endStr = endStr + nowStr;
                }

                tempStr = nextStr;
            }
            Console.WriteLine(endStr);
        }
    }
}
