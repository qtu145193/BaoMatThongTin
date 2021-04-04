using ATTT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATTT.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}