using ShoeShop.Areas.admin.Code;
using ShoeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ShoeShop.Areas.admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public string NotAdminFunc()
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (session.UserRole == 1)
            {
                return "block";
            }
            else
            {
                return "none";
            }
        }
        public ActionResult Dashboard()
        {

            return View();
        }
        public ActionResult Page()
        {
                return View();
        }
        public ActionResult AddPage()
        {
                return View();
        }
        public void InsertPage()
        {

        }
    }
}