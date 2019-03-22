namespace SoftUniStore.App.Views.Games
{
    using System.Collections.Generic;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using Utilities;

    public class Manage : IRenderable<IEnumerable<ManagingGamesViewModel>>
    {
        public IEnumerable<ManagingGamesViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.AdminGames);

            StringBuilder adminGames = new StringBuilder();
            foreach (var model in Model)
            {
                adminGames.AppendLine(model.ToString());
            }

            html = html.Replace("##admingames##", adminGames.ToString());
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}