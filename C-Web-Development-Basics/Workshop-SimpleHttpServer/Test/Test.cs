namespace Test
{
    using System.Collections.Generic;
    using SimpleHttpServer;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    class Test
    {
        static void Main()
        {
            //var response = new HttpResponse(ResponseStatusCode.Page_Not_Found);
            //Console.WriteLine(response);
            //
            //var request = new HttpRequest(RequestMethod.POST, "/img/test.jpg");
            //request.Content = "Just random content";
            //Console.WriteLine(request);

            var routes = new List<Route>()
            {
                new Route
                {
                    Name = "Hello Handler",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>
                    {
                        return new HttpResponse(ResponseStatusCode.OK)
                        {
                            ContentAsUTF8 = "<h3>Hello from HttpServer :)</h3>",
                        };
                    }
                }
            };

            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }
    }
}