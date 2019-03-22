using System.Net.Http;

namespace IssueTracker.App.Controllers
{
    using System.Collections.Generic;
    using Security;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using Service;
    using Models.BindingModels;
    using SimpleMVC.Interfaces;

    public class IssuesController : Controller
    {
        private IssuesService service;

        public IssuesController()
        {
            this.service = new IssuesService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<IssueViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            return this.View(service.GetAllIssues(session));
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, NewIssueBindingModel nibm)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return;
            }
            service.PostNewIssue(session, nibm);
            Redirect(response, "/issues/all");
        }

        [HttpGet]
        public IActionResult<EditIssueViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            var issueToEditId = new EditIssueViewModel { IssueId = id };
            return this.View(issueToEditId);
        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, EditExistingIssueBindingModel eeibm)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return;
            }
            service.EditExistingIssue(eeibm);
            Redirect(response, "/issues/all");
        }
    }
}