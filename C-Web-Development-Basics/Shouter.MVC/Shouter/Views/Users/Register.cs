namespace Shouter.Views.Users
{
    using SimpleMVC.Interfaces;
    using Helpers;
    using System.Text;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(HTMLReader.Read(Constants.Header));
            html.AppendLine(HTMLReader.Read(Constants.Register));
            html.AppendLine(HTMLReader.Read(Constants.Footer));
            return html.ToString();
        }
    }
}