namespace IssueTracker.Models.BindingModels
{
    public class EditExistingIssueBindingModel
    {
        public string NewIssueName { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int IssueId { get; set; }
    }
}