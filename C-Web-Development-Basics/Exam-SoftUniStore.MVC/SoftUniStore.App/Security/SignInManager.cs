namespace SoftUniStore.App.Security
{
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using Utilities;
    using Data.Models;
    using Data;

    public static class SignInManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            Helpers.Username = Data.Context.Sessions.FirstOrDefault(s => s.SessionId == sessionId)?.User.FullName;
            return Data.Context.Sessions.Any(s => s.SessionId == sessionId && s.IsActive);
        }

        public static void Logout(HttpSession session, HttpResponse response)
        {
            Data.Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).IsActive = false;
            Helpers.Username = "";
            Data.Context.SaveChanges();

            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            return Data.Context.Sessions.FirstOrDefault(s => s.SessionId == sessionId && s.IsActive)?.User;
        }
    }
}