namespace Models.ViewModels
{
    using System.Collections.Generic;

    public class FollowingViewModel
    {
        public FollowingViewModel()
        {
            this.Followings = new HashSet<string>();
        }

        public string Username { get; set; }

        public HashSet<string> Followings { get; set; }
    }
}