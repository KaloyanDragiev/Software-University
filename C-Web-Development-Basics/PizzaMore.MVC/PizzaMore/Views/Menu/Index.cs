namespace PizzaMore.Views.Menu
{
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Utilities;
    using System.Linq;

    public class Index : IRenderable<IEnumerable<PizzaViewModel>>
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(File.ReadAllText(Constants.MenuTop));
            html.AppendLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                    "<div class=\"navbar-header\">" +
                        "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>" +
                     "</div>" +
                     "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                        "<ul class=\"nav navbar-nav\">" +
                            "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                            "<li><a href=\"/menu/suggestions\">Your Suggestions</a></li>" +
                            "<li><a href=\"/menu/sorted\">Sorted Pizzas</a></li>" +
                        "</ul>" +
                        "<ul class=\"nav navbar-nav navbar-right\">" +
                            "<p class=\"navbar-text navbar-right\"></p>" +
                            "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>" +
                            $"<p class=\"navbar-text navbar-right\">Signed in as {Model.First().Owner.Email}</p>" +
                        "</ul> </div></div></nav>");

            html.AppendLine("<div class=\"card-deck\">");
            foreach (var pizzaViewModel in Model)
            {
                html.AppendLine(pizzaViewModel.ToString());
            }
            html.AppendLine("</div>");

            html.AppendLine(File.ReadAllText(Constants.MenuBottom));
            return html.ToString();
        }

        public IEnumerable<PizzaViewModel> Model { get; set; }
    }
}