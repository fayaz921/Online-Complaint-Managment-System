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
    [Authorize]
    public class ComplaintController : Controller
    {
        // GET: Visitors/Complaint
        private readonly ComplaintService complaintservice = new ComplaintService();
        private readonly UserServices userServices = new UserServices();
        public ActionResult Complaint()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SaveComplaint(AddComplaintDto complaintdto)
        {

            if(!ModelState.IsValid)
            {
                //collect all models error
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );
                return Json(new {success = false,errors}, JsonRequestBehavior.AllowGet);
            }



            var userid = User.Identity.Name;
            var user = userServices.GetbyIDService(Guid.Parse(userid));
            if (user.Status == UserStatus.Pending || user.Status == UserStatus.Suspended || user.Status == UserStatus.Rejected)
            {
                return Json(new { requestUrl = Url.Action("StatusView", "Status", new { area = "Visitors" }) });
            }

            complaintdto.ImageUrl = complaintdto.ImageFile != null ? ImageUpload(complaintdto.ImageFile) : null;
            complaintdto.UserId = Guid.Parse(userid);

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