using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using ShoeShop.Areas.admin.Code;
using ShoeShop.Common;

namespace ShoeShop.Areas.admin.Controllers
{
    public class TagController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var ab = new TagDao();
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

        // GET: admin/Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Tag/Create
        [HttpPost]
        public ActionResult Create(Tag collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new TagDao();
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
        // GET: admin/Tag/Edit/5
        public ActionResult Edit(int id)
        {
            var ab = new TagDao().ViewDetail(id);
            return View(ab);
        }

        // POST: admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(Tag ab)
        {
            if (ModelState.IsValid)
            {
                var dao = new TagDao();
                var res = dao.Update(ab);
                if (res)
                {
                    return RedirectToAction("Index", "Tag");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/Tag/Delete/5
        public ActionResult Delete(int id)
        {
            new TagDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new TagDao().Delete(int.Parse(id));
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