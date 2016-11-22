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

        public ActionResult Index()
        {
            //Return path of Views part to count files
            string path = HttpContext.Server.MapPath("");
            path = path.Replace("HSQ", "Views/HSQ");
            int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount) + 1;
            System.Diagnostics.Debug.WriteLine(rdmView);
            string rdmAction = "HSQ" + rdmView;
            return RedirectToAction(rdmAction);
        }

        //
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
        public ActionResult HSQ1()
        {
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
