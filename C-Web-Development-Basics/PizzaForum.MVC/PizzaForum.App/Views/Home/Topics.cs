namespace PizzaForum.App.Views.Home
{
    using System.Collections.Generic;
    using System.Text;
    using Helpers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Topics : IRenderable<IEnumerable<TopicViewModel>>
    {
        public IEnumerable<TopicViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Constants.Header));
            html.Append("<div class=\"container\">");
            if (TopicViewModel.Button == "")
            {
                html.Append(HtmlReader.Read(Constants.NavNotLogged));
            }
            else
            {
                html.Append(HtmlReader.Read(Constants.NavLogged));
                html.Append(TopicViewModel.Button);
            }
            foreach (var topic in Model)
            {
                html.AppendLine(topic.ToString());
            }
            html.Append("</div>");
            html.Append(HtmlReader.Read(Constants.Footer));

            html = html.Replace("##username##", Constants.Username);
            return html.ToString();
        }
    }
}