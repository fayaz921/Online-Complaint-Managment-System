using System;
using System.Web;
using System.Web.Mvc;


namespace OCMS.Authentication
{
    public class CookiesService : Controller
    {
        public void AppendCookies(string key, string value, DateTime ExpiryDate)
        {
            HttpCookie httpCookie = new HttpCookie(key, value);
            httpCookie.Expires = ExpiryDate;
            Response.Cookies.Add(httpCookie);
        }

        public string GetCookies(string key)
        {
            //return Request.Cookies.Get(key).Value;
            var cookie = Request.Cookies.Get(key);
            return cookie?.Value; // safe null handling
        }

        public void RemoveCookies(string key)
        {
            //Request.Cookies.Remove(key);
            if (Request.Cookies[key] != null)
            {
                var cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie); // overwrite to expire in browser
            }
        }

        public bool IsExistCookie(string key)
        {
            var data = Request.Cookies.Get(key);
            if (data != null)
            {
                return true;
            }
            return false;

            //return Request.Cookies.Get(key) != null;
        }
    }
}
