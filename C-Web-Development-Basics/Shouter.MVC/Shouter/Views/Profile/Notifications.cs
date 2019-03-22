namespace Shouter.Views.Profile
{
    using System.Collections.Generic;
    using System.Text;
    using Models.ViewModels;
    using Helpers;
    using SimpleMVC.Interfaces.Generic;

    public class Notifications : IRenderable<IEnumerable<NotificationViewModel>>
    {
        public IEnumerable<NotificationViewModel> Model { get; set; }

        public string Render()
        {
            string originalHtml = HTMLReader.Read(Constants.Notifications);

            StringBuilder notifications = new StringBuilder();

            foreach (var model in Model)
            {
                notifications.AppendLine(model.ToString());
            }

            originalHtml = originalHtml.Replace("##loggedUser##", Constants.loggedUsername);
            return originalHtml.Replace("##notifyMe##", notifications.ToString());
        }
    }
}