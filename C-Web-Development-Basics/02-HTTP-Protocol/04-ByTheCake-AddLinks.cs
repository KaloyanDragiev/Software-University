using System;
using System.IO;

namespace _04_ByTheCake_AddLinks
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html =
                File.ReadAllText(
                    @"C:\Users\Pesho\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\04-ByTheCake-AddLinks.html");
            Console.WriteLine(html);
        }
    }
}
