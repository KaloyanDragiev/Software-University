namespace PizzaForum.App.Views.Home
{
    using System.Collections.Generic;
    using System.Text;
    using Helpers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Categories : IRenderable<IEnumerable<NormalUserCategoryViewModel>>
    {
        public IEnumerable<NormalUserCategoryViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Constants.Header));
            html.Append("<div class=\"container\">");
            html.Append(HtmlReader.Read(Constants.NavLogged));
            html.Append("<ul>");
            foreach (var category in Model)
            {
                html.AppendLine(category.ToString());
            }
            html.Append("</ul>");
            html.Append("</div>");
            html.Append(HtmlReader.Read(Constants.Footer));

            html = html.Replace("##username##", Constants.Username);
            return html.ToString();
        }
    }
}