namespace SimpleHttpServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;

    public class HttpProcessor
    {
        private IList<Route> Routes;
        private HttpRequest Request;
        private HttpResponse Response;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                Request = GetRequest(stream);
                Response = RouteRequest();
                StreamUtils.WriteResponse(stream, Response);
            }
        }

        private HttpResponse RouteRequest()
        {
            string requestUrl = Request.Url;
            if (!Routes.Any(r => new Regex(r.UrlRegex).IsMatch(requestUrl)))
            {
                return ResponseBuilder.NotFound();
            }
            var matchingRoutes = Routes.Where(r => new Regex(r.UrlRegex).IsMatch(requestUrl));
            if (matchingRoutes.All(r => r.Method != Request.Method))
            {
                return new HttpResponse(ResponseStatusCode.Method_Not_Allowed);
            }
            Route route =
                Routes.FirstOrDefault(r => new Regex(r.UrlRegex).IsMatch(requestUrl) && r.Method == Request.Method);
            try
            {
                HttpResponse response = route.Callable(Request);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ResponseBuilder.InternalServerError();
            }          
        }

        private HttpRequest GetRequest(NetworkStream inputStream)
        {
            string firstLine = StreamUtils.ReadLine(inputStream);
            string[] requestLineInfo = firstLine.Split(' ');
            if (requestLineInfo.Length < 3)
            {
                throw new ArgumentException();
            }

            RequestMethod method = RequestMethod.GET;
            if (requestLineInfo[0].ToLower() == "post")
            {
                method = RequestMethod.POST;
            }

            string url = requestLineInfo[1];

            Header header = new Header(HeaderType.HttpRequest);
            string line = null;
            while ((line = StreamUtils.ReadLine(inputStream)) != null)
            {
                if (String.IsNullOrEmpty(line))
                {
                    break;
                }
                string[] lineInfo = line.Split(':');
                string name = lineInfo[0];
                string value = lineInfo[1];
                if (name == "Cookie")
                {
                    header.Cookies[name] = new Cookie(name, value);
                }
                else if (name == "Content-Length")
                {
                    header.ContentLength = value;
                }
                else
                {
                    header.OtherParameters[name] = value;
                }
            }
            string content = null;
            if (header.ContentLength != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = inputStream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);
                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }
            var request = new HttpRequest(method, url)
            {
                Content = content,
                Header = header
            };
            return request;
        }
    }
}