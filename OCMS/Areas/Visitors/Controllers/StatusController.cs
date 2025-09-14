using OCMS.Authentication;
using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using OCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    public class StatusController : CookiesService
    {
        UserServices userServices = new UserServices();
        // GET: Visitors/Status
        public ActionResult StatusView()
        {
            try
            {
                GetUserStatusDto getUserStatusDto = new GetUserStatusDto();
                if (IsExistCookie(CookiesKey.UserId))
                {
                    var user = userServices.GetbyIDService(Guid.Parse(GetCookies(CookiesKey.UserId)));
                    getUserStatusDto.Status = (UserStatus)user.Status;
                }
                return View(getUserStatusDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
