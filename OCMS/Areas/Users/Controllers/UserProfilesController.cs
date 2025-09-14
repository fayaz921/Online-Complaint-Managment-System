using OCMS.Dtos;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Services;
using OCMS.Services.ComplaintService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Users.Controllers
{
    [Authorize]
    public class UserProfilesController : Controller
    {
        private readonly ComplaintService complaintService = new ComplaintService();
        private readonly UserServices userServices = new UserServices();
        // GET: Users/UserProfile
        public ActionResult UserProfile()
        {
            try
            {
                var userid = User.Identity.Name;
                var user = userServices.GetbyIDService(Guid.Parse(userid));
                var complaints = complaintService.GetAllComplaints();

                ViewBag.User = user;
                ViewBag.Complaints = complaints;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}