using OCMS.Authentication;
using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    public class StatusController : CookiesService
    {
        // GET: Visitors/Status
        public ActionResult StatusView()
        {
            GetUserStatusDto getUserStatusDto = new GetUserStatusDto();
            if(IsExistCookie(CookiesKey.Status))
            {
                var userstatus = GetCookies(CookiesKey.Status);
                getUserStatusDto.Status = userstatus;
            }
            return View(getUserStatusDto);
        }
    }
}