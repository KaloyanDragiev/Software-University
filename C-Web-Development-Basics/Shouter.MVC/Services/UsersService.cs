namespace Services
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models.BindingModels;
    using Data.Data;
    using Data.Models;
    using SimpleHttpServer.Models;
    using Helpers;

    public class UsersService
    {
        private ShouterContext Context { get; }

        public UsersService()
        {
            this.Context = Data.Context;
        }

        public bool RegisterUser(RegisterUserBindingModel model)
        {
            if (IsUserValid(model))
            {
                User user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Username = model.Username,
                };
                Context.Users.Add(user);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsUserValid(RegisterUserBindingModel model)
        {
            Regex nameRegex = new Regex("[0-9A-Za-z]+");
            if (!nameRegex.IsMatch(model.Username) || Context.Users.Any(u => u.Username == model.Username))
            {
                return false;
            }
            if (!model.Email.Contains("@") || Context.Users.Any(u => u.Email == model.Email))
            {
                return false;
            }
            if (model.Password.Length < 3)
            {
                return false;
            }
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            return true;
        }

        public bool LoginUser(LoginBindingModel model, HttpSession session)
        {
            User user = Context.Users.FirstOrDefault(u => (u.Password == model.Password && u.Username == model.Credentials) || u.Password == model.Password && u.Email == model.Credentials);
            if (user != null)
            {
                Session sessionEntity = new Session
                {
                    IsActive = true,
                    SessionId = session.Id,
                    User = user
                };
                Context.Sessions.Add(sessionEntity);
                Context.SaveChanges();
                Constants.loggedUsername = user.Username;
                return true;
            }
        return false;
        }
    }
}