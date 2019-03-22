namespace Helpers
{
    using System.IO;

    public static class HTMLReader
    {
        public static string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}