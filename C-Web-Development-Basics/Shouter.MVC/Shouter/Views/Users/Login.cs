namespace Shouter.Views.Users
{
    using System.Text;
    using Helpers;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(HTMLReader.Read(Constants.Header));
            html.AppendLine(HTMLReader.Read(Constants.Login));
            html.AppendLine(HTMLReader.Read(Constants.Footer));
            return html.ToString();
        }
    }
}