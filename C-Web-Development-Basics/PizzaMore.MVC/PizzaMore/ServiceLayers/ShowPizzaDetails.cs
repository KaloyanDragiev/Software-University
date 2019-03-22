namespace PizzaMore.ServiceLayers
{
    using Data;
    using Models;
    using ViewModels;

    public class ShowPizzaDetails
    {
        public PizzaDetailsViewModel Show(int id)
        {
            using (var context = new PizzaMoreContext())
            {
                Pizza pizza = context.Pizzas.Find(id);
                PizzaDetailsViewModel pizzaDetailsVM = new PizzaDetailsViewModel
                {
                    DownVote = pizza.DownVotes,
                    UpVote = pizza.UpVotes,
                    ImageUrl = pizza.ImageUrl,
                    Recipe = pizza.Recipe,
                    Title = pizza.Title
                };
                return pizzaDetailsVM;
            }
        }
    }
}