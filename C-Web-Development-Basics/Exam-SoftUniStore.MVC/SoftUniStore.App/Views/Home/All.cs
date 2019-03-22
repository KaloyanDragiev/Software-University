namespace SoftUniStore.App.Views.Home
{
    using System.Collections.Generic;
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using System.Text;
    using Utilities;

    public class All : IRenderable<IEnumerable<HomePageGameViewModel>>
    {
        public IEnumerable<HomePageGameViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.Home);

            StringBuilder gamesHtml = new StringBuilder();
            int counter = 0;
            foreach (var model in Model)
            {
                if (counter % 3 == 0)
                {
                    gamesHtml.AppendLine("<div class=\"card-group\">");
                }
                gamesHtml.AppendLine(model.ToString());
                if (counter % 3 == 2)
                {
                    gamesHtml.AppendLine("</div>");
                }
                counter++;
            }

            html = html.Replace("##allgameshere##", gamesHtml.ToString());
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}