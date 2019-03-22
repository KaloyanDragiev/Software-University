using System;

class BonusScore
{
    static void Main()
    {
        int score = int.Parse(Console.ReadLine());
        switch (score)
        {
            case 1: Console.WriteLine(score * 10); break;
            case 2: Console.WriteLine(score * 10); break;
            case 3: Console.WriteLine(score * 10); break;
            case 4: Console.WriteLine(score * 100); break;
            case 5: Console.WriteLine(score * 100); break;
            case 6: Console.WriteLine(score * 100); break;
            case 7: Console.WriteLine(score * 1000); break;
            case 8: Console.WriteLine(score * 1000); break;
            case 9: Console.WriteLine(score * 1000); break;
            default: Console.WriteLine("invalid score");
                break;
        }
    }
}
