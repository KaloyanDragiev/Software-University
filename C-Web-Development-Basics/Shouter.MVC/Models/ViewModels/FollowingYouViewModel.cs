namespace Models.ViewModels
{
    public class FollowingYouViewModel
    {
        public string Username { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"<li><h4><strong><a href=\"/followers/profile?id={this.Id}\">{this.Username}</a></strong></h4></li>";
        }
    }
}