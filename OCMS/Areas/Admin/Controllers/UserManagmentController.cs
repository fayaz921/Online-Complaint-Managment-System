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

        private readonly UserServices userServices = new UserServices();

        public ActionResult Userss(UserRequestType RequestType = UserRequestType.AllUsers)
        {
            try
            {
                ViewBag.TableName = RequestType.ToString();
                TempData["RequestType"] = RequestType;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult GetAllUsers(UserRequestType RequestType)
        {
            try
            {
                ViewBag.TableName = RequestType.ToString();
                return PartialView("_loadUserss", userServices.GetUsers(RequestType));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateUserStatuss(Guid UserId, UserStatus StatusCode)
        {
            try
            {
                var response = userServices.UpdateStatusService(UserId, StatusCode);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult RemoveUsers(Guid UserId)
        {
            try
            {
                var response = userServices.Removeservice(UserId);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
