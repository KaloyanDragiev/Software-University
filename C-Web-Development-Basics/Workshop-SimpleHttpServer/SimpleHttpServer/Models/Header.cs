using System.Text;

namespace SimpleHttpServer.Models
{
    using System.Collections.Generic;
    using Enums;

    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLength { get; set; }

        public Dictionary<string, string> OtherParameters { get; set; }

        public CookieCollection Cookies { get; private set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine("Content-type: " + this.ContentType);

            if (this.Cookies.Count > 0)
            {
                if (Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies.ToString());
                }
                else if (Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie: " + cookie);
                    }
                }
            }

            if (this.ContentLength != null)
            {
                header.AppendLine("Content-Length: " + this.ContentLength);
            }
            foreach (var parameter in OtherParameters)
            {
                header.AppendLine($"{parameter.Key}: {parameter.Value}");
            }
            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}