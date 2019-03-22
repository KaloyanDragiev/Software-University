namespace PizzaForum.App.Views.Categories
{
    using System.Text;
    using Helpers;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<IEnumerable<CategoryViewModel>>
    {
        public IEnumerable<CategoryViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Constants.Header));
            html.Append(HtmlReader.Read(Constants.NavLogged));
            html.Append(HtmlReader.Read(Constants.AdminCategories));
            html.Append(HtmlReader.Read(Constants.Footer));

            StringBuilder categories = new StringBuilder();

            foreach (var model in Model)
            {
                categories.AppendLine(model.ToString());
            }

            html = html.Replace("##username##", Constants.Username);
            html = html.Replace("##admincategories##", categories.ToString());
            return html.ToString();
        }
    }
}