namespace Home
{
    using System.Collections.Generic;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;
    using PizzaMore.Data;

    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;

        static void Main()
        {
            AddDefaultLanguageCookie();
            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Cookie newCookie = new Cookie("lang", RequestParameters["language"]);
                Header.AddCookie(newCookie);
                Language = RequestParameters["language"];
            }
            ShowPage();
        }

        private static void TryLogOut()
        {
            if (RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    using (var context = new PizzaMoreContext())
                    {
                        var ses = context.Sessions.Find(Session.Id);
                        context.Sessions.Remove(ses);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            if (Language == "BG")
                ServeHtmlBg();
            else
                ServeHtmlEn();
        }

        private static void ServeHtmlBg()
        {
            WebUtil.PrintFileContent(Constants.HomePageBG);
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent(Constants.HomePageEN);
        }

        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
            }
        }
    }
}