namespace PizzaForum.App.Views.Topics
{
    using System.Text;
    using Helpers;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using static Helpers.Constants;

    public class New : IRenderable<IEnumerable<NewTopicViewModel>>
    {
        public IEnumerable<NewTopicViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Header));
            html.Append(HtmlReader.Read(NavLogged));
            html.Append(HtmlReader.Read(TopicNew));
            html.Append(HtmlReader.Read(Footer));

            StringBuilder allCategories = new StringBuilder();

            foreach (var model in Model)
            {
                allCategories.AppendLine(model.ToString());
            }

            html = html.Replace("##categoryChoice##", allCategories.ToString());
            html = html.Replace("##username##", Username);
            return html.ToString();
        }
    }
}