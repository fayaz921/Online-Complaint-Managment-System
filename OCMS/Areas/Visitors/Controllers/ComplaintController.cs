using OCMS.Authentication;
using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Services;
using OCMS.Services.ComplaintService;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (!IsExistCookie(CookiesKey.Status))
            {
                return Json(new { requestUrl = Url.Action("Login", "Account", new { area = "Users" }) });
            }

            var status = GetCookies(CookiesKey.Status);
            if(status == UserStatus.Pending.ToString() 
                || status == UserStatus.Suspended.ToString() 
                || status == UserStatus.Rejected.ToString() )
            {
                return Json(new { requestUrl = Url.Action("StatusView", "Status", new { area = "Visitors" }) });
            }
               
               
            complaintdto.ImageUrl = complaintdto.ImageFile != null ? ImageUpload(complaintdto.ImageFile) : null;
            complaintdto.UserId =Guid.Parse(GetCookies(CookiesKey.UserId));
            
            var response = complaintservice.AddComplaintService(complaintdto);
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