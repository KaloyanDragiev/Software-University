using System;

namespace PizzaMore.Utility
{
    using Interfaces;
    using System.Text;

    public class Header
    {
        public string Type { get; set; }

        public string Location { get; set; }

        public ICookieCollection Cookies { get; set; }

        public Header()
        {
            this.Type = "Content-type: text/html";
            this.Cookies = new CookieCollection();
        }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Type);
            if (Cookies.Count != 0)
            {
                foreach (var cookie in Cookies)
                {
                    sb.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }
            if (this.Location != null)
                sb.AppendLine(this.Location);
            sb.AppendLine();
            sb.AppendLine();
            return sb.ToString();
        }
    }
}