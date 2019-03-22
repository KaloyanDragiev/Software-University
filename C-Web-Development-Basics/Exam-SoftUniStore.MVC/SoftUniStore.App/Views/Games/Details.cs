namespace SoftUniStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using System.Text;
    using Utilities;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.GameDetails);

            html = html.Replace("##gamedetails##", Model.ToString());
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}