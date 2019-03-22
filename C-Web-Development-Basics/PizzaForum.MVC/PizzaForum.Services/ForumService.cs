using System.Collections.Generic;
using PizzaForum.Models.ViewModels;

namespace PizzaForum.Services
{
    using Models.BindingModels;
    using System.Linq;
    using Data.Models;
    using System.Text.RegularExpressions;
    using SimpleHttpServer.Models;

    public class ForumService : BaseService
    {
        public bool RegisterUser(RegisterUserBindingModel rubm)
        {
            if (!ValidateUser(rubm))
            {
                return false;
            }
            User user = new User
            {
                Email = rubm.Email,
                Password = rubm.Password,
                Username = rubm.Username,
                IsAdmin = false
            };
            if (!Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            Context.Users.Add(user);
            Context.SaveChanges();
            return true;
        }

        private bool ValidateUser(RegisterUserBindingModel rubm)
        {
            Regex usernameRegex = new Regex("^[a-z0-9]{3,}$");
            Regex passwordRegex = new Regex("^[0-9]{4}$");
            if (!usernameRegex.IsMatch(rubm.Username))
            {
                return false;
            }
            if (!rubm.Email.Contains("@"))
            {
                return false;
            }
            if (!passwordRegex.IsMatch(rubm.Password))
            {
                return false;
            }
            if (rubm.Password != rubm.ConfirmPassword)
            {
                return false;
            }
            if (Context.Users.Any(u => u.Username == rubm.Username) || Context.Users.Any(u => u.Email == rubm.Email))
            {
                return false;
            }
            return true;
        }

        public bool TryLogin(LoginBindingModel lbm, HttpSession session)
        {
            User user = Context.Users.FirstOrDefault(u => u.Email == lbm.Credentials && u.Password == lbm.Password);
            if (user == null)
            {
                user = Context.Users.FirstOrDefault(u => u.Username == lbm.Credentials && u.Password == lbm.Password);
            }
            if (user == null)
            {
                return false;
            }
            Session sessionEntity = new Session
            {
                IsActive = true,
                SessionId = session.Id,
                User = user
            };
            Context.Sessions.Add(sessionEntity);
            Context.SaveChanges();
            return true;
        }

        private bool IsLoginValid(LoginBindingModel lbm)
        {
            return Context.Users.Any(
                user =>
                    (user.Email == lbm.Credentials || user.Username == lbm.Credentials) && user.Password == lbm.Password);
        }

        public IEnumerable<ProfileTopicsViewModel> GetProfileMine(int id)
        {
            User currentUser = Context.Users.Find(id);
            var ptvms = new HashSet<ProfileTopicsViewModel>();

            foreach (var topic in currentUser.Topics)
            {
                var ptvm = new ProfileTopicsViewModel
                {
                    CategoryName = topic.Category.Name,
                    RepliesCount = topic.Replies.Count,
                    TopicId = topic.Id,
                    TopicPublishDate = topic.PublishDate.ToString(),
                    TopicTitle = topic.Title                
                };
                ptvms.Add(ptvm);
            }
            ProfileTopicsViewModel.Username = currentUser.Username;
            ProfileTopicsViewModel.IsMine = true;
            return ptvms;
        }

        public IEnumerable<ProfileTopicsViewModel> GetProfileOther(int id)
        {
            var ptvms = new HashSet<ProfileTopicsViewModel>();
            User user = Context.Users.Find(id);
            foreach (var topic in user.Topics)
            {
                var ptvm = new ProfileTopicsViewModel
                {
                    CategoryName = topic.Category.Name,
                    RepliesCount = topic.Replies.Count,
                    TopicId = topic.Id,
                    TopicPublishDate = topic.PublishDate.ToString(),
                    TopicTitle = topic.Title
                };
                ptvms.Add(ptvm);
            }
            ProfileTopicsViewModel.Username = user.Username;
            ProfileTopicsViewModel.IsMine = false;
            return ptvms;
        }
    }
}