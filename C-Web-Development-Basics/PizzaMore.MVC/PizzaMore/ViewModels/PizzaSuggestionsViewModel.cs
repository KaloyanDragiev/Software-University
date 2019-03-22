namespace PizzaMore.ViewModels
{
    using System.Text;
    using System.Collections.Generic;
    using Models;

    public class PizzaSuggestionsViewModel
    {
        public string Email { get; set; }

        public ICollection<Pizza> PizzaSuggestions { get; set; }

        public override string ToString()
        {        
            StringBuilder sb = new StringBuilder();
            foreach (var suggestion in this.PizzaSuggestions)
            {
                sb.AppendLine("<form method=\"POST\">");
                sb.AppendLine($"<li><a href=\"/menu/details?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"Pizzaid\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                sb.AppendLine("</form>");
            }
            return sb.ToString();
        }
    }
}