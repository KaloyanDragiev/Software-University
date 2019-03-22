namespace PizzaMore.Views.Users
{
    using System.IO;
    using Utilities;
    using SimpleMVC.Interfaces;

    public class Signin : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.SignIn);
        }
    }
}