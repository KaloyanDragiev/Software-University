namespace PizzaForum.App.Views.Forum
{
    using System.Text;
    using Helpers;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Constants.Header));
            html.Append(HtmlReader.Read(Constants.NavNotLogged));
            html.Append(HtmlReader.Read(Constants.Login));
            html.Append(HtmlReader.Read(Constants.Footer));
            return html.ToString();
        }
    }
}