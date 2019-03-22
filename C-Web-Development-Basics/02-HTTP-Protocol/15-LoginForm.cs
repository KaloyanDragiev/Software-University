using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Content-type: text/html\r\n");
        string html =
            File.ReadAllText(
                @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\15-LoginForm.html");
        Console.WriteLine(html);
        string[] userInfo = Console.ReadLine().Split('&');
        string username = userInfo[0].Split('=')[1];
        string password = userInfo[1].Split('=')[1];
        Console.WriteLine($"Hi {username}, your password is {password}");
    }
}