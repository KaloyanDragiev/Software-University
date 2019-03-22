using SimpleHttpServer.Models;
using SoftUniStore.Utilities;

namespace SoftUniStore.Service
{
    using System;
    using System.Linq;
    using Data.Models;
    using Models.BindingModels;

    public class UsersService : BaseService
    {
        public bool RegisterUser(RegisterUserBindingModel rubm)
        {
            if (!IsUserValid(rubm))
            {
                return false;
            }
            User user = new User
            {
                Email =  rubm.Email,
                FullName = rubm.Name,
                IsAdmin = IsUserAdmin(),
                Password = rubm.Password
            };
            Context.Users.Add(user);
            Context.SaveChanges();
            return true;
        }

        private bool IsUserAdmin()
        {
            return !Context.Users.Any();
        }

        private bool IsUserValid(RegisterUserBindingModel rubm)
        {
            if (!rubm.Email.Contains("@") || !rubm.Email.Contains(".") || Context.Users.Any(u => u.Email == rubm.Email))
            {
                return false;
            }

            if (rubm.Password.Length < 6 || !rubm.Password.Any(char.IsDigit) || !rubm.Password.Any(char.IsLower) || !rubm.Password.Any(char.IsUpper))
            {
                return false;
            }
            if (rubm.Password != rubm.ConfirmPassword)
            {
                return false;
            }
            if (String.IsNullOrEmpty(rubm.Name))
            {
                return false;
            }
            return true;
        }

        public bool TryLogin(LoginUserBindingModel lubm, HttpSession session)
        {
            User user = Context.Users.FirstOrDefault(u => u.Email == lubm.Email && u.Password == lubm.Password);
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
            Helpers.Username = user.FullName;
            return true;
        }
    }
}