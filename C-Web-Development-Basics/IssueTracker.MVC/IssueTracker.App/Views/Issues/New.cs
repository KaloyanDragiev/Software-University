namespace IssueTracker.App.Views.Issues
{
    using System.Text;
    using Utilities;
    using SimpleMVC.Interfaces;

    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            html.Append(Helpers.MenuLogged);
            html.Append(Helpers.IssueNew);
            html.Append(Helpers.Footer);
            html = html.Replace("##username##", Helpers.Username);
            return html.ToString();
        }
    }
}