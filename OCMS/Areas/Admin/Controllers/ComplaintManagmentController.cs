using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using OCMS.Services;
using OCMS.Services.ComplaintService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Admin.Controllers
{
    public class ComplaintManagmentController : Controller
    {
        private readonly ComplaintService complaintService = new ComplaintService();
        // GET: Admin/ComplaintManagment
        public ActionResult Complaints(ComplaintRequestType RequestType = ComplaintRequestType.AllComplaints)
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
        public ActionResult GetAllComplaints(ComplaintRequestType RequestType)
        {
            try
            {
                ViewBag.TableName = RequestType.ToString();
                return PartialView("_loadComplaints", complaintService.GetComplaintsByRequestType(RequestType));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult UpdateComplaintStatus(Guid complaintid, ComplaintStatus StatusCode)
        {
            try
            {
                var response = complaintService.UpdateComplaintStatus(complaintid, StatusCode);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult RemoveComplaint(Guid complaintid)
        {
            try
            {
                var response = complaintService.Removeservice(complaintid);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}