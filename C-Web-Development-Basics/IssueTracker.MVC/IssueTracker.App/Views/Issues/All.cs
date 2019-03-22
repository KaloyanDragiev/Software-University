namespace IssueTracker.App.Views.Issues
{
    using System.Collections.Generic;
    using System.Text;
    using Models.ViewModels;
    using Utilities;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<IEnumerable<IssueViewModel>>
    {
        public IEnumerable<IssueViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            html.Append(Helpers.MenuLogged);
            html.Append(Helpers.Issues);
            html.Append(Helpers.Footer);

            StringBuilder issuesHtml = new StringBuilder();
            foreach (var issue in Model)
            {
                issuesHtml.Append(issue);
            }
            html = html.Replace("##issuesall##", issuesHtml.ToString());

            html = html.Replace("##username##", Helpers.Username);
            return html.ToString();
        }
    }
}