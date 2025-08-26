using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitors/Visitor
        public ActionResult Index()
        {
            return View();
        }
    }
}