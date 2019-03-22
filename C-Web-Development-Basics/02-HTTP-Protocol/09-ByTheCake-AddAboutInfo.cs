using System;
using System.IO;
class Program
{
    static void Main()
    {
        Console.WriteLine("Content-type: text/html\r\n");
        string html =
            File.ReadAllText(
                @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\09-ByTheCake-AddAboutInfo.html");
        Console.WriteLine(html);
    }
}