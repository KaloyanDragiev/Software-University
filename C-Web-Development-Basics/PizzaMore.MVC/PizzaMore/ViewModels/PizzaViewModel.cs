namespace PizzaMore.ViewModels
{
    using System.Text;
    using Models;
    using System.Linq;
    using System.Collections.Generic;

    public class PizzaViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public User Owner { get; set; }

        public ICollection<User> VotedUsers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"card\">");
            sb.AppendLine($"<img class=\"card-img-top\" src=\"{this.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
            sb.AppendLine("<div class=\"card-block\">");
            sb.AppendLine($"<h4 class=\"card-title\">{this.Title}</h4>");
            sb.AppendLine($"<p class=\"card-text\"><a href=\"/menu/details?pizzaid={this.Id}\">Recipe</a></p>");

            if (VotedUsers.Any(u => u == Owner))
            {
                sb.AppendLine($"<p> Up: {this.UpVotes}");
                sb.AppendLine($"<p> Down: {this.DownVotes}");
            }
            else
            {
                sb.AppendLine("<form method=\"POST\" action=\"/menu/index\">");
                sb.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"Pizzavote\" value=\"up\">Up</label></div>");
                sb.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"Pizzavote\" value=\"down\">Down</label></div>");
                sb.AppendLine($"<input type=\"hidden\" name=\"Pizzaid\" value=\"{this.Id}\" />");
                sb.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
            }
            
            sb.AppendLine("</form>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }
    }
}