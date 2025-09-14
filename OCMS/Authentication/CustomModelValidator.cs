using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS.Authentication
{
    public class CustomModelValidator : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                var controller = filterContext.Controller as Controller;
                if (controller != null && !controller.ModelState.IsValid)
                {
                    //collect all models error
                    var errors = controller.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );
                    filterContext.Result = new JsonResult
                    {
                        Data = new { success = false, errors },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    };
                    return;
                }

                base.OnActionExecuted(filterContext);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
