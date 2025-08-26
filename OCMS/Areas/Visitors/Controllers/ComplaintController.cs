using OCMS.Authentication;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Services;
using OCMS.Services.ComplaintService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    public class ComplaintController : CookiesService
    {
        // GET: Visitors/Complaint
        private readonly ComplaintService complaintservice = new ComplaintService();
        public ActionResult Complaint()
        {
            if (!IsExistCookie(CookiesKey.UserId))
            {
                return RedirectToAction("Login", "Account", new { area = "Users" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveComplaint(AddComplaintDto complaintdto)
        {
            //if (!IsExistCookie(CookiesKey.Status))
            //{
            //    return RedirectToAction("StatusView","Status",new {area="Visitors"});
            //}
            //complaintservice.AddComplaintService(complaintdto);
            // AppendCookies(CookiesKey.Status, ComplaintStatus.Pending.ToString(), DateTime.Now.AddDays(1));
            //return Json(1,JsonRequestBehavior.AllowGet);

            if (!IsExistCookie(CookiesKey.Status))
            {
                //return Json(new { redirectUrl = Url.Action("StatusView", "Status", new { area = "Visitors" }) });
            }

            complaintservice.AddComplaintService(complaintdto);

            AppendCookies(CookiesKey.Status, ComplaintStatus.Pending.ToString(), DateTime.Now.AddDays(1));

            return Json(new { redirectUrl = Url.Action("StatusView", "Status", new { area = "Visitors" }) });


        }
    }
}