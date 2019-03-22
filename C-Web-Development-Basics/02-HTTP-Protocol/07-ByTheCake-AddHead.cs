using System;
using System.IO;
class ByTheCakeAddHead
{
    static void Main()
    {
        Console.WriteLine("Content-type: text/html\r\n");
        string html =
            File.ReadAllText(
                @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\07-ByTheCake-AddHead.html");
        Console.WriteLine(html);
    }
}