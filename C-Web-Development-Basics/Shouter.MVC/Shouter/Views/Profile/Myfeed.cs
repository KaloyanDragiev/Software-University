namespace Shouter.Views.Profile
{
    using System.Text;
    using Models.ViewModels;
    using Helpers;
    using SimpleMVC.Interfaces.Generic;

    public class Myfeed : IRenderable<ProfileViewModel>
    {
        public ProfileViewModel Model { get; set; }

        public string Render()
        {
            string originalHtml = HTMLReader.Read(Constants.MyFeed);

            StringBuilder shouts = new StringBuilder();
            foreach (var shout in Model.UserShouts)
            {
                var shoutText = shout.ToString();
                var shoutWithDelete = shoutText.Insert(shoutText.Length - 6,
                    $"<form method=\"post\">\r\n\t\t\t<input type=\"hidden\" name=\"shoutId\" value=\"{shout.Id}\">\r\n\t\t\t<input type=\"submit\" class=\"btn btn-danger\" value=\"Delete\"/>\r\n\t\t\t</form>");
                 shouts.AppendLine(shoutWithDelete);
            }

            string modifiedHtml = originalHtml.Replace("##username##", Model.Username);
            modifiedHtml = modifiedHtml.Replace("##userShouts##", shouts.ToString());

            return modifiedHtml;
        }
    }
}