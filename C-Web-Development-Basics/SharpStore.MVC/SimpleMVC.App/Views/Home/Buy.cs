namespace SimpleMVC.App.Views.Home
{
    using System.IO;
    using ViewModels;
    using Interfaces.Generic;

    public class Buy : IRenderable<KnifeViewModel>
    {
        public KnifeViewModel Model { get; set; }

        public string Render()
        {
            string replacement =
                $"\t<div class=\"row\">\r\n\t\t<h3>Are you sure you want to purchase {this.Model.Name} for {this.Model.Price}?</h3>\r\n\t</div>";
            string originalHtml = File.ReadAllText("../../content/buy.html");

            return string.Format(originalHtml, replacement, Model.Id);
        }
    }
}