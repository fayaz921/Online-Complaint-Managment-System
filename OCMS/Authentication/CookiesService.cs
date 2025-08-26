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
            return Request.Cookies.Get(key).Value;
        }

        public void RemoveCookies(string key)
        {
            Request.Cookies.Remove(key);
        }

        public bool IsExistCookie(string key)
        {
            var data = Request.Cookies.Get(key);
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}