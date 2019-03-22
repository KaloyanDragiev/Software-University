using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Content-type: text/html\r\n");
        string html =
            File.ReadAllText(
                @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\BrowseCakes.html");
        Console.WriteLine(html);
        string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
        string desiredCake = "";
        if (getContent != null)
            desiredCake = getContent.Split('=')[1];
        string[] allCakes = File.ReadAllLines(@"database.csv");
        var filteredCakes = allCakes.Where(c => c.Contains(desiredCake));
        foreach (var cake in filteredCakes)
        {
            var cakeInfo = cake.Split(',');
            string cakeName = cakeInfo[0];
            decimal cakePrice = decimal.Parse(cakeInfo[1]);
            Console.WriteLine($"{cakeName} ${cakePrice}<br>");
        }
    }
}