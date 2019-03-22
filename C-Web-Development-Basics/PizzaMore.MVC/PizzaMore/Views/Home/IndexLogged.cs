namespace PizzaMore.Views.Home
{
    using System.IO;
    using Utilities;
    using SimpleMVC.Interfaces;

    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.HomeLogged);
        }
    }
}