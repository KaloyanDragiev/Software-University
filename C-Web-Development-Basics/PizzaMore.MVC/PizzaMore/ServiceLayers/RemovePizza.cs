namespace PizzaMore.ServiceLayers
{
    using Data;
    using Models;

    public class RemovePizza
    {
        public void Remove(int pizzaid)
        {
            using (var context = new PizzaMoreContext())
            {
                Pizza pizzaToRemove = context.Pizzas.Find(pizzaid);
                context.Pizzas.Remove(pizzaToRemove);
                context.SaveChanges();
            }
        }
    }
}