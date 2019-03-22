namespace SimpleMVC.App.Views.Home
{
    using System.IO;
    using Interfaces;

    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contacts.html");
        }
    }
}