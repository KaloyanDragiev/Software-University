namespace PizzaForum.App.Controllers
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using Services;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using SimpleHttpServer.Models;
    using Security;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpSession session, HttpResponse response)
        {
            var topicVMs = service.GetAllTopics();
            if (SignInManager.IsAuthenticated(session.Id))
            {
                TopicViewModel.LoggedUserButton();
            }
            else
            {
                TopicViewModel.GuestUserButton();
            }
            return View(topicVMs);
        }

        [HttpGet]
        public IActionResult<IEnumerable<NormalUserCategoryViewModel>> Categories(HttpSession session,
            HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/forum/login");
                return null;
            }
            IEnumerable<NormalUserCategoryViewModel> categoryVMs = service.GetCategoryList();
            return this.View(categoryVMs);
        }
    }
}