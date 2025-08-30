using OCMS.Authentication;
using OCMS.Dtos;
using OCMS.Services;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMS.Common.CustomClasses;
using System.Net.NetworkInformation;
using System.Web.Security;
namespace OCMS.Areas.Users.Controllers
{
    public class AccountController : CookiesService
    {
        private readonly UserServices userServices = new UserServices();
        // GET: Users/Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCheck(UserLoginDto userLoginDto)
        {
            var response = userServices.LoginCheckService(userLoginDto, out Common.CustomClasses.OperationStatus operationStatus);

            if (response != null)
            {
                //if (!IsExistCookie(CookiesKey.UserId))     //cookies check if login info doesn't exist then save it 
                //{
                //    RemoveCookies(CookiesKey.UserId);        
                //    AppendCookies(CookiesKey.UserId,response.UserId.ToString(), DateTime.Now.AddDays(2));
                //    return Json(operationStatus, JsonRequestBehavior.AllowGet);
                //}

                //AppendCookies(CookiesKey.UserId, response.UserId.ToString(), DateTime.Now.AddDays(2));
                FormsAuthentication.SetAuthCookie(response.UserId.ToString(), true);
                return Json(operationStatus, JsonRequestBehavior.AllowGet);
            }
            return Json(operationStatus, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUser(AddUserDto dto)
        {
            //for image
            dto.ImageUrl = ImageUpload(dto.Imagefile);
            //Calling service
            var response = userServices.AddUser(dto);
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public string ImageUpload(HttpPostedFileBase File)
        {
            try
            {
                if (File != null)
                {
                    string filename = Path.GetFileName(File.FileName);
                    string ext = Path.GetExtension(filename);
                    filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ext;
                    string folderpath = Path.Combine("/uploads/", filename);
                    File.SaveAs(Server.MapPath(folderpath));
                    string domainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                    return domainName + "/uploads/" + filename;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}