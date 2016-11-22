using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class SQController : Controller
    {
        //
        // GET: /SQ/


        public ActionResult Index()
        {
            //string path1 = Directory.GetCurrentDirectory() + "/Views/SQ";
            string path = HttpContext.Server.MapPath("");
            path = path.Replace("SQ","Views/SQ");
           
            int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount) + 1;
            System.Diagnostics.Debug.WriteLine(rdmView);
            string rdmAction = "SQ" + rdmView;
            return RedirectToAction(rdmAction);
        }
        public ActionResult SQ1()
        {
            return View();
        }
        public ActionResult SQ2()
        {
            return View();
        }
        public ActionResult SQ3()
        {
            return View();
        }
        public ActionResult SQ4()
        {
            return View();
        }

    }
}
