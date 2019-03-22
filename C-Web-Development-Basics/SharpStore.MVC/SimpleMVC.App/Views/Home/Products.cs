namespace SimpleMVC.App.Views.Home
{
    using ViewModels;
    using Interfaces.Generic;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    public class Products : IRenderable<IEnumerable<KnifeViewModel>>
    {
        public IEnumerable<KnifeViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder replacement = new StringBuilder();
            int counter = 0;
            foreach (var knife in this.Model)
            {
                if (counter % 3 == 0)
                {
                    replacement.AppendLine("<div class=\"row\">");
                }
                replacement.AppendLine(knife.ToString());
                if (counter % 3 == 2)
                {
                    replacement.AppendLine("</div>");
                }
                counter++;
            }
            string originalHtml = File.ReadAllText("../../content/products.html");
            return string.Format(originalHtml, replacement);
        }
    }
}