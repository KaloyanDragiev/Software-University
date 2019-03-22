namespace Shouter.Views.Profile
{
    using System.Collections.Generic;
    using System.Text;
    using Models.ViewModels;
    using Helpers;
    using SimpleMVC.Interfaces.Generic;

    public class Following : IRenderable<IEnumerable<FollowingYouViewModel>>
    {
        public IEnumerable<FollowingYouViewModel> Model { get; set; }

        public string Render()
        {
            string originalHtml = HTMLReader.Read(Constants.Following);

            StringBuilder usernames = new StringBuilder();

            foreach (var model in Model)
            {
                usernames.AppendLine(model.ToString());
            }

            originalHtml = originalHtml.Replace("##followingyou##", usernames.ToString());
            originalHtml = originalHtml.Replace("##loggedUser##", Constants.loggedUsername);
            return originalHtml;
        }
    }
}