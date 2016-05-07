using ShoeShop.Areas.admin.Code;
using ShoeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShop.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller="Login", action="Index", area="admin"}));
            }
                base.OnActionExecuting(filterContext);
        }
    }
}