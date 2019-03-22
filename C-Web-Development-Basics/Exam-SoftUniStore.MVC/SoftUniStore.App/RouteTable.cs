namespace SoftUniStore.App
{
    using System.Collections.Generic;
    using System.IO;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;

    public class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                     new Route
                    {
                        Name = "jQuery JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/scripts/jquery-3.1.1.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/scripts/jquery-3.1.1.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                     new Route
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/js/bootstrap.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Bootstrap CSS Map",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/bootstrap.min.css.map$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/css/bootstrap.min.css.map")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/bootstrap.min.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/css/bootstrap.min.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "All Custom CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/(.+).css$",
                        Callable = (request) =>
                        {
                            int lastSlashIndex = request.Url.LastIndexOf('/') + 1;
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../content/css/{request.Url.Substring(lastSlashIndex)}")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "All JPEG Images",
                        Method = RequestMethod.GET,
                        UrlRegex = "/images/(.+)$",
                        Callable = (request) =>
                        {
                            int lastSlashIndex = request.Url.LastIndexOf('/') + 1;
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes($"../../content/images/{request.Url.Substring(lastSlashIndex)}")
                            };
                            response.Header.ContentType = "image/*";
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}