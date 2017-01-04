using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Framework;
using Model;
using MvcAdmin.Models;
using MvcAdmin.Code;

namespace MvcAdmin.Controllers
{
    public class ViewKQsController : Controller
    {
        //private d38dbContext db = new d38dbContext();
        private StatisticModel context = new StatisticModel();
        [HttpGet]
        // GET: ViewKQs
        public ActionResult Index()
        {
            StatisticMainModel model = new StatisticMainModel();
            var list = context.ListAll();
            model.listKQ = list;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index (StatisticMainModel model)
        {
            int month = model.month;
            var list = new List<ViewKQ>();
            if (month == 0)
            {
                list = context.ListAll();
            }
            else
            {
                list = context.List_Month(month);
            }
            model.listKQ = list;
            return View(model);
        }

        // syncing result - realtime syncing
        [HttpGet]
        public ActionResult SyncResult()
        {
            List<ViewKQ> data = func_SyncResult.show_New_Result();
            string[] text = { " " };
            var i = 0;
            if (data == null)
            {
                text[0] = "normal";
            }   
            else
            {
                for (i = 0; i < text.Length; i++)
                {
                    string str = "Nộp bài: " + data[i].HoTen + " - " + data[i].KQ + " điểm";
                    text[i] = str;
                }
            }

            return Json(text, JsonRequestBehavior.AllowGet);

        }
        // GET: ViewKQs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewKQ viewKQ = db.ViewKQs.Find(id);
        //    if (viewKQ == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(viewKQ);
        //}

        // POST: ViewKQs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ViewKQ viewKQ = db.ViewKQs.Find(id);
        //    db.ViewKQs.Remove(viewKQ);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
