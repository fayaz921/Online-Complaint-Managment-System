using OCMS.Helper.Emailservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Helper
{
    public class EmailController : Controller
    {
        //// GET: Email
        //[HttpPost]
        //public ActionResult SendOtp(string email)
        //{
        //    var otp = new Random().Next(100000, 999999).ToString();
        //    Session["OTP"] = otp;
        //    Session["OTPEmail"] = email;

        //    var emailService = new EmailService();
        //    bool sent = emailService.SendOtp(email, otp);

        //    if (sent)
        //        return Json(new { success = true, message = "OTP sent successfully" });
        //    else
        //        return Json(new { success = false, message = "Error sending OTP" });
        //}

        //[HttpPost]
        //public ActionResult VerifyOtp(string otp)
        //{
        //    var sessionOtp = Session["OTP"]?.ToString();

        //    if (sessionOtp != null && sessionOtp == otp)
        //        return Json(new { success = true, message = "OTP verified!" });
        //    else
        //        return Json(new { success = false, message = "Invalid OTP" });
        //}


        private static string generatedOtp = "";

        // Load the page
        public ActionResult OtpTest()
        {
            return View();
        }

        // Send OTP
        [HttpPost]
        public JsonResult SendOtp(string email)
        {
            generatedOtp = new Random().Next(100000, 999999).ToString(); // 6-digit OTP

            var emailService = new EmailService(); // the class where you wrote SendOtp()
            bool result = emailService.SendOtp(email, generatedOtp);

            return Json(new { success = result });
        }

        // Verify OTP
        [HttpPost]
        public JsonResult VerifyOtp(string otp)
        {
            bool isValid = (otp == generatedOtp);
            return Json(new { success = isValid });
        }
    }
}
