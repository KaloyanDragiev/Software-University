namespace PizzaForum.Models.ViewModels
{
    public class NewTopicViewModel
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"<option value=\"{this.Id}\">{this.Name}</option>";
        }
    }
}