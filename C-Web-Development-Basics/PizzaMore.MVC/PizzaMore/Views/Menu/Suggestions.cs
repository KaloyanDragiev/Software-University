namespace PizzaMore.Views.Menu
{
    using System.IO;
    using System.Text;
    using Utilities;
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Suggestions : IRenderable<PizzaSuggestionsViewModel>
    {
        public PizzaSuggestionsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                "<li><a href=\"/menu/suggestions\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {Model.Email}</p>" +
                "</ul> </div></div></nav>");
            html.AppendLine(File.ReadAllText(Constants.YourSuggestionsTop));

            html.AppendLine("<ul>");
            foreach (var pizzaSuggestion in Model.PizzaSuggestions)
            {
                html.AppendLine(pizzaSuggestion.ToString());
            }
            html.AppendLine("</ul>");

            html.AppendLine(File.ReadAllText(Constants.YourSuggestionsBottom));
            return html.ToString();
        }
    }
}