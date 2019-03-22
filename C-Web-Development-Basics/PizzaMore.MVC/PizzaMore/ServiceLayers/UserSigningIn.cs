namespace PizzaMore.ServiceLayers
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using SimpleHttpServer.Models;

    public class UserSigningIn
    {
        public void TrySigningIn(UserBindingModel model, HttpSession session)
        {
            using (var context = new PizzaMoreContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    Session sessionEntity = new Session
                    {
                        isActive = true,
                        SessionId = session.Id,
                        UserId = user.Id
                    };

                    // Throws error because session is not actually changed
                    context.Sessions.Add(sessionEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}