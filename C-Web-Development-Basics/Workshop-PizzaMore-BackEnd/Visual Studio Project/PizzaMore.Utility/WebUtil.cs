namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Data;
    using Data.Models;
    using Interfaces;

    public static class WebUtil
    {
        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod.ToLower() == "post";
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod.ToLower() == "get";
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parameters = Environment.GetEnvironmentVariable("QUERY_STRING");
            return RetrieveRequestParameters(parameters);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parameters = Console.ReadLine();
            return RetrieveRequestParameters(parameters);
        }

        public static IDictionary<string, string> RetrieveRequestParameters(string parameters)
        {
            Dictionary<string, string> nameValues = new Dictionary<string, string>();
            string decodedParams = WebUtility.UrlDecode(parameters);
            if (decodedParams != null)
            {
                string[] paramsInfo = decodedParams.Split('&');
                foreach (var param in paramsInfo)
                {
                    string[] nameValueInfo = param.Split('=');
                    string name = nameValueInfo[0];
                    string value = nameValueInfo[1];
                    nameValues.Add(name, value);
                }
            }  
            return nameValues;
        }

        public static ICookieCollection GetCookies()
        {
            ICookieCollection cookies = new CookieCollection();
            string cookieHeader = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (cookieHeader != null)
            {
                string[] cookiesInfo = cookieHeader.Split(';');
                foreach (var c in cookiesInfo)
                {
                    string[] cookieInfo = c.Split('=');
                    string cookieName = cookieInfo[0];
                    string cookieValue = cookieInfo[1];
                    Cookie cookie = new Cookie(cookieName, cookieValue);
                    cookies.AddCookie(cookie);
                }
                return cookies;
            }
            return new CookieCollection();
        }

        public static Session GetSession()
        {
            ICookieCollection cookies = GetCookies();
            if (cookies.ContainsKey("sid"))
            {
                Cookie desiredCookie = cookies["sid"];
                PizzaMoreContext context = new PizzaMoreContext();
                int desiredSessionId = int.Parse(desiredCookie.Value);
                return context.Sessions.FirstOrDefault(s => s.Id == desiredSessionId);
            }
            return null;
        }

        public static void PrintFileContent(string path)
        {
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.Game);
        }
    }
}