namespace Services
{
    using System.Linq;
    using Data.Models;
    using Models.ViewModels;
    using Data.Data;
    using SimpleHttpServer.Models;
    using Models.BindingModels;
    using System.Collections.Generic;

    public class FollowersService
    {
        private readonly ShouterContext context;
        private readonly HomeServices homeServices;

        public FollowersService()
        {
            this.context = Data.Context;
            this.homeServices = new HomeServices();
        }

        public ProfileViewModel GetProfile(int id)
        {
            User user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                ProfileViewModel profileVm = new ProfileViewModel
                {
                    Username = user.Username,
                    ProfileId = user.Id
                };
                foreach (var shout in user.Shouts)
                {
                    ShoutViewModel shoutVM = new ShoutViewModel
                    {
                        Content = shout.Content,
                        RelativeTime = homeServices.GetRelativeTime(shout.PublishTime),
                        Username = user.Username,
                        ProfileId = user.Id
                    };

                    profileVm.UserShouts.Add(shoutVM);
                }
                return profileVm;
            }
            return null;
        }
        
        public FollowingViewModel GetFollowing(HttpSession session)
        {
            User userEntity = GetCurrentUser(session);

            var allUsers = context.Users.ToList();

            return FollowingViewModel(userEntity, allUsers);
        }

        public FollowingViewModel GetFollowingFilter(HttpSession session, string filter)
        {
            User userEntity = GetCurrentUser(session);

            var allUsers = context.Users.Where(u => u.Username.Contains(filter)).ToList();

            return FollowingViewModel(userEntity, allUsers);
        }

        private static FollowingViewModel FollowingViewModel(User userEntity, List<User> Users)
        {
            FollowingViewModel followingVM = new FollowingViewModel
            {
                Username = userEntity.Username
            };

            foreach (var user in Users.Where(u => u != userEntity))
            {
                if (userEntity.Following.Any(u => u.Id == user.Id))
                {
                    followingVM.Followings.Add(
                        $"<li><h4><strong><a href=\"/followers/profile?id={user.Id}\">{user.Username}  </a></strong><form style=\"display: inline\" method=\"post\" action=\"/followers/all\"><input type=\"hidden\" name=\"Id\" value=\"{user.Id}\"><input type=\"submit\" class=\"btn btn-danger\" value=\"Unfollow\"/></form> </h4></li>");
                }
                else
                {
                    followingVM.Followings.Add(
                        $"<li><h4><strong><a href=\"/followers/profile?id={user.Id}\">{user.Username} </a></strong><form style=\"display: inline\" method=\"post\" action=\"/followers/all\"><input type=\"hidden\" name=\"Id\" value=\"{user.Id}\"><input type=\"submit\" class=\"btn btn-success\" value=\"Follow\"/></form> </h4></li>");
                }
            }
            return followingVM;
        }

        public void FollowUnfollow(HttpSession session, FollowingBindingModel fbm)
        {
            User curentUser = GetCurrentUser(session);
            User userToManipulate = context.Users.Find(fbm.Id);
            if (curentUser.Following.Any(u => u.Id == fbm.Id))
            {
                curentUser.Following.Remove(userToManipulate);
                userToManipulate.Followers.Remove(curentUser);
            }
            else
            {
                curentUser.Following.Add(userToManipulate);
                userToManipulate.Followers.Add(curentUser);
            }
            context.SaveChanges();
        }

        public IEnumerable<ShoutViewModel> GetFollowingShouts(HttpSession session)
        {
            var shoutVMs = new List<ShoutViewModel>();
            var user = GetCurrentUser(session);
            var shouts = new List<Shout>();
            foreach (var following in user.Following)
            {
                foreach (var shout in following.Shouts)
                {
                    shouts.Add(shout);
                }
            }
            var orderedShouts = shouts.OrderByDescending(s => s.PublishTime);
            foreach (var shout in orderedShouts)
            {
                var shoutVM = new ShoutViewModel
                {
                    Content = shout.Content,
                    Username = shout.User.Username,
                    ProfileId = shout.User.Id,
                    RelativeTime = homeServices.GetRelativeTime(shout.PublishTime)
                };
                shoutVMs.Add(shoutVM);
            }

            return shoutVMs;
        }

        public User GetCurrentUser(HttpSession session)
        {
            return context.Sessions.FirstOrDefault(s => s.SessionId == session.Id)?.User;
        }
    }
}