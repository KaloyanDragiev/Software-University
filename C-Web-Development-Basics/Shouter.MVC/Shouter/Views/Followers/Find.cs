namespace Shouter.Views.Followers
{
    using System.Text;
    using Models.ViewModels;
    using Helpers;
    using SimpleMVC.Interfaces.Generic;

    public class Find : IRenderable<FollowingViewModel>
    {
        public FollowingViewModel Model { get; set; }

        public string Render()
        {
            string originalHtml = HTMLReader.Read(Constants.Followers);

            StringBuilder followerButtons = new StringBuilder();

            foreach (var modelFollowing in Model.Followings)
            {
                followerButtons.AppendLine(modelFollowing);
            }
            originalHtml = originalHtml.Replace("##loggedUser##", Constants.loggedUsername);
            return originalHtml.Replace("##following##", followerButtons.ToString());
        }
    }
}