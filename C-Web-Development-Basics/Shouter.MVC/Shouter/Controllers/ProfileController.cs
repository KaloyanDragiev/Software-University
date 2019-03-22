namespace Shouter.Controllers
{
    using Services;
    using Security;
    using SimpleMVC.Controllers;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using Models.BindingModels;

    public class ProfileController : Controller
    {
        private SignInManager signInManager;
        private ProfileService service;

        public ProfileController()
        {
            this.signInManager = new SignInManager();
            this.service = new ProfileService();
        }

        [HttpGet]
        public IActionResult<ProfileViewModel> Myfeed(HttpSession session, HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return this.View(service.DisplayProfileShouts(session));
            }
            Redirect(response, "/users/login");
            return null;
        }

        [HttpPost]
        public void Myfeed(HttpSession session, HttpResponse response, ShoutDeleteBindingModel sdbm)
        {
            if (signInManager.IsAuthenticated(session))
            {
                service.DeleteShout(sdbm.ShoutId);
                Redirect(response, "/profile/myfeed");
                return;
            }
            Redirect(response, "/users/login");
        }

        [HttpGet]
        public IActionResult<IEnumerable<FollowingYouViewModel>> Following(HttpSession session, HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return this.View(service.WhoIsFollowingYou(session));
            }
            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult<IEnumerable<NotificationViewModel>> Notifications(HttpSession session,
            HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return this.View(service.GetNotifications(session));
            }
            Redirect(response, "/users/login");
            return null;
        }
    }
}