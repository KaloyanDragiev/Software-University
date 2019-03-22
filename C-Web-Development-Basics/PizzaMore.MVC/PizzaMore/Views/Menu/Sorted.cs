namespace PizzaMore.Views.Menu
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Utilities;
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Sorted : IRenderable<IEnumerable<PizzaViewModel>>
    {
        public IEnumerable<PizzaViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(File.ReadAllText(Constants.MenuTop));
            html.AppendLine("<nav class=\"navbar navbar-default\">\r\n" +
                            "<div class=\"container-fluid\">\r\n" +
                            "<div class=\"navbar-header\">\r\n" +
                                "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>\r\n" +
                                    "</div>\r\n" +
                                    "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">\r\n" +
                                        "<ul class=\"nav navbar-nav\">\r\n" +
                                            "<li><a href=\"/menu/index\">Go Back</a></li>\r\n" +
                                            "<li>\r\n" +
                                                "<form method=\"post\" action=\"/menu/sorted\" style=\" vertical-align: middle; padding: 10px\">\r\n" +
                            "<select name=\"FirstCriteria\" class=\"form-control\" style=\"display: inline-block; width: auto;\">\r\n" +
                                "<option value=\"sortBy\" selected=\"selected\">Sort By</option>\r\n" +
                                "<option value=\"names\">Names</option>\r\n" +
                                "<option value=\"upvotes\">Up Votes</option>\r\n" +
                                "<option value=\"downvotes\">Down Votes</option>\r\n" +
                            "</select>\r\n" +
                            "<select name=\"SecondCriteria\" class=\"form-control\" style=\"display: inline-block; width: auto\">\r\n" +
                                "<option value=\"thenBy\" selected=\"selected\">Then By</option>\r\n" +
                                "<option value=\"names\">Names</option>\r\n" +
                                "<option value=\"upvotes\">Up Votes</option>\r\n" +
                                "<option value=\"downvotes\">Down Votes</option>\r\n" +
                            "</select>\r\n" +
                                "<input type=\"submit\" class=\"btn btn-primary\" value=\"Sort\" style=\"display: inline-block; width: auto\">\r\n" +
                            "</form>\r\n" +
                            "</li>\r\n" +
                            "</ul>\r\n" +
                            "<ul class=\"nav navbar-nav navbar-right\">\r\n" +
                                "<p class=\"navbar-text navbar-right\"></p>\r\n" +
                                "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>\r\n" +
                                $"<p class=\"navbar-text navbar-right\">Signed in as {Model.First().Owner.Email}</p>\r\n" +
                            "</ul>\r\n</div>\r\n</div>\r\n</nav>");
							
            foreach (var pizzaViewModel in Model)
            {
                html.AppendLine(pizzaViewModel.ToString());
            }
            html.AppendLine("</div>");

            html.AppendLine(File.ReadAllText(Constants.MenuBottom));
            return html.ToString();
        }
    }
}
