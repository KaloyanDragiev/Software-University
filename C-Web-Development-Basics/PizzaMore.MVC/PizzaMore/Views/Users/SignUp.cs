namespace PizzaMore.Views.Users
{
    using System.IO;
    using Utilities;
    using SimpleMVC.Interfaces;

    public class Signup : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.SignUp);
        }
    }
}