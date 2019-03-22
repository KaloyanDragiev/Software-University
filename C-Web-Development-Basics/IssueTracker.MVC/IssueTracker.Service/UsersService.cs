namespace IssueTracker.Service
{
    using System.Collections.Generic;
    using Models.BindingModels;
    using Models.ViewModels;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Data.Models;
    using SimpleHttpServer.Models;
    using Utilities;

    public class UsersService : Service
    {
        public IEnumerable<ErrorViewModel> RegisterUser(RegisterUserBindingModel rubm)
        {
            var errors = ValidateUser(rubm);

            if (!errors.Any())
            {
                User user = new User
                {
                    FullName = rubm.FullName,
                    Password = rubm.Password,
                    Username = rubm.Username,
                    Role = GetUserRole()
                };
                Context.Users.Add(user);
                Context.SaveChanges();
            }

            return errors;
        }

        public Role GetUserRole()
        {
            return Context.Users.Any() ? Role.Regular : Role.Administrator;
        }

        public IEnumerable<ErrorViewModel> ValidateUser(RegisterUserBindingModel rubm)
        {
            HashSet<ErrorViewModel> errors = new HashSet<ErrorViewModel>();
            if (rubm.Username.Length < 5 || rubm.Username.Length >30)
            {
                errors.Add(new ErrorViewModel{ Message = "The username should be between 5 and 30 symbols" });
            }
            if (rubm.FullName.Length < 5)
            {
                errors.Add(new ErrorViewModel { Message = "The full name should be at least 5 symbols" });
            }

            Regex passwordPatter = new Regex("[!@#$%^&*,.]");
            if (!passwordPatter.IsMatch(rubm.Password) || !rubm.Password.Any(char.IsDigit) || !rubm.Password.Any(char.IsUpper) || rubm.Password.Length < 8)
            {
                errors.Add(new ErrorViewModel { Message = "The password is not in the correct format" });
            }

            if (rubm.Password != rubm.RepeatPassword)
            {
                errors.Add(new ErrorViewModel { Message = "Passwords do not match" });
            }
            return errors;
        }

        public bool TryLogin(LoginUserBindingModel lubm, HttpSession session)
        {
            User user = Context.Users.FirstOrDefault(u => u.Username == lubm.Username && u.Password == lubm.Password);
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
            Helpers.Username = lubm.Username;
            return true;
        }
    }
}