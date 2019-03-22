namespace SoftUniStore.Models.ViewModels
{
    public class ManagingGamesViewModel
    {
        public int GameId { get; set; }

        public string Name { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return "<tr>" +
                   $"<td>{this.Name}</td>" +
                   $"<td>{this.Size:f2} GB</td>" +
                   $"<td>{this.Price:f2} &euro;</td>" +
                   $"<td><a href=\"/games/edit?id={this.GameId}\" class=\"btn btn-warning btn-sm\">Edit</a>" +
                   $"<a href=\"/games/delete?id={this.GameId}\" class=\"btn btn-danger btn-sm\">Delete</a></td>" +
                   "</tr>";
        }
    }
}