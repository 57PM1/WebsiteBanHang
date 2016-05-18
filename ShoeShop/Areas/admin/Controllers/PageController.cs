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
    public class PageController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var ab = new PageDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = ab.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = ab.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/Page/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Page/Create
        [HttpPost]
        public ActionResult Create(Page collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new PageDao();
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
        // GET: admin/Page/Edit/5
        public ActionResult Edit(int id)
        {
            var ab = new PageDao().ViewDetail(id);
            return View(ab);
        }

        // POST: admin/Page/Edit/5
        [HttpPost]
        public ActionResult Edit(Page ab)
        {
            if (ModelState.IsValid)
            {
                var dao = new PageDao();
                var res = dao.Update(ab);
                if (res)
                {
                    return RedirectToAction("Index", "Page");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/Page/Delete/5
        public ActionResult Delete(int id)
        {
            new PageDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/Page/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new PageDao().Delete(int.Parse(id));
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