namespace PizzaForum.Models.ViewModels
{
    public class ReplyViewModel
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Date { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            if (ImageUrl == null)
            {
                return
                    $"<div class=\"thumbnail reply\">\r\n\t<h5><strong><a href=\"/forum/profile?id={this.AuthorId}\">{this.AuthorName}</a><strong> {this.Date}</h5>\r\n\t<p>{this.Content}</p>\r\n</div>\t\t";
            }
            return
                $"<div class=\"thumbnail reply\">\r\n\t<h5><strong><a href=\"/forum/profile?id={this.AuthorId}\">{this.AuthorName}</a><strong> {this.Date}</h5>\r\n\t<p>{this.Content}</p>\r\n\t<img src=\"{this.ImageUrl}\" class=\"img-thumbnail\" />\r\n</div>\t\t";
        }
    }
}