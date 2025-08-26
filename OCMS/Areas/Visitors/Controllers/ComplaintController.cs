using OCMS.Authentication;
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
            if(!IsExistCookie(CookiesKey.UserId))
            {
                return RedirectToAction("Login","Account", new {area ="Users"});
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveComplaint(ComplaintDto complaintdto)
        {
            complaintservice.AddComplaintService(complaintdto);
            return Json(1,JsonRequestBehavior.AllowGet);
        }
    }
}