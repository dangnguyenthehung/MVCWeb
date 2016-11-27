using MvcWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index(ShowResultModel model)
        {
            string ViewName = model.type + "/" + model.fileName;
            return View(ViewName, model);
        }
        
    }
}