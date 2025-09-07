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
using System.Web.Services.Description;
namespace OCMS.Areas.Users.Controllers
{

    [CustomModelValidator]
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        public ActionResult ForgetPassword()
        {
            return View();
        }

        //Forget Password , Generate OTP
        [HttpPost]
        public ActionResult ForgetPasswordUser(string email)
        {
            var user = userServices.GetUserByEmail(email);
            if (user == null)
            {
                return Json(new { success = false, message = "Email not found" },JsonRequestBehavior.AllowGet);
            }

            string otp = new Random().Next(100000, 999999).ToString();

            userServices.SaveOtp(user.UserId, otp);

            var emailService = new EmailOTPService();
            emailService.SendOtp(user.Email, otp);

            return Json(new { success = true, message = "OTP sent to your email" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        // Reset Password
        [HttpPost]
        public ActionResult ResetPasswordUser(string email, string otp, string newPassword)
        {
            var user = userServices.GetUserByEmail(email);
            if (user == null)
            {
                return Json(new { success = false, message = "Email not found" }, JsonRequestBehavior.AllowGet);
            }

            bool validOtp = userServices.VerifyOtp(user.UserId, otp);
            if (!validOtp)
            {
                return Json(new { success = false, message = "Invalid OTP" }, JsonRequestBehavior.AllowGet);
            }

            userServices.UpdatePassword(user.UserId, newPassword);

            return Json(new { success = true, message = "Password updated successfully" }, JsonRequestBehavior.AllowGet);
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