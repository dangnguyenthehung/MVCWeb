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
    public class DanhSachesController : Controller
    {
        private d38dbContext db = new d38dbContext();

        // GET: DanhSaches
        public ActionResult Index()
        {
            return View(db.DanhSaches.ToList());
        }

        // GET: DanhSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // GET: DanhSaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDQN,HoTen,CB,CV,DonVi,ThanhPhan")] DanhSach danhSach)
        {
            if (ModelState.IsValid)
            {
                db.DanhSaches.Add(danhSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhSach);
        }

        // GET: DanhSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // POST: DanhSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDQN,HoTen,CB,CV,DonVi,ThanhPhan")] DanhSach danhSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhSach);
        }

        // GET: DanhSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // POST: DanhSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSach danhSach = db.DanhSaches.Find(id);
            db.DanhSaches.Remove(danhSach);
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
