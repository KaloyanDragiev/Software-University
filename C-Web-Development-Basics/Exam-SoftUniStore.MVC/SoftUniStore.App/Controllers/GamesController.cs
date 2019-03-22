namespace SoftUniStore.App.Controllers
{
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using Security;
    using Models.ViewModels;
    using Service;
    using System.Collections.Generic;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Interfaces;
    using Models.BindingModels;

    public class GamesController : Controller
    {
        private GamesService service;

        public GamesController()
        {
            this.service = new GamesService();
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(int id, HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return null;
            }
            var gameToDisplay = service.GetGameDetails(id);
            return this.View(gameToDisplay);
        }

        [HttpPost]
        public void Details(HttpSession session, HttpResponse response, GamePurchaseBindingModel gpbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/users/login");
                return;
            }
            this.service.TryPurchaseGame(gpbm, session);
            Redirect(response, "/home/owned");
        }

        [HttpGet]
        public IActionResult<IEnumerable<ManagingGamesViewModel>> Manage(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return null;
            }
            var manageGameVMs = service.GetAdminGames();
            return this.View(manageGameVMs);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Add(HttpSession session, HttpResponse response, AddNewGameBindingModel angbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return;
            }
            if (service.TryAddingNewGame(angbm))
            {
                Redirect(response, "/home/all");
                return;
            }
            Redirect(response, "/games/add");
        }

        [HttpGet]
        public IActionResult<EditGameViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return null;
            }
            EditGameViewModel egvm = service.GetEditGameInfo(id);
            return this.View(egvm);
        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, EditGameBindingModel egbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return;
            }
            if (service.TryEditingGame(egbm))
            {
                Redirect(response, "/home/all");
                return;
            }
            Redirect(response, "/games/manage");
        }

        [HttpGet]
        public IActionResult<DeleteGameViewModel> Delete(HttpSession session, HttpResponse response, int id)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return null;
            }
            DeleteGameViewModel egvm = service.GetDeleteGameInfo(id);
            return this.View(egvm);
        }

        [HttpPost]
        public void Delete(HttpSession session, HttpResponse response, DeleteGameBindingModel dgbm)
        {
            if (!SignInManager.IsAuthenticated(session.Id) || !SignInManager.GetAuthenticatedUser(session.Id).IsAdmin)
            {
                Redirect(response, "/home/all");
                return;
            }
            if (service.TryDeletingGame(dgbm))
            {
                Redirect(response, "/home/all");
                return;
            }
            Redirect(response, "/games/manage");
        }
    }
}