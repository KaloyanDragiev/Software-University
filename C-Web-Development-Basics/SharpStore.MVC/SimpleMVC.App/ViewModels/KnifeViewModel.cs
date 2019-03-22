namespace SimpleMVC.App.ViewModels
{
    public class KnifeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return "<div class=\"col-sm-4\">\r\n" +
                 "<div class=\"thumbnail\">\r\n" +
                 $"<img src=\"{this.ImageUrl}\" alt=\"Card image cap\" class=\"img-responsive\">\r\n" +
                 "<div class=\"caption\">\r\n" +
                 $"<h3>{this.Name}</h3>\r\n" +
                 $"<p>${this.Price:f2}</p>\r\n" +
                 $"<p><a href=\"/home/buy?id={this.Id}\" class=\"btn btn-primary\" role=\"button\">Buy Now</a></p>\r\n" +
                 "</div>\r\n" +
                 "</div>\r\n" +
                 "</div>";
        }
    }
}