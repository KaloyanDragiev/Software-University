using System;
using System.IO;
using System.Net;

namespace AddCake
{
    public class Cake
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name + "," + Price;
        }
    }

    class AddCake
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html =
                File.ReadAllText(
                    @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\AddCake.html");
            Console.WriteLine(html);
            string postContent = Console.ReadLine();
            string[] cakeinfo = postContent.Split('&');
            string cakeName = cakeinfo[0].Split('=')[1];
            cakeName = cakeName.Replace('+', ' ');
            decimal cakePrice = decimal.Parse(cakeinfo[1].Split('=')[1]);
            if (cakeName != null && cakePrice != 0)
            {
                Console.WriteLine($"name: {cakeName}<br>");
                Console.WriteLine($"price: {cakePrice}<br>");
                Cake cake = new Cake
                {
                    Name = cakeName,
                    Price = cakePrice
                };
                File.AppendAllText(@"database.csv" , cake + "\r\n");
            }
        }
    }
}
