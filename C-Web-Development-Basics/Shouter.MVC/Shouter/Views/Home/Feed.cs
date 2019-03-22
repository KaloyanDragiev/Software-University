namespace Shouter.Views.Home
{
    using Helpers;
    using System.Collections.Generic;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Feed : IRenderable<IEnumerable<ShoutViewModel>>
    {
        public IEnumerable<ShoutViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder html = new StringBuilder();

            foreach (var shoutViewModel in Model)
            {
                html.AppendLine(shoutViewModel.ToString());
            }

            string originalHtml = HTMLReader.Read(Constants.Feed);
            return string.Format(originalHtml, html);
        }
    }
}