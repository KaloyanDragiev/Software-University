using System.Collections;

namespace PizzaMore.Utility
{
    using System.Collections.Generic;
    using Interfaces;

    public class CookieCollection : ICookieCollection
    {
        private Dictionary<string, Cookie> cookies;

        public CookieCollection()
        {
            this.cookies = new Dictionary<string, Cookie>();
        }

        public void AddCookie(Cookie cookie)
        {
            this.cookies.Add(cookie.Name, cookie);
        }

        public void RemoveCookie(string cookieName)
        {
            this.cookies.Remove(cookieName);
        }

        public bool ContainsKey(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public int Count => this.cookies.Count;

        public Cookie this[string key]
        {
            get { return this.cookies[key]; }
            set { this.cookies[key] = value; }
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            foreach (var kvp in cookies)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}