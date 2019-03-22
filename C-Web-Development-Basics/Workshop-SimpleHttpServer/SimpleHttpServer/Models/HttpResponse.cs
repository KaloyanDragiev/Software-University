namespace SimpleHttpServer.Models
{
    using System.Text;
    using Enums;

    public class HttpResponse
    {
        public HttpResponse(ResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[10];
        }

        public ResponseStatusCode StatusCode { get; set; }

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUTF8
        {
            set { Content = Encoding.UTF8.GetBytes(value); }
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            string statusCodeWithSpaces = StatusCode.ToString().Replace("_", " ");

            response.AppendLine($"HTTP/1.0 {(int) StatusCode} {statusCodeWithSpaces}");
            response.AppendLine(Header.ToString());

            return response.ToString();
        }
    }
}