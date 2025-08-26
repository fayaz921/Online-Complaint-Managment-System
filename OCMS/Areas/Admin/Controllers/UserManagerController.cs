using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using OCMS.Services;
using System;
using System.Web.Mvc;

namespace OCMS.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        // GET: Admin/UserManager
        private readonly UserServices userServices = new UserServices();

        public ActionResult Users(UserRequestType RequestType = UserRequestType.AllUsers)
        {
            ViewBag.TableName = RequestType.ToString();
            TempData["RequestType"] = RequestType;
            return View();
        }
        [HttpGet]
        public ActionResult GetAllUser(UserRequestType RequestType)
        {
            ViewBag.TableName = RequestType.ToString();
            return PartialView("_loadUsers", userServices.GetUsers(RequestType));
        }
        [HttpPost]
        public ActionResult UpdateUserStatus(Guid UserId, UserStatus StatusCode)
        {
            var response = userServices.UpdateStatusService(UserId, StatusCode);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveUser(Guid UserId)
        {
          var response =  userServices.Removeservice(UserId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}