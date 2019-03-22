namespace Shouter.Views.Followers
{
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Text;
    using Helpers;

    public class Feed : IRenderable<IEnumerable<ShoutViewModel>>
    {
        public IEnumerable<ShoutViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();

            foreach (var shoutViewModel in Model)
            {
                html.AppendLine(shoutViewModel.ToString());
            }
            string originalHtml = HTMLReader.Read(Constants.FollowersFeed);
            originalHtml = originalHtml.Replace("##loggedUser##", Constants.loggedUsername);
            return originalHtml.Replace("##followersfeed##", html.ToString());
        }
    }
}