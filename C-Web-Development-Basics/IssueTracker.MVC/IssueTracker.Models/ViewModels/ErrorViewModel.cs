namespace IssueTracker.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return
                $"<div class=\"alert alert-danger alert - dismissable\"><a href=\"#\" class=\"close\"data-dismiss=\"alert\" aria-label=\"close\">&times;</a><strong>Error!</strong> \"{this.Message}\"</div>";
        }
    }
}