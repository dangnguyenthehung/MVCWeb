using Model;
using MvcWEB.Code;
using MvcWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class HSQController : Controller
    {
        //
        
        // GET: /HSQ/
        
        public ActionResult Index(ChooseTypeModel model)
        {
            //Return path of Views part to count files
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("HSQ\\Index","Views\\HSQ");
            int fCount = Directory.GetFiles(RePath, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount) + 1;
            //print to output for test
            System.Diagnostics.Debug.WriteLine(rdmView);
            System.Diagnostics.Debug.WriteLine(model.HoTen);
            System.Diagnostics.Debug.WriteLine(model.ID);
            //choose random action
            string rdmAction = "HSQ" + rdmView;

            //return RedirectToAction(rdmAction);

            // testing
            //var KQ = new KetQuaModel();
            //KQ.IDQN = model.ID;
            //KQ.DeSo = rdmView;
            //GetInfo(KQ);
            SessionHelper.SetSession(new UserSession() { ID = model.ID, DeSo = rdmView });
            //Session.Add("ID", model.ID);
            //Session.Add("DeSo", rdmView);
            
            return RedirectToAction("HSQ1");
        }

        //
        //public KetQuaModel GetInfo(KetQuaModel KQ)
        //{
        //    var info = new KetQuaModel();
        //    info.IDQN = KQ.IDQN;
        //    info.DeSo = KQ.DeSo;
        //    return info;
        //}
        // GET: /HSQ/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /HSQ/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HSQ/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HSQ/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /HSQ/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HSQ/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /HSQ/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //return Views
        [HttpGet]
        public ActionResult HSQ1()
        {
            var model = new KetQuaModel();
            var session = SessionHelper.GetSession();
            System.Diagnostics.Debug.WriteLine(session.ID);
            System.Diagnostics.Debug.WriteLine(session.DeSo);

            return View("HSQ1");
        }
        [HttpPost]
        public ActionResult HSQ1(KetQuaModel model)
        {
            System.Diagnostics.Debug.WriteLine("------Begin------");
            System.Diagnostics.Debug.WriteLine(model.IDQN);
            System.Diagnostics.Debug.WriteLine(model.KQ);
            System.Diagnostics.Debug.WriteLine(model.XepLoai);
            System.Diagnostics.Debug.WriteLine(model.DeSo);
            System.Diagnostics.Debug.WriteLine("------End------");

            return View();
        }

        public ActionResult HSQ2()
        {
            return View();
        }
        public ActionResult HSQ3()
        {
            return View();
        }
        public ActionResult HSQ4()
        {
            return View();
        }
    }
}
