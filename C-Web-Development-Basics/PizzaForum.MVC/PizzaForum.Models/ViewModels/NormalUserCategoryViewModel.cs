namespace PizzaForum.Models.ViewModels
{
    public class NormalUserCategoryViewModel
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"<li><a href=\"/categories/topics?CategoryName={this.Name}\">{this.Name}</a></li>";
        }
    }
}