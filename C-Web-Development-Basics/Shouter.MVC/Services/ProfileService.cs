namespace Services
{
    using Data.Data;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public class ProfileService
    {
        private readonly ShouterContext context;
        private readonly HomeServices homeServices;

        public ProfileService()
        {
            this.context = Data.Context;
            this.homeServices = new HomeServices();
        }

        public ProfileViewModel DisplayProfileShouts(HttpSession session)
        {
            User user = GetCurrentUser(session);
            var profileVm = new ProfileViewModel
            {
                ProfileId = user.Id,
                Username = user.Username,
                UserShouts = GetProfileShouts(session, user)
            };
            return profileVm;
        }

        private HashSet<ShoutViewModel> GetProfileShouts(HttpSession session, User user)
        {
            var shoutVMs = new HashSet<ShoutViewModel>();
            var userShouts = user.Shouts.OrderByDescending(s => s.PublishTime);
            foreach (var shout in userShouts)
            {
                var shoutVM = new ShoutViewModel
                {
                    Content = shout.Content,
                    Username = shout.User.Username,
                    ProfileId = shout.User.Id, 
                    Id = shout.Id,
                    RelativeTime = homeServices.GetRelativeTime(shout.PublishTime)
                };
                shoutVMs.Add(shoutVM);
            }
            return shoutVMs;
        }

        public void DeleteShout(int shoutId)
        {
            Shout shoutToRemove = context.Shouts.Find(shoutId);
            context.Shouts.Remove(shoutToRemove);
            context.SaveChanges();
        }

        public IEnumerable<FollowingYouViewModel> WhoIsFollowingYou(HttpSession session)
        {
            User user = GetCurrentUser(session);
            HashSet<FollowingYouViewModel> followingYouVMs = new HashSet<FollowingYouViewModel>();

            foreach (var follower in user.Followers)
            {
                FollowingYouViewModel fyvm = new FollowingYouViewModel
                {
                    Id = follower.Id,
                    Username = follower.Username
                };
                followingYouVMs.Add(fyvm);
            }
            return followingYouVMs;
        }

        public IEnumerable<NotificationViewModel> GetNotifications(HttpSession session)
        {
            User user = GetCurrentUser(session);
            HashSet<NotificationViewModel> notificationVMs = new HashSet<NotificationViewModel>();

            foreach (var shout in user.UnviewedShouts.OrderByDescending(s => s.PublishTime))
            {
                var nfvm = new NotificationViewModel
                {
                    Id = shout.User.Id,
                    Username = shout.User.Username
                };

                notificationVMs.Add(nfvm);
            }
            user.UnviewedShouts.Clear();
            return notificationVMs;
        }

        private User GetCurrentUser(HttpSession session)
        {
            return context.Sessions.FirstOrDefault(s => s.SessionId == session.Id)?.User;
        }


    }
}