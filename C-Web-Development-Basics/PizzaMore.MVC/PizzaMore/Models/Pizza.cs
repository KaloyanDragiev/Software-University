namespace PizzaMore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using System.Collections.Generic;

    public class Pizza
    {
        public Pizza()
        {
            this.UsersVoted = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Recipe { get; set; }
        
        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public virtual ICollection<User> UsersVoted { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<form method=\"POST\" action=\"/menu/suggestions\">");
            sb.AppendLine($"<li><a href=\"/menu/details?pizzaid={this.Id}\">{this.Title}</a> <input type=\"hidden\" name=\"Pizzaid\" value=\"{this.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
            sb.AppendLine("</form>");
            return sb.ToString();
        }
    } 
}