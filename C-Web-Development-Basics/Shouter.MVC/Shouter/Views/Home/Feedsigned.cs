namespace Shouter.Views.Home
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using Helpers;
    using System.Text;

    public class Feedsigned : IRenderable<IEnumerable<ShoutViewModel>>
    {
        public IEnumerable<ShoutViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();

            foreach (var shoutViewModel in Model)
            {
                html.AppendLine(shoutViewModel.ToString());
            }
            string originalHtml = HTMLReader.Read(Constants.FeedSigned);
            originalHtml = originalHtml.Replace("##loggedUser##", Constants.loggedUsername);
            return string.Format(originalHtml, html);
        }
    }
}