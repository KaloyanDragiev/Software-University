namespace Shouter.Security
{
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using System.Linq;
    using Data.Data;

    class SignInManager
    {
        private ShouterContext Context;

        public SignInManager()
        {
            this.Context = Data.Context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }
            return this.Context.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);
        }

        public void Logout(HttpSession session, HttpResponse response)
        {
            Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).IsActive = false;
            this.Context.SaveChanges();

            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}