namespace IssueTracker.App.Views.Home
{
    using SimpleMVC.Interfaces;
    using System.Text;
    using Utilities;

    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            if (string.IsNullOrEmpty(Helpers.Username))
                html.Append(Helpers.MenuNotLogged);
            else
                html.Append(Helpers.MenuLogged);
            html.Append(Helpers.Home);
            html.Append(Helpers.Footer);
            html = html.Replace("##username##", Helpers.Username);
            return html.ToString();
        }
    }
}