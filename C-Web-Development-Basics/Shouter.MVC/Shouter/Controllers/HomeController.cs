namespace Shouter.Controllers
{
    using Services;
    using Security;
    using SimpleMVC.Controllers;
    using SimpleMVC.Attributes.Methods;
    using SimpleHttpServer.Models;
    using Models.BindingModels;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private SignInManager signInManager;
        private HomeServices service;

        public HomeController()
        {
            this.signInManager = new SignInManager();
            this.service = new HomeServices();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ShoutViewModel>> Feed(HttpSession session)
        {
            return this.View(service.GetShouts(session));
        }

        [HttpGet]
        public IActionResult<IEnumerable<ShoutViewModel>> Feedsigned(HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/feed");
                return null;
            }
            return this.View(service.GetShouts(session));
        }


        [HttpPost]
        public void Feedsigned(ShoutBindingModel sbm, HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/feed");
            }
            service.PublishShout(sbm, session);
            Redirect(response, "/home/feedsigned");
        }
    }
}