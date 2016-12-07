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

namespace MvcAdmin.Controllers
{
    public class ViewPermissionsController : Controller
    {
        //private d38dbContext db = new d38dbContext();
        private PermissionModel context = new PermissionModel(); 
        // GET: ViewPermissions
        public ActionResult Index()
        {
            var viewList = new List<ViewPermission>();
            viewList = context.ListAll();
            var list = new List<PermissionObj>();
            list = GetPermission(viewList);
            var mainModel = new PermissionMainModel();
            mainModel.PerList = list;
            return View(mainModel);
            //return View(db.ViewPermissions.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PermissionMainModel obj)
        {
            var id = obj.CaptID;
            var action = obj.Action;
            if (action ==  "Accept")
            {
                context.Accept(id);
            }
            else
            {
                context.Refresh(id);
            }
            
            return RedirectToAction("Index");
        }

        private List<PermissionObj> GetPermission(List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation
            
            var perList = new List<PermissionObj>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var item in view)
            {
                var permisObj = new PermissionObj();
                permisObj.IDQN = item.IDQN;
                permisObj.Hoten = item.HoTen;
                permisObj.Permission = item.Permission;
                permisObj.LogStatus = item.LogStatus;
                perList.Add(permisObj);
            }

            return perList;
        }

        
        public JsonResult LoadList(int id, string act)
        {
            ViewPermission obj = new ViewPermission();
                
            //var id = obj.CaptID;
            //var action = obj.Action;
            if (act == "Accept")
            {
                context.Accept(id);
            }
            else
            {
                context.Refresh(id);
            }
            obj = context.GetOne(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        // GET: ViewPermissions/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewPermission viewPermission = db.ViewPermissions.Find(id);
        //    if (viewPermission == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(viewPermission);
        //}

        // GET: ViewPermissions/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ViewPermissions/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IDQN,HoTen,Permission,LogStatus")] ViewPermission viewPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ViewPermissions.Add(viewPermission);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(viewPermission);
        //}

        // GET: ViewPermissions/Edit/5

        // POST: ViewPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

    }
}
