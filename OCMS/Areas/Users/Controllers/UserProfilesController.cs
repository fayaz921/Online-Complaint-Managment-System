using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Users.Controllers
{
    public class UserProfilesController : Controller
    {
        // GET: Users/UserProfile
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}