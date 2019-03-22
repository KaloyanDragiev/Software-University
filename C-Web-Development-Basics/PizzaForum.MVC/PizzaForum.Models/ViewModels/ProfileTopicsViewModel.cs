namespace PizzaForum.Models.ViewModels
{
    public class ProfileTopicsViewModel
    {
        public static string Username { get; set; }

        public static bool IsMine { get; set; }

        public int TopicId { get; set; }

        public string TopicTitle { get; set; }  

        public string CategoryName { get; set; }

        public string TopicPublishDate { get; set; }

        public int RepliesCount { get; set; }

        public override string ToString()
        {
            if (IsMine)
            {
                return $"<tr>\r\n\t\t\t\t<td><a href=\"/topics/details?id={this.TopicId}\">{this.TopicTitle}</a></td>" +
            $"\r\n\t\t\t\t<td><a href=\"/categories/topics?CategoryName={this.CategoryName}\">{this.CategoryName}</a></td>" +
            $"\r\n\t\t\t\t<td>{this.TopicPublishDate}</td>\r\n\t\t\t\t" +
            $"<td>{this.RepliesCount}</td>\r\n\t\t\t\t" +
            $"<td><a href=\"/topics/delete?id={this.TopicId}\" class=\"btn btn-danger\">Delete</a></td>\r\n\t\t\t</tr>";
            }
            return $"<tr>\r\n\t\t\t\t<td><a href=\"/topics/details?id={this.TopicId}\">{this.TopicTitle}</a></td>" +
            $"\r\n\t\t\t\t<td><a href=\"/categories/topics?CategoryName={this.CategoryName}\">{this.CategoryName}</a></td>" +
            $"\r\n\t\t\t\t<td>{this.TopicPublishDate}</td>\r\n\t\t\t\t" +
            $"<td>{this.RepliesCount}</td></tr>";
        }
    }
}