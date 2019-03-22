namespace PizzaForum.App.Views.Forum
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Text;
    using Helpers;

    public class Profile : IRenderable<IEnumerable<ProfileTopicsViewModel>>
    {
        public IEnumerable<ProfileTopicsViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();
            html.Append(HtmlReader.Read(Constants.Header));
            html.Append(HtmlReader.Read(Constants.NavLogged));

            if (!ProfileTopicsViewModel.IsMine)
            {
                html.Append(HtmlReader.Read(Constants.ProfileOther));
            }
            else
            {
                html.Append(HtmlReader.Read(Constants.ProfileMine));
            }

            StringBuilder topics = new StringBuilder();
            foreach (var topic in Model)
            {
                topics.AppendLine(topic.ToString());
            }

            html.Append(HtmlReader.Read(Constants.Footer));

            html.Replace("##profileUsername##", ProfileTopicsViewModel.Username);
            html.Replace("##profiletopics##", topics.ToString());
            html = html.Replace("##username##", Constants.Username);
            return html.ToString();
        }
    }
}