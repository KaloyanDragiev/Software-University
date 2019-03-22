namespace PizzaMore.Views.Menu
{
    using System;
    using System.IO;
    using Utilities;
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Details : IRenderable<PizzaDetailsViewModel>
    {
        public PizzaDetailsViewModel Model { get; set; }

        public string Render()
        {
            string html = File.ReadAllText(Constants.Details);
            string replacement =
                $"\t\t\t<a class=\"btn btn-danger\" href=\"/menu/suggestions\">All Suggestions</a>\r\n\t\t\t<h3>{Model.Title}</h3>\r\n\t\t\t<img src=\"{Model.ImageUrl}\" width=\"300px\"/>\r\n\t\t\t<p>{Model.Recipe}</p>\r\n\t\t\t<p>Up: {Model.UpVote}</p>\r\n\t\t\t<p>Down: {Model.DownVote}</p>";
            return String.Format(html, replacement);
        }
    }
}