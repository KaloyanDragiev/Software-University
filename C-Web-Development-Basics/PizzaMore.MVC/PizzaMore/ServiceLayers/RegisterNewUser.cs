namespace PizzaMore.ServiceLayers
{
    using BindingModels;
    using Data;
    using Models;

    public class RegisterNewUser
    {
        public void RegUser(UserBindingModel model)
        {
            using (var context = new PizzaMoreContext())
            {
                User user = new User
                {
                    Email = model.Email,
                    Password = model.Password
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}