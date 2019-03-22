using System;

class Problem2PetarGame
{
    static void Main()
    {
        ulong startNum = ulong.Parse(Console.ReadLine());
        ulong endNum = ulong.Parse(Console.ReadLine());
        string inputString = Console.ReadLine();
        string sumAsString = null;
        decimal sum = 0;
        string replaceString;
        for (ulong i = startNum; i < endNum; i++)
        {
            if (i % 5 == 0)
            {
                sum += i;
            }
            else
            {
                sum += i % 5;
            }
            if (sum % 2 == 0)
            {
                replaceString = sum.ToString()[0].ToString();
            }
            else
            {
                replaceString = sum.ToString()[sum.ToString().Length - 1].ToString();
            }
            sumAsString = sum.ToString().Replace(replaceString, inputString);

        }
        Console.WriteLine(sumAsString);
    }
}