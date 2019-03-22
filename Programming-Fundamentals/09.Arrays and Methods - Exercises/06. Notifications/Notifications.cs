namespace _06.Notifications
{
    using System;

    public class Notifications
    {
        public static void Main()
        {
            string operation = string.Empty;
            string message = string.Empty;
            int messageCode = 0;

            byte counter = byte.Parse(Console.ReadLine());
            for (int count = 0; count < counter; count++)
            {
                message = Console.ReadLine();
                if (message == "success")
                {
                    operation = Console.ReadLine();
                    message = Console.ReadLine();
                    ShowSuccess(operation, message);
                }
                else if (message == "error")
                {
                    message = Console.ReadLine();
                    messageCode = int.Parse(Console.ReadLine());
                    ShowError(message, messageCode);
                }
            }
        }

        private static void ShowError(string message, int messageCode)
        {
            Console.WriteLine("Error: Failed to execute {0}.", message);
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Error Code: {0}.", messageCode);
            Console.WriteLine(messageCode >= 0 ?
                "Reason: Invalid Client Data." : "Reason: Internal System Failure.");
            
        }

        private static void ShowSuccess(string operation, string message)
        {
            Console.WriteLine("Successfully executed {0}.", operation);
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Message: {0}.", message);
        }
    }
}
