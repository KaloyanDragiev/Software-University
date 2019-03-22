namespace SoftUniStore.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using Data.Models;
    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using Models.BindingModels;

    public class GamesService : BaseService
    {
        public IEnumerable<HomePageGameViewModel> GetAllGames()
        {
            var allGameEntities = Context.Games.GetAll().ToList();

            return HomePageGameViewModels(allGameEntities);
        }

        public IEnumerable<HomePageGameViewModel> GetGamesOwnedByUser(HttpSession session)
        {
            var currentUser = Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User;
            var currentUserGames = currentUser.Games.ToList();

            return HomePageGameViewModels(currentUserGames);
        }

        private static IEnumerable<HomePageGameViewModel> HomePageGameViewModels(List<Game> allGameEntities)
        {
            var allGamesVMs = new HashSet<HomePageGameViewModel>();
            foreach (var game in allGameEntities)
            {
                HomePageGameViewModel gameVm = new HomePageGameViewModel
                {
                    GameId = game.Id,
                    ImageThumbnail = game.ImageThumbnail,
                    Price = game.Price,
                    Size = game.Size,
                    Title = game.Title,
                    Description = game.Description.Substring(0, Math.Min(300, game.Description.Length))
                };
                allGamesVMs.Add(gameVm);
            }
            return allGamesVMs;
        }

        public GameDetailsViewModel GetGameDetails(int id)
        {
            Game selectedGame = Context.Games.Find(id);
            GameDetailsViewModel gdvm = new GameDetailsViewModel
            {
                Description = selectedGame.Description,
                GameId = selectedGame.Id,
                Price = selectedGame.Price,
                ReleaseDate = selectedGame.ReleaseDate.ToString(),
                Size = selectedGame.Size,
                Title = selectedGame.Title,
                YouTubeId = selectedGame.Trailer
            };
            return gdvm;
        }

        public void TryPurchaseGame(GamePurchaseBindingModel gpbm, HttpSession session)
        {
            var currentUser = Context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User;
            Game gameToBuy = Context.Games.Find(gpbm.GameId);
            if (currentUser.Games.Any(g => g.Id == gpbm.GameId))
            {
                return;
            }
            currentUser.Games.Add(gameToBuy);
            Context.SaveChanges();
        }

        public IEnumerable<ManagingGamesViewModel> GetAdminGames()
        {
            var allGames = Context.Games.GetAll().ToList();
            var gamesVMs = new HashSet<ManagingGamesViewModel>();

            foreach (var game in allGames)
            {
                var gameVm = new ManagingGamesViewModel
                {
                    GameId = game.Id,
                    Name = game.Title,
                    Price = game.Price,
                    Size = game.Size
                };
                gamesVMs.Add(gameVm);
            }

            return gamesVMs;
        }

        public bool TryAddingNewGame(AddNewGameBindingModel angbm)
        {
            if (!IsGameValid(angbm))
            {
                return false;
            }
            Game game = new Game
            {
                Description = angbm.Description,
                ImageThumbnail = WebUtility.UrlDecode(angbm.Thumbnail),
                Price = angbm.Price,
                ReleaseDate = DateTime.Parse(angbm.ReleaseDate),
                Size = angbm.Size,
                Trailer = angbm.YouTubeId,
                Title = angbm.Name
            };
            Context.Games.Add(game);
            Context.SaveChanges();
            return true;
        }

        private bool IsGameValid(AddNewGameBindingModel angbm)
        {
            if (!char.IsUpper(angbm.Name[0]) || angbm.Name.Length < 3 || angbm.Name.Length > 100)
            {
                return false;
            }
            if (angbm.Price <= 0)
            {
                return false;
            }
            if (angbm.Size <= 0)
            {
                return false;
            }
            if (angbm.YouTubeId.Length != 11)
            {
                return false;
            }
            Regex thumbnailRegex = new Regex("^(http|https)://");
            if (!thumbnailRegex.IsMatch(angbm.Thumbnail))
            {
                return false;
            }

            if (angbm.Description.Length < 20)
            {
                return false;
            }
            return true;
        }

        public EditGameViewModel GetEditGameInfo(int id)
        {
            Game gameToEdit = Context.Games.Find(id);
            EditGameViewModel egvm = new EditGameViewModel
            {
                Description = gameToEdit.Description,
                GameId = gameToEdit.Id,
                Price = gameToEdit.Price,
                Size = gameToEdit.Size,
                Thumbnail = gameToEdit.ImageThumbnail,
                Title = gameToEdit.Title,
                YouTubeId = gameToEdit.Trailer
            };
            return egvm;
        }

        public bool TryEditingGame(EditGameBindingModel egbm)
        {
            AddNewGameBindingModel angbm = new AddNewGameBindingModel
            {
                Description = egbm.Description,
                Name = egbm.Name,
                Price = egbm.Price,
                Size = egbm.Size,
                Thumbnail = egbm.Thumbnail,
                YouTubeId = egbm.YouTubeId,
            };
            if (!IsGameValid(angbm))
            {
                return false;
            }
            Game gameToEdit = Context.Games.Find(egbm.GameId);
            gameToEdit.Size = egbm.Size;
            gameToEdit.Description = egbm.Description;
            gameToEdit.ImageThumbnail = egbm.Thumbnail;
            gameToEdit.Price = egbm.Price;
            gameToEdit.Title = egbm.Name;
            gameToEdit.Trailer = egbm.YouTubeId;
            Context.SaveChanges();
            return true;
        }

        public DeleteGameViewModel GetDeleteGameInfo(int id)
        {
            Game gameToDelete = Context.Games.Find(id);
            DeleteGameViewModel dgvm = new DeleteGameViewModel
            {
                GameId = gameToDelete.Id,
                Title = gameToDelete.Title
            };
            return dgvm;
        }

        public bool TryDeletingGame(DeleteGameBindingModel dgbm)
        {
            Game gameToDelete = Context.Games.Find(dgbm.GameId);
            try
            {
                Context.Games.Remove(gameToDelete);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}