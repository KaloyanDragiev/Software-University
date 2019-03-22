using System;

class PlaywithIntDoubleandString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int ");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int n = int.Parse(Console.ReadLine());
        switch (n)
        {
            case 1:
                Console.WriteLine("Please enter a int:");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine(a + 1); break;
            case 2:
                Console.WriteLine("Please enter a double:");
                double d = double.Parse(Console.ReadLine());
                Console.WriteLine(d + 1); break;
            case 3:
                Console.WriteLine("Please enter a string:");
                string t = Console.ReadLine();
                Console.WriteLine(t + "*"); break;
            default: Console.WriteLine("Agian...");
                break;
        }
    }
}
