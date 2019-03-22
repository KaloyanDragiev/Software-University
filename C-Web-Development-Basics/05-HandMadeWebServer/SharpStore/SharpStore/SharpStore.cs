using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using SharpStore.Data;
using SharpStore.Data.Models;
using SimpleHttpServer;

namespace SharpStore
{
    class SharpStore
    {
        public static void Main()
        {
            SharpStoreContext context = new SharpStoreContext();

            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "About Us Page",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/about$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/about.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Products",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/products$",
                    Callable = (request) =>
                    {
                        var knives = context.Knives.ToList();
                        var productsFinal = GenerateKnives(knives);

                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = productsFinal
                        };
                    }
                },
                new Route()
                {
                    Name = "Products",
                    Method = SimpleHttpServer.Enums.RequestMethod.POST,
                    UrlRegex = "^/products$",
                    Callable = (request) =>
                    {
                        string searchFilter = request.Content.Split('=')[1];
                        var knives = context.Knives.Where(k => k.Name.Contains(searchFilter)).ToList();
                        var productsFinal = GenerateKnives(knives);

                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = productsFinal
                        };
                    }
                },
                new Route()
                {
                    Name = "Contacts",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/contacts$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/contacts.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Contacts",
                    Method = SimpleHttpServer.Enums.RequestMethod.POST,
                    UrlRegex = "^/contacts$",
                    Callable = (request) =>
                    {
                        UploadMessageToDB(request, context);

                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/contacts.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },

                new Route()
                {
                    Name = "Bootstrap CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
            };

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }

        private static string GenerateKnives(List<Knife> knives)
        {
            int counter = 0;
            string productsMiddle = "";
            foreach (var knife in knives)
            {
                if (counter % 3 == 0)
                {
                    productsMiddle += "<div class=\"row\">";
                }
                productsMiddle +=
                    $"<div class=\"img-thumbnail\" style=\"margin:10px; padding: 10px\">\r\n                    <img src=\"{knife.ImageUrl}\" alt=\"Card image cap\" width=\"300\" height=\"150\">\r\n                    <div class=\"card-block\">\r\n                        <h3 class=\"card-title\">{knife.Name}</h3>\r\n                        <p class=\"card-text\">${knife.Price}</p>\r\n                        <button class=\"btn btn-primary\" style=\"margin-bottom: 10px\" type=\"submit\">Buy Now</button>\r\n                    </div>\r\n                </div>";
                if (counter % 3 == 2)
                {
                    productsMiddle += "</div>";
                }
                counter++;
            }
            string productsFinal = File.ReadAllText("../../content/products-top.html");
            productsFinal += productsMiddle;
            productsFinal += File.ReadAllText("../../content/products-bottom.html");
            return productsFinal;
        }

        private static void UploadMessageToDB(HttpRequest request, SharpStoreContext context)
        {
            string requestContent = WebUtility.UrlDecode(request.Content);
            string[] parameters = requestContent.Split('&');
            Dictionary<string, string> nameValuePairs = new Dictionary<string, string>();
            foreach (var parameter in parameters)
            {
                string[] parameterInfo = parameter.Split('=');
                nameValuePairs.Add(parameterInfo[0], parameterInfo[1]);
            }
            Message message = new Message
            {
                Sender = nameValuePairs["emailAddress"],
                Subject = nameValuePairs["subject"],
                FullMessage = nameValuePairs["message"]
            };
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}