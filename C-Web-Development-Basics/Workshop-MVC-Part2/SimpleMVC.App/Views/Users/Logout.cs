namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;

    using System.Text;

    public class Logout : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder("<h2>Notes App</h2>");
            sb.AppendLine("<a href=\"/users/all\">All users</a> <a href=\"/users/register\">Register Users</a>");
            sb.AppendLine("<a href=\"/users/logout\">Log Out</a>");
            return sb.ToString();
        }
    }
}