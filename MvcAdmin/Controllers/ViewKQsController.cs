using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Framework;

namespace MvcAdmin.Controllers
{
    public class ViewKQsController : Controller
    {
        private d38dbContext db = new d38dbContext();

        // GET: ViewKQs
        public ActionResult Index()
        {
            return View(db.ViewKQs.ToList());
        }

        // GET: ViewKQs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewKQ viewKQ = db.ViewKQs.Find(id);
            if (viewKQ == null)
            {
                return HttpNotFound();
            }
            return View(viewKQ);
        }

        // POST: ViewKQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewKQ viewKQ = db.ViewKQs.Find(id);
            db.ViewKQs.Remove(viewKQ);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
