namespace IssueTracker.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using System;
    using System.Globalization;
    using Models.BindingModels;

    public class IssuesService : Service
    {
        public IEnumerable<IssueViewModel> GetAllIssues(HttpSession session)
        {
            User currentUser = GetCurrentUser(session.Id);
            var issuesVMs = new HashSet<IssueViewModel>();

            var issues = Context.Issues.GetAll().ToList();
            foreach (var issue in issues)
            {
                var issueVm  = new IssueViewModel
                {
                    AuthorName = issue.Author.Username,
                    IssueId = issue.Id,
                    IssueName = issue.Name,
                    Priority = issue.Priority.ToString("G"),
                    Status = issue.Status.ToString("G"),
                    CreationDate = GetDateString(issue.PublishDate),
                    IsChangeable = IsIssueChangeable(issue, currentUser)
                };
                issuesVMs.Add(issueVm);
            }
            return issuesVMs;
        }

        private User GetCurrentUser(string sessionId)
        {
            return Context.Sessions.FirstOrDefault(s => s.SessionId == sessionId).User;
        }

        private string GetDateString(DateTime? publishDate)
        {
            return publishDate.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
        }

        private bool IsIssueChangeable(Issue issue, User user)
        {
            return user.Role == Role.Administrator || user.Id == issue.AuthorId;
        }

        public void PostNewIssue(HttpSession session, NewIssueBindingModel nibm)
        {
            User user = GetCurrentUser(session.Id);

            Issue issue = new Issue
            {
                Author = user,
                Name = nibm.IssueName,
                PublishDate = DateTime.Now,
                Priority = (Priority) Enum.Parse(typeof(Priority), nibm.Priority),
                Status = (Status)Enum.Parse(typeof(Status), nibm.Status)
            };

            Context.Issues.Add(issue);
            Context.SaveChanges();
        }

        public void EditExistingIssue(EditExistingIssueBindingModel eeibm)
        {
            Issue issueToChange = Context.Issues.Find(eeibm.IssueId);

            issueToChange.Name = eeibm.NewIssueName;
            issueToChange.Priority = (Priority) Enum.Parse(typeof(Priority), eeibm.Priority);
            issueToChange.Status = (Status) Enum.Parse(typeof(Status), eeibm.Status);

            Context.SaveChanges();
        }
    }
}