using Models.Dao;
using ShoeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using ShoeShop.Areas.admin.Code;

namespace ShoeShop.Areas.admin.Controllers
{
    public class SliderController : Controller
    {
       
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Slider/Create
        [HttpPost]
        public ActionResult Create(Slider collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new SliderDao();
                int id = dao.Insert(collection);
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
        // GET: admin/Slider/Edit/5
        public ActionResult Edit(int id)
        {
            var ct = new SliderDao().ViewDetail(id);
            return View(ct);
        }

        // POST: admin/Slider/Edit/5
        [HttpPost]
        public ActionResult Edit(Slider ct)
        {
            if (ModelState.IsValid)
            {
                var dao = new SliderDao();
                var res = dao.Update(ct);
                if (res)
                {
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/Slider/Delete/5
        public ActionResult Delete(int id)
        {
            new SliderDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/Slider/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new SliderDao().Delete(int.Parse(id));
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
