namespace PizzaForum.Models.ViewModels
{
    using System.Collections.Generic;
    using System.Text;

    public class TopicDetailsViewModel
    {
        public int TopicId { get; set; }

        public string TopicTitle { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public string Date { get; set; }

        public string Content { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }

        public override string ToString()
        {
            StringBuilder topic = new StringBuilder();
            topic.AppendLine("<div class=\"container\">");
            topic.AppendLine(
                $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"/topics/details?id={this.TopicId}\">{this.TopicTitle}</a><strong></h4>\r\n\t<p><a href=\"/forum/profile?id={this.AuthorId}\">{this.AuthorName}</a> {this.Date}</p>\r\n\t<p>{this.Content}</p>\r\n</div>");

            foreach (var reply in Replies)
            {
                topic.AppendLine(reply.ToString());
            }

            return topic.ToString();
        }
    }
}