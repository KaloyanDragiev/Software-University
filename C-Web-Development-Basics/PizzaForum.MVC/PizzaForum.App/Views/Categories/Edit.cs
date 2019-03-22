namespace PizzaForum.App.Views.Categories
{
    using System.Text;
    using Helpers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using static Helpers.Constants;

    public class Edit : IRenderable<CategoryViewModel>
    {
        public CategoryViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Header));
            html.Append(HtmlReader.Read(NavLogged));
            html.Append(HtmlReader.Read(AdminCategoryEdit));
            html.Append(HtmlReader.Read(Footer));

            html = html.Replace("##username##", Username);
            html = html.Replace("##newName##", Model.Name);
            html = html.Replace("##catId##", Model.Id.ToString());
            return html.ToString();
        }
    }
}