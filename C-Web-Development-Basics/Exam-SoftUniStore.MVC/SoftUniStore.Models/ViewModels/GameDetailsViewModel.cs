namespace SoftUniStore.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public string Title { get; set; }

        public string YouTubeId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string ReleaseDate { get; set; }

        public int GameId { get; set; }

        public override string ToString()
        {
            return $"<h1 class=\"display-3\">{this.Title}</h1><br/>" +
                   $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.YouTubeId}\" frameborder=\"0\" allowfullscreen></iframe><br/><br/>" +
                   $"<p>{this.Description}</p>" +
                   $"<p><strong>Price</strong> - {this.Price:f2}&euro;</p>" +
                   $"<p><strong>Size</strong> - {this.Size:f2} GB</p>" +
                   $"<p><strong>Release Date</strong> - {this.ReleaseDate}</p>" +
                   $"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"/home/all\">Back</a>" +
                   $"<form action=\"/games/details\" method=\"post\">" +
                   $"<input type=\"number\" value=\"{this.GameId}\" name=\"gameid\" hidden=\"hidden\" /><br/>" +
                   $"<input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />" +
                   $"</form>";
        }
    }
}