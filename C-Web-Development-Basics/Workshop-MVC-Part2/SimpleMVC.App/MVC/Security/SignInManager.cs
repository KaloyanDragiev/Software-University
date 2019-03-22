using System.Linq;
using SimpleHttpServer.Models;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Security
{
    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            Login login = dbContext.Logins.FirstOrDefault(l => l.SessionId == session.Id);
            if (login == null)
            {
                return false;
            }
            if (login.isActive)
            {
                return true;
            }
            return false;
        }
    }
}