namespace SignUp
{
    using System.Collections.Generic;
    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    public class SignUp
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header header = new Header();

        static void Main()
        {         
            if (WebUtil.IsPost())
            {
                RegisterUser();
            }
            ShowPage();
        }

        private static void RegisterUser()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string email = RequestParameters["email"];
            string password = RequestParameters["password"];
            User user = new User()
            {
                Email = email,
                Password = PasswordHasher.Hash(password)
            };

            using (var context = new PizzaMoreContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            header.Print();
            WebUtil.PrintFileContent(Constants.SignUp);
        }
    }
}