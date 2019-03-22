namespace PizzaForum.App.Views.Categories
{
    using System.Text;
    using Helpers;
    using SimpleMVC.Interfaces;
    using static Helpers.Constants;

    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Header));
            html.Append(HtmlReader.Read(NavLogged));
            html.Append(HtmlReader.Read(AdminCategoryNew));
            html.Append(HtmlReader.Read(Footer));

            html = html.Replace("##username##", Username);
            return html.ToString();
        }
    }
}