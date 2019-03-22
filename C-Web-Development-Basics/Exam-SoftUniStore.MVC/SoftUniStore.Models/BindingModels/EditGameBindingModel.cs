namespace SoftUniStore.Models.BindingModels
{
    public class EditGameBindingModel
    {
        public int GameId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string YouTubeId { get; set; }
    }
}