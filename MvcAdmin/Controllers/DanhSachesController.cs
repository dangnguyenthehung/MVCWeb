﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Framework;
using MvcAdmin.Models;
using MvcAdmin.Code;

namespace MvcAdmin.Controllers
{
    public class DanhSachesController : Controller
    {
        
        private DanhSachModel context = new DanhSachModel(); 

        // GET: DanhSaches
        public ActionResult Index()
        {
            var id = 0;
            var list = context.List_ID(id);
            return View(list);
        }

        // GET: DanhSaches/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // declare model
            DanhSachMainModel model = new DanhSachMainModel();
            //
            List<DanhSach> List = context.List_ID(id);
            DanhSach user = List[0];
            List<ViewKQ> listKQ = context.List_Statistic_ID(id);
            //
            model.user = user;
            model.listKQ = listKQ;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
        public ActionResult Create([Bind(Include = "IDQN,HoTen,CB,CV,DonVi,ThanhPhan")] DanhSach user)
        {
            if (ModelState.IsValid)
            {
                context.Insert(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: DanhSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<DanhSach> List = context.List_ID(id);
            DanhSach user = List[0];
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: DanhSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDQN,HoTen,CB,CV,DonVi,ThanhPhan")] DanhSach user)
        {
            if (ModelState.IsValid)
            {
                context.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
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

        // GET: DanhSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // declare model
            DanhSachMainModel model = new DanhSachMainModel();
            //
            List<DanhSach> List = context.List_ID(id);
            DanhSach user = List[0];
            List<ViewKQ> listKQ = context.List_Statistic_ID(id);
            //
            model.user = user;
            model.listKQ = listKQ;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //POST: DanhSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachModel model = new DanhSachModel();
            model.Delete_user(id);
            
            return RedirectToAction("Index");
            
        }
        // DeleteResult
        public ActionResult DeleteResult(int? IDKQ, int? IDQN)
        {
            if (IDKQ == null || IDQN == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KetQuaKiemTraModel model = new KetQuaKiemTraModel();

            ViewKQ obj = new ViewKQ();
            obj = model.GetResult(IDKQ, IDQN);
            if (obj == null)
            {
                return View("NoResult");
            }

            return View(obj);
        }
        
        //POST: DanhSaches/Delete/5
        [HttpPost, ActionName("DeleteResult")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteResultConfirmed(int? IDKQ, int? IDQN)
        {
            if (IDKQ == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQuaKiemTraModel model = new KetQuaKiemTraModel();
            model.DeleteResult(IDKQ);
            if (IDQN != null)
            {
                return RedirectToAction("Details", new { id = IDQN});

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

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
