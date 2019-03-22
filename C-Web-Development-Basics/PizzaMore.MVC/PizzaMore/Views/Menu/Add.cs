namespace PizzaMore.Views.Menu
{
    using System.IO;
    using Utilities;
    using SimpleMVC.Interfaces;

    public class Add : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.AddPizza);
        }
    }
}