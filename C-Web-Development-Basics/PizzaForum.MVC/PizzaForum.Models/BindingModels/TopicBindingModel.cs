namespace PizzaForum.Models.BindingModels
{
    public class TopicBindingModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}