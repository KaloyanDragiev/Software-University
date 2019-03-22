namespace PizzaForum.Models.ViewModels
{
    public class TopicViewModel
    {
        public int TopicId { get; set; }

        public string TopicTitle { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public int RepliesCount { get; set; }

        public static string Button = "";

        public string Date { get; set; }

        public override string ToString()
        {
            return
                $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"/topics/details?id={this.TopicId}\">{this.TopicTitle}</a><strong> <small><a href=\"/categories/topics?CategoryName={this.CategoryName}\">{this.CategoryName}</a></small></h4>\r\n\t<p><a href=\"/forum/profile?id={this.AuthorId}\">{this.AuthorName}</a> | Replies: {this.RepliesCount} | {this.Date}</p>\r\n</div>";
        }

        public static void LoggedUserButton()
        {
            Button = "<p><a href=\"/topics/new\" class=\"btn btn-success\">New Topic</a></p><br>";
        }

        public static void GuestUserButton()
        {
            Button = "";
        }
    }
}