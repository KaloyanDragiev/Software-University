namespace PizzaMore.ServiceLayers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using ViewModels;
    using SimpleHttpServer.Models;

    public class DisplayAllPizzas
    {
        public IEnumerable<PizzaViewModel> GetPizzas(HttpSession session, string sortingMethod)
        {
            var pizzasVMs = new List<PizzaViewModel>();

            using (var context = new PizzaMoreContext())
            {
                var pizzas = context.Pizzas.ToList();
                var sortedPizzas = this.GetSortedPizzas(pizzas, sortingMethod);
                foreach (var pizza in sortedPizzas)
                {
                    PizzaViewModel pizzaVM = new PizzaViewModel
                    {
                        Id = pizza.Id,
                        ImageUrl = pizza.ImageUrl,
                        Title = pizza.Title,
                        Owner = context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User,
                        UpVotes = pizza.UpVotes,
                        DownVotes = pizza.DownVotes,
                        VotedUsers = pizza.UsersVoted
                    };
                    pizzasVMs.Add(pizzaVM);
                }
            }
            return pizzasVMs;
        }

        public IEnumerable<Pizza> GetSortedPizzas(List<Pizza> pizzas, string sortingCriteria)
        {
            switch (sortingCriteria)
            {
                case "defaultSort":
                    return pizzas.OrderByDescending(p => p.UpVotes).ThenBy(p => p.DownVotes).AsEnumerable();
                case "names_upvotes":
                    return pizzas.OrderBy(p => p.Title).ThenBy(p => p.UpVotes).AsEnumerable();
                case "names_downvotes":
                    return pizzas.OrderBy(p => p.Title).ThenBy(p => p.DownVotes).AsEnumerable();
                case "upvotes_names":
                    return pizzas.OrderBy(p => p.UpVotes).ThenBy(p => p.Title).AsEnumerable();
                case "upvotes_downvotes":
                    return pizzas.OrderBy(p => p.UpVotes).ThenBy(p => p.DownVotes).AsEnumerable();
                case "downvotes_names":
                    return pizzas.OrderBy(p => p.DownVotes).ThenBy(p => p.Title).AsEnumerable();
                case "downvotes_upvotes":
                    return pizzas.OrderBy(p => p.DownVotes).ThenBy(p => p.UpVotes).AsEnumerable();
                case "names_names":
                    return pizzas.OrderBy(p => p.Title).AsEnumerable();
                case "downvotes_downvotes":
                    return pizzas.OrderBy(p => p.DownVotes).AsEnumerable();
                case "upvotes_upvotes":
                    return pizzas.OrderBy(p => p.UpVotes).AsEnumerable();
                default:
                    return pizzas;
            }
        }
    }
}