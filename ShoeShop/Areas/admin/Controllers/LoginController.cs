using Models;
using Models.Dao;
using ShoeShop.Areas.admin.Code;
using ShoeShop.Areas.admin.Models;
using ShoeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoeShop.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var dao = new UserDao();
            var res = dao.Login(model.UserName, Encriptor.MD5Hash(model.Password));
            if (ModelState.IsValid)
            {
                switch (res)
                {
                    case 0:
                        ModelState.AddModelError("", CommonConstant.LOGIN_FAIL);
                        break;
                    case -1:
                        ModelState.AddModelError("", CommonConstant.USER_IS_BLOCKED);
                        break;
                    default:
                        var user = dao.GetNguoiDungByName(model.UserName);
                        var userSession = new UserSession();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.ID;
                        userSession.UserRole = user.Role;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        return RedirectToAction("Dashboard", "AdminHome");
                }
               
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION]=null;
            return RedirectToAction("Index", "Login");
        }
    }
}