using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Authentication
{
    public class UserBaseService : CookiesService
    {

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!IsExistCookie(CookiesKey.UserId))
            {
                filterContext.Result = new RedirectResult("/Users/Account/Login");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}