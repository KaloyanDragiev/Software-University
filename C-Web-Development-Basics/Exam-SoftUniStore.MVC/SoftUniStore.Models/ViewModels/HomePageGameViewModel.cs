namespace SoftUniStore.Models.ViewModels
{
    public class HomePageGameViewModel
    {
        public string ImageThumbnail { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string Description { get; set; }

        public int GameId { get; set; }

        public override string ToString()
        {
            return $"<div class=\"card col-4 thumbnail\">" +
                   $"<img class=\"card-image-top img-fluid img-thumbnail\" src=\"{this.ImageThumbnail}\">" +
                   $"<div class=\"card-block\">" +
                   $"<h4 class=\"card-title\">{this.Title}</h4>" +
                   $"<p class=\"card-text\"><strong>Price</strong> - {this.Price:f2}&euro;</p>" +
                   $"<p class=\"card-text\"><strong>Size</strong> - {this.Size:f2} GB</p>" +
                   $"<p class=\"card-text\">{this.Description}</p>" +
                   $"</div>" +
                   $"<div class=\"card-footer\">" +
                   $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/games/details?id={this.GameId}\">Info</a>" +
                   $"</div></div>";
        }
    }
}