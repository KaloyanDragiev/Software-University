namespace PizzaForum.Helpers
{
    using System.IO;

    public static class HtmlReader
    {
        public static string Read(string html)
        {
            return File.ReadAllText(html);
        }
    }
}