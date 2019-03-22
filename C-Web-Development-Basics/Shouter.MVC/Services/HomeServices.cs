namespace Services
{
    using Data.Data;
    using Data.Models;
    using Models.BindingModels;
    using SimpleHttpServer.Models;
    using System.Linq;
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using Models.ViewModels;

    public class HomeServices
    {
        private ShouterContext Context { get; }

        public HomeServices()
        {
            this.Context = Data.Context;
        }

        public void PublishShout(ShoutBindingModel shout, HttpSession session)
        {
            User currentUser = Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User;

            if (ShoutValidator(shout))
            {
                Shout shoutEntity = new Shout
                {
                    Content = ModifyContent(shout.ShoutContent),
                    HourDuration = int.Parse(shout.Expire),
                    User = currentUser,
                    PublishTime = DateTime.Now
                };
                var usersToNotify = currentUser.Followers;
                foreach (var user in usersToNotify)
                {
                    user.UnviewedShouts.Add(shoutEntity);
                }
                Context.Shouts.Add(shoutEntity);
                Context.SaveChanges();
            }
        }

        private bool ShoutValidator(ShoutBindingModel shout)
        {
            return shout.ShoutContent.Length < 160 && shout.Expire != null;
        }

        private string ModifyContent(string content)
        {
            Regex httpsRegex = new Regex("https://[^ ]+");
            Regex httpRegex = new Regex("http://[^ ]+");
            Regex wwwRegex = new Regex("www\\.[^ ]+");

            string result = content;

            Match httpMatch = httpRegex.Match(content);
            if (httpMatch.Success)
            {
                return httpRegex.Replace(content, $"<a href=\"{httpMatch.Value}\">{httpMatch.Value}</a>");
            }

            Match httpsMatch = httpsRegex.Match(content);
            if (httpsMatch.Success)
            {
                return httpsRegex.Replace(content, $"<a href=\"{httpsMatch.Value}\">{httpsMatch.Value}</a>");
            }

            Match wwwMatch = wwwRegex.Match(content);
            if (wwwMatch.Success)
            {
                return wwwRegex.Replace(content, $"<a href=\"{wwwMatch.Value}\">{wwwMatch.Value}</a>");
            }

            return result;
        }

        public IEnumerable<ShoutViewModel> GetShouts(HttpSession session)
        {
            var shoutVMs = new List<ShoutViewModel>();
            var allShouts = Context.Shouts.OrderByDescending(s => s.PublishTime);
            User user = Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id)?.User;
            foreach (var shout in allShouts)
            {
                var shoutVM = new ShoutViewModel
                {
                    Content = shout.Content,
                    Username = shout.User.Username,
                    ProfileId = shout.User.Id,
                    RelativeTime = GetRelativeTime(shout.PublishTime),
                };
                shoutVMs.Add(shoutVM);
            }
            return shoutVMs;
        }

        public string GetRelativeTime(DateTime? date)
        {
            DateTime now = DateTime.Now;
            TimeSpan? diff = now - date;
            if (Math.Abs(diff.Value.Seconds) <= 1)
            {
                return "less than a second";
            }
            else if ((int)diff.Value.TotalSeconds <= 60)
            {
                return "less than a minute";
            }
            else if (diff.Value.TotalHours < 1)
            {
                return $"{(int)diff.Value.TotalMinutes} minutes ago";
            }
            else if (diff.Value.TotalDays < 1)
            {
                return $"{(int)diff.Value.TotalHours} hours ago";
            }
            else if (diff.Value.TotalDays <= 30)
            {
                return $"{(int)diff.Value.TotalDays} days ago";
            }
            else if (diff.Value.TotalDays <= 365)
            {
                return $"{(int)diff.Value.TotalDays / 30} months ago";
            }
            return "more than a year";
        }
    }
}