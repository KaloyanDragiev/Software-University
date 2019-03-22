namespace PizzaMore.ServiceLayers
{
    using Data;
    using Models;
    using SimpleHttpServer.Models;
    using System.Linq;

    public class VoteForPizza
    {
        public void Vote(int pizzaId, string voteType, HttpSession session)
        {
            using (var context = new PizzaMoreContext())
            {
                User user = context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User;

                Pizza votePizza = context.Pizzas.Find(pizzaId);
                if (voteType.ToLower() == "up")
                {
                    votePizza.UpVotes++;
                }
                else
                {
                    votePizza.DownVotes++;
                }

                user.PizzaVotedFor.Add(votePizza);
                context.SaveChanges();
            }
        }
    }
}