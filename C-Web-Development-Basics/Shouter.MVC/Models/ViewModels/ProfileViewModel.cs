namespace Models.ViewModels
{
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            this.UserShouts = new HashSet<ShoutViewModel>();
        }

        public string Username { get; set; }

        public int ProfileId { get; set; }

        public HashSet<ShoutViewModel> UserShouts { get; set; }
    }
}