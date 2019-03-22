namespace Shouter.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using Services;
    using Security;
    using SimpleHttpServer.Models;
    using Models.BindingModels;
    using System.Collections.Generic;

    public class FollowersController : Controller
    {
        private SignInManager signInManager;
        private FollowersService service;

        public FollowersController()
        {
            this.signInManager = new SignInManager();
            this.service = new FollowersService();
        }

        [HttpGet]
        public IActionResult<ProfileViewModel> Profile(int id)
        {
            var profileVm = service.GetProfile(id);
            return this.View(profileVm);
        }

        [HttpGet]
        public IActionResult<FollowingViewModel> All(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                return this.View(service.GetFollowing(session));
            }   
            Redirect(response, "/users/login");
            return null;
        }

        [HttpPost]
        public void All(HttpSession session, HttpResponse response, FollowingBindingModel fbm)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                service.FollowUnfollow(session, fbm);
                Redirect(response, "/followers/all");
                return;
            }
            Redirect(response, "/users/login");
        }

        [HttpGet]
        public IActionResult<FollowingViewModel> Find(HttpSession session, HttpResponse response, string username)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
               return this.View(service.GetFollowingFilter(session, username));
            }
            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult<IEnumerable<ShoutViewModel>> Feed(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                return this.View(service.GetFollowingShouts(session));
            }
            Redirect(response, "/users/login");
            return null;
        }
    }
}