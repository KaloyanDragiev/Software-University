namespace SoftUniStore.Utilities
{
    using System.IO;

    public static class Helpers
    {
        public static string Username = "";

        public static string Footer = File.ReadAllText("../../content/footer.html");
        public static string Header = File.ReadAllText("../../content/header.html");
        public static string Login = File.ReadAllText("../../content/login.html");
        public static string NavLogged = File.ReadAllText("../../content/nav-logged.html");
        public static string NavNotLogged = File.ReadAllText("../../content/nav-not-logged.html");
        public static string Register = File.ReadAllText("../../content/register.html");
        public static string AddGame = File.ReadAllText("../../content/add-game.html");
        public static string AdminGames = File.ReadAllText("../../content/admin-games.html");
        public static string DeleteGame = File.ReadAllText("../../content/delete-game.html");
        public static string Edit = File.ReadAllText("../../content/edit-game.html");
        public static string GameDetails = File.ReadAllText("../../content/game-details.html");
        public static string Home = File.ReadAllText("../../content/home.html");
    }
}