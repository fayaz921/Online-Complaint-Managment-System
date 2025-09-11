using OCMS.Common.CustomClasses;
using OCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Admin.Controllers
{
    public class UserManagmentController : Controller
    {
        // GET: Admin/UserManagment
        // GET: Admin/UserManager
        private readonly UserServices userServices = new UserServices();

        public ActionResult Userss(UserRequestType RequestType = UserRequestType.AllUsers)
        {
            ViewBag.TableName = RequestType.ToString();
            TempData["RequestType"] = RequestType;
            return View();
        }
        [HttpGet]
        public ActionResult GetAllUsers(UserRequestType RequestType)
        {
            ViewBag.TableName = RequestType.ToString();
            return PartialView("_loadUserss", userServices.GetUsers(RequestType));
        }
        [HttpPost]
        public ActionResult UpdateUserStatuss(Guid UserId, UserStatus StatusCode)
        {
            var response = userServices.UpdateStatusService(UserId, StatusCode);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveUsers(Guid UserId)
        {
            var response = userServices.Removeservice(UserId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
