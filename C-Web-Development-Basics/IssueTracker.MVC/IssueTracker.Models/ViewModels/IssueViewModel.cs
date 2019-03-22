namespace IssueTracker.Models.ViewModels
{
    public class IssueViewModel
    {
        public int IssueId { get; set; }

        public string IssueName { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string CreationDate { get; set; }

        public string AuthorName { get; set; }

        public bool IsChangeable { get; set; }

        public override string ToString()
        {
            string issueHtml = $"<tr><td>{this.IssueId}</td>" +
                               $"<td>{this.IssueName}</td>" +
                               $"<td>{this.Status}</td>" +
                               $"<td>{this.Priority}</td>" +
                               $"<td>{this.CreationDate}</td>" +
                               $"<td>{this.AuthorName}</td>";
            if (IsChangeable)
            {
                issueHtml += $"<td><a href=\"/issues/edit?id={this.IssueId}\" class=\"btn mini btn-primary\">Edit</a></td>" +
                             $"<td><a href=\"/issues/delete?id={this.IssueId}\" class=\"confirm-delete mini btn btn-danger\">Delete</a></td>";
            }
            issueHtml += "</tr>";
            return issueHtml;
        }
    }
}
