namespace PizzaMore.Security
{
    using SimpleHttpServer.Models;
    using Interfaces;
    using System;
    using SimpleHttpServer.Utilities;
    using System.Linq;

    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }
             return this.dbContext.Sessions.Any(s => s.SessionId == session.Id && s.isActive);
        }

        public void Logout(HttpSession session, HttpResponse response)
        {
            dbContext.Sessions.FirstOrDefault(s => s.SessionId == session.Id).isActive = false;
            this.dbContext.SaveChanges();

            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}