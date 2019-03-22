namespace IssueTracker.App.Views.Issues
{
    using System.Text;
    using Models.ViewModels;
    using Utilities;
    using SimpleMVC.Interfaces.Generic;

    public class Edit : IRenderable<EditIssueViewModel>
    {
        public EditIssueViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            html.Append(Helpers.MenuLogged);
            html.Append(Helpers.IssueEdit);
            html.Append(Helpers.Footer);

            html = html.Replace("##issuetoreplaceid##", Model.IssueId.ToString());
            html = html.Replace("##username##", Helpers.Username);
            return html.ToString();
        }
    }
}