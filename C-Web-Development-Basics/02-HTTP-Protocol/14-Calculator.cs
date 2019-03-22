using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        Console.WriteLine("Content-type: text/html\r\n");
        string html =
            File.ReadAllText(
                @"C:\Users\Petar\WebstormProjects\C# Web Fundamentals\02-HTTP-Protocol\14-Calculator.html");
        Console.WriteLine(html);
        string[] operationInfo = Console.ReadLine().Split('&');
        decimal finalNumber = 0;
        try
        {
            decimal firstNum = decimal.Parse(operationInfo[0].Split('=')[1]);
            decimal secondNum = decimal.Parse(operationInfo[2].Split('=')[1]);
            string numOperator = operationInfo[1].Split('=')[1];
            numOperator = WebUtility.UrlDecode(numOperator);
            switch (numOperator)
            {
                case "+":
                    finalNumber = firstNum + secondNum;
                    break;

                case "-":
                    finalNumber = firstNum - secondNum;
                    break;
                case "/":
                    finalNumber = firstNum / secondNum;
                    break;
                case "*":
                    finalNumber = firstNum * secondNum;
                    break;
                default:
                    throw new Exception();
            }
            Console.WriteLine("Result: " + finalNumber);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid sign!");
            throw;
        }
    }
}