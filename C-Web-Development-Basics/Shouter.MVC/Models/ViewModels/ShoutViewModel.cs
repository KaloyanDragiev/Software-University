namespace Models.ViewModels
{
    public class ShoutViewModel
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public string Username { get; set; }

        public string RelativeTime { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            return
                $"<div class=\"thumbnail\">\r\n\t\t\t<h4><strong><a href=\"profile?id={this.ProfileId}\">{this.Username}</a></strong> <small>{RelativeTime}</small></h4>\r\n\t\t\t<p>{this.Content}</p>\r\n\t\t</div>";
        }
    }
}