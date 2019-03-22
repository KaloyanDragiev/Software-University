using System;
using System.IO;

namespace PizzaMore.Utility
{
    public static class Logger
    {
        public static void Log(string message)
        {
            if (!Directory.Exists(@"Logs"))
                Directory.CreateDirectory(@"Logs");
            File.AppendAllText(@"Logs/log.txt", message + Environment.NewLine);
        }
    }
}