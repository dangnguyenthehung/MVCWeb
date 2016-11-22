using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        //
        // GET: /Client/Test/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HSQ()
        {
            return View("HSQ");
        }

        public ActionResult SQ()
        {
            return View("SQ");
        }

        public ActionResult QNCN()
        {
            return View("QNCN");
        }

    }
}
