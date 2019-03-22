namespace PizzaForum.App.Views.Topics
{
    using System.Text;
    using Helpers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using static Helpers.Constants;

    public class Details : IRenderable<TopicDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Header));
            html.Append(HtmlReader.Read(NavLogged));
            html.AppendLine(Model.ToString());
            html.Append(HtmlReader.Read(TopicDetailsReplyForm));
            html.Append("</div>");
            html.Append(HtmlReader.Read(Footer));          

            html = html.Replace("##username##", Username);
            html = html.Replace("##topicid##", Model.TopicId.ToString());
            return html.ToString();
        }

        public TopicDetailsViewModel Model { get; set; }
    }
}