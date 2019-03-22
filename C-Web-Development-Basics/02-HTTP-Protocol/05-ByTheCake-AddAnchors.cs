using System;
using System.IO;

namespace _05_ByTheCake_AddAnchors
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html =
                File.ReadAllText(
                    @"C:\Users\Pesho\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\05-ByTheCake-AddAnchors.html");
            Console.WriteLine(html);
        }
    }
}