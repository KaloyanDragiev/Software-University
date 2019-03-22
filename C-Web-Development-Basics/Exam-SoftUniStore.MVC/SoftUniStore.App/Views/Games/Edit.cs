namespace SoftUniStore.App.Views.Games
{
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using System.Text;
    using Utilities;

    public class Edit : IRenderable<EditGameViewModel>
    {
        public EditGameViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(Helpers.Header);
            html.AppendLine(Helpers.NavLogged);
            html.AppendLine(Helpers.Edit);
            html = html.Replace("##gameid##", Model.GameId.ToString());
            html = html.Replace("##oldtitle##", Model.Title);
            html = html.Replace("##oldgamedescription##", Model.Description);
            html = html.Replace("##oldthumbnail##", Model.Thumbnail);
            html = html.Replace("##oldprice##", Model.Price.ToString());
            html = html.Replace("##oldsize##", Model.Size.ToString());
            html = html.Replace("##oldyoutubeid##", Model.YouTubeId);
            html.AppendLine(Helpers.Footer);
            return html.ToString();
        }
    }
}