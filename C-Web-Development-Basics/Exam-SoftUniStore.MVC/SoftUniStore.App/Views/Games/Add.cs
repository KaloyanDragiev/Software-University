namespace SoftUniStore.App.Views.Games
{
    using System.Text;
    using SimpleMVC.Interfaces;
    using Utilities;

    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.AddGame);
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}