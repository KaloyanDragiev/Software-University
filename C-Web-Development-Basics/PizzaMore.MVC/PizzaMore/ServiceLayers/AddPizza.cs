namespace PizzaMore.ServiceLayers
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using SimpleHttpServer.Models;
    using AutoMapper;

    public class AddPizza
    {
        public void Add(HttpSession session, PizzaBindingModel model)
        {
            using (var context = new PizzaMoreContext())
            {
                User user = context.Sessions.FirstOrDefault(u => u.SessionId == session.Id).User;

                user.PizzaSuggestions.Add(new Pizza
                {
                    ImageUrl = model.Url,
                    Title = model.Title,
                    Recipe = model.Recipe
                });

                //ConfigureMapper(session, context);
                //Pizza pizzaEntity = Mapper.Map<Pizza>(model);
                //user.PizzaSuggestions.Add(pizzaEntity);

                context.SaveChanges();
            }
        }

        public void ConfigureMapper(HttpSession session, PizzaMoreContext context)
        {
            Mapper.Initialize(expression => expression.CreateMap<PizzaBindingModel, Pizza>()
            .ForMember(p => p.Owner, config => config
            .MapFrom(u => context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User)));
        }
    }
}