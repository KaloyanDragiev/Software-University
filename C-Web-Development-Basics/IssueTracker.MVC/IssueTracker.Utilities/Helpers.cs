namespace IssueTracker.Utilities
{
    using System.IO;

    public static class Helpers
    {
        public static string Username = "";

        public static string Alert = File.ReadAllText("../../content/alert.html");
        public static string Footer = File.ReadAllText("../../content/footer.html");
        public static string Header = File.ReadAllText("../../content/header.html");
        public static string Home = File.ReadAllText("../../content/home.html");
        public static string IssueEdit = File.ReadAllText("../../content/issue-edit.html");
        public static string IssueNew = File.ReadAllText("../../content/issue-new.html");
        public static string Issues = File.ReadAllText("../../content/issues.html");
        public static string Login = File.ReadAllText("../../content/login.html");
        public static string MenuLogged = File.ReadAllText("../../content/menu-logged.html");
        public static string MenuNotLogged = File.ReadAllText("../../content/menu.html");
        public static string Register = File.ReadAllText("../../content/register.html");
    }
}