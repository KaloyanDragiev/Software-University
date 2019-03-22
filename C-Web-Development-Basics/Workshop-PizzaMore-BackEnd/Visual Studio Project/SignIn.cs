namespace SignIn
{
    using System.Collections.Generic;
    using System.Linq;
    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    public class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();

        static void Main()
        {        
            if (WebUtil.IsPost())
            {
                TryLogInUser();
            }
            ShowPage();
        }

        private static void TryLogInUser()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string email = RequestParameters["email"];
            string password = PasswordHasher.Hash(RequestParameters["password"]);
            using (var context = new PizzaMoreContext())
            {
                User desiredUser = context.Users.SingleOrDefault(user => user.Email == email);
                if (desiredUser.Password == password)
                {
                    Session session = new Session();
                    session.User = desiredUser;
                    if (desiredUser != null)
                    {
                        Header.AddCookie(new Cookie("sid", session.Id.ToString()));
                    }
                    context.Sessions.Add(session);
                    context.SaveChanges();
                }
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignIn);
        }
    }
}