namespace SoftUniStore.App.Views.Games
{
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using Utilities;

    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public DeleteGameViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.DeleteGame);
            html = html.Replace("##gameid##", Model.GameId.ToString());
            html = html.Replace("##gametitle##", Model.Title);
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}