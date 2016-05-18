using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using ShoeShop.Areas.admin.Code;
using ShoeShop.Common;

namespace ShoeShop.Areas.admin.Controllers
{
    public class LienHeController : Controller
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var lh = new LienHeDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = lh.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = lh.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/LienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/LienHe/Create
        [HttpPost]
        public ActionResult Create(LienHe collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new LienHeDao();
                long id = dao.Insert(collection);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.INSERT_FAIL);
                }
            }
            else
            {
                ModelState.AddModelError("", CommonConstant.INSERT_FAIL);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase Image)
        {
            string path = Server.MapPath(Image.FileName);
            Image.SaveAs(path);
            return View("Create");
        }
        // GET: admin/LienHe/Edit/5
        public ActionResult Edit(int id)
        {
            var lh = new LienHeDao().ViewDetail(id);
            return View(lh);
        }

        // POST: admin/LienHe/Edit/5
        [HttpPost]
        public ActionResult Edit(LienHe lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new LienHeDao();
                var res = dao.Update(lh);
                if (res)
                {
                    return RedirectToAction("Index", "LienHe");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/LienHe/Delete/5
        public ActionResult Delete(int id)
        {
            new LienHeDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/LienHe/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new LienHeDao().Delete(int.Parse(id));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "có lỗi");
                return RedirectToAction("Index");
            }
        }
    }
}