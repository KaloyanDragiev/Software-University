namespace IssueTracker.App.Views.Users
{
    using Utilities;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Text;

    public class Register : IRenderable<IEnumerable<ErrorViewModel>>
    {
        public IEnumerable<ErrorViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(Helpers.Header);
            html.Append(Helpers.MenuNotLogged);

            html.Append("<div class=\"container\">");
            StringBuilder errors = new StringBuilder();
            foreach (var errorViewModel in Model)
            {
                errors.Append(errorViewModel);
            }
            html.Append(errors);
            html.Append("</div>");

            html.Append(Helpers.Register);
            html.Append(Helpers.Footer);
            return html.ToString();
        }
    }
}