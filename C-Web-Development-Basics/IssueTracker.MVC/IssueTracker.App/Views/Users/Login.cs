namespace IssueTracker.App.Views.Users
{
    using SimpleMVC.Interfaces;
    using System.Text;
    using Utilities;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            html.Append(Helpers.MenuNotLogged);
            html.Append(Helpers.Login);
            html.Append(Helpers.Footer);
            return html.ToString();
        }
    }
}