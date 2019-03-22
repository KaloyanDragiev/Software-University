namespace Shouter.Views.Followers
{
    using Helpers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Text;

    public class Profile : IRenderable<ProfileViewModel>
    {
        public ProfileViewModel Model { get; set; }

        public string Render()
        {
            string originalHtml = HTMLReader.Read(Constants.Profile);

            StringBuilder shouts = new StringBuilder();
            foreach (var shout in Model.UserShouts)
            {
                shouts.AppendLine(shout.ToString());
            }

            originalHtml = originalHtml.Replace("##username##", Model.Username);
            originalHtml = originalHtml.Replace("##profileShouts##", shouts.ToString());

            return originalHtml;
        }
    }
}