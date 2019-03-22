namespace SoftUniStore.App.Views.Users
{
    using System.Text;
    using SimpleMVC.Interfaces;
    using Utilities;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavNotLogged);
            html.AppendLine(Helpers.Login);
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}