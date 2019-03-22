namespace _05.User_Logins
{
    using System;
    using System.Collections.Generic;

    public class UserLogins
    {
        public static void Main()
        {
            var registerCollection = new Dictionary<string, string>();
            var isTimeToLogin = false;
            var user = string.Empty;
            var password = string.Empty;
            var unsuccessfullyLoginCounter = 0;
            for (int infiniatly = 0; ; infiniatly++)
            {
                var enteredData = Console.ReadLine()
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if (enteredData[0] == "login")
                {
                    isTimeToLogin = true;
                    continue;
                }

                if (!isTimeToLogin && enteredData[0] != "end")
                {
                    user = enteredData[0];
                    password = enteredData[1];
                    UserRegistering(registerCollection, user, password);
                }
                else if (isTimeToLogin && enteredData[0] != "end")
                {
                    user = enteredData[0];
                    password = enteredData[1];
                    CheckForUserAndPassword(registerCollection, user, password, ref unsuccessfullyLoginCounter);
                }
                else if (enteredData[0] == "end")
                {
                    Console.WriteLine($"unsuccessful login attempts: {unsuccessfullyLoginCounter}");
                    return;
                }
            }
        }

        static void UserRegistering(
            Dictionary<string, string> registerCollection, string user, string password)
        {
            if (!registerCollection.ContainsKey(user))
            {
                registerCollection[user] = string.Empty; ;
            }
            registerCollection[user] = password;
        }

        static void CheckForUserAndPassword(Dictionary<string, string> registerCollection, 
            string user, 
            string password,
            ref int unsuccessfullyLoginCounter)
        {
            if (registerCollection.ContainsKey(user) && registerCollection.ContainsValue(password))
            {
                Console.WriteLine($"{user}: logged in successfully");
            }
            else
            {
                Console.WriteLine($"{user}: login failed");
                unsuccessfullyLoginCounter++;
            }
        }

        static void Print(Dictionary<string, Int32> productQuantityCollection)
        {
            foreach (var item in productQuantityCollection)
            {
                var name = item.Key;
                var value = item.Value;
                if (value > 0)
                {
                    Console.WriteLine($"{name}: {value}");
                }
            }
        }
    }
}
