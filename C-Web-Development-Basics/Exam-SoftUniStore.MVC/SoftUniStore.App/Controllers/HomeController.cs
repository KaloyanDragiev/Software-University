namespace SoftUniStore.App.Controllers
{
    using System.Collections.Generic;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using Security;
    using Service;
    using SimpleMVC.Attributes.Methods;

    public class HomeController : Controller
    {
        private GamesService service;

        public HomeController()
        {
            this.service = new GamesService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomePageGameViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            IEnumerable<HomePageGameViewModel> gamesVMs = service.GetAllGames();
            return this.View(gamesVMs);
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomePageGameViewModel>> Owned(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            IEnumerable<HomePageGameViewModel> gamesVMs = service.GetGamesOwnedByUser(session);
            return this.View(gamesVMs);
        }
    }
}