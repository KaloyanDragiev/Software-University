namespace PizzaForum.App.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using Security;
    using SimpleHttpServer.Models;
    using Services;
    using Data.Models;
    using Models.BindingModels;

    public class TopicsController : Controller
    {
        private TopicsService service;

        public TopicsController()
        {
            this.service = new TopicsService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<NewTopicViewModel>> New(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }
            return this.View(service.GetAllTopicCategories());
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, TopicBindingModel tbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/topics");
                return;
            }
            User currentUser = SignInManager.GetAuthenticatedUser(session.Id);
            if (service.CreateNewTopic(tbm, currentUser))
            {
                Redirect(response, "/home/topics");
                return;
            }
            Redirect(response, "/topics/new");
        }

        [HttpGet]
        public IActionResult<TopicDetailsViewModel> Details(HttpSession session, HttpResponse response, int id)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }
            return this.View(service.GetTopicDetails(id));
        }

        [HttpPost]
        public void Details(HttpSession session, HttpResponse response, ReplyBindingModel rbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/topics");
                return;
            }
            User currentUser = SignInManager.GetAuthenticatedUser(session.Id);
            service.AddReplyToTopic(rbm, currentUser);
            Redirect(response, $"/topics/details?id={rbm.TopicId}");
        }
    }
}