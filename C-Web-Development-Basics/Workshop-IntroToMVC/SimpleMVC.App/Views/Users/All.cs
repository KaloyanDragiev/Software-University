namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            int idCount = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"../../home/index\">&lt; Home</a>");
            sb.AppendLine("<h3> All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var username in Model.Usernames)
            {
                sb.AppendLine($"<li><a href=\"profile?id={idCount++}\">{username}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}