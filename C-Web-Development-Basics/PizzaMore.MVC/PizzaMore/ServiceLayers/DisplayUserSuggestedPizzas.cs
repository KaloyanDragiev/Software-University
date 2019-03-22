namespace PizzaMore.ServiceLayers
{
    using Models;
    using SimpleHttpServer.Models;
    using System.Linq;
    using Data;
    using ViewModels;

    public class DisplayUserSuggestedPizzas
    {
        public PizzaSuggestionsViewModel GetPizzas(HttpSession session)
        {
            using (var context = new PizzaMoreContext())
            {
                User user = context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User;
                PizzaSuggestionsViewModel pizzaVM = new PizzaSuggestionsViewModel
                {
                    Email = user.Email,
                    PizzaSuggestions = user.PizzaSuggestions
                };
                return pizzaVM;
            }        
        }
    }
}