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
        private PermissionModel context = new PermissionModel(); 
        
        // GET: ViewPermissions
        public ActionResult Index()
        {
            var viewList = new List<ViewPermission>();
            viewList = context.ListAll();
            // divide list
            var list_SQ = new List<PermissionObj>();
            var list_QNCN = new List<PermissionObj>();
            var list_HSQ_TS = new List<PermissionObj>();
            var list_HSQ_TT = new List<PermissionObj>();
            var list_HSQ_dB_bBD = new List<PermissionObj>();

            list_SQ = GetPermission_SQ(viewList);
            list_QNCN = GetPermission_QNCN(viewList);
            list_HSQ_TS = GetPermission_HSQ_TS(viewList);
            list_HSQ_TT = GetPermission_HSQ_TT(viewList);
            list_HSQ_dB_bBD = GetPermission_HSQ_dB_BD(viewList);

            var mainModel = new PermissionMainModel();
            mainModel.PerList_SQ = list_SQ;
            mainModel.PerList_QNCN = list_QNCN;
            mainModel.PerList_HSQ_TS = list_HSQ_TS;
            mainModel.PerList_HSQ_TT = list_HSQ_TT;
            mainModel.PerList_HSQ_dB_BD = list_HSQ_dB_bBD;

            return View(mainModel);
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

        // create individual list for each type - easy to control on view page
        private List<PermissionObj> GetPermission_SQ (List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation
            
            var perList = new List<PermissionObj>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            foreach (var item in view)
            {
                if (item.ThanhPhan == "SQ")
                {
                    var permisObj = new PermissionObj();
                    permisObj.IDQN = item.IDQN;
                    permisObj.Hoten = item.HoTen;
                    permisObj.Permission = item.Permission;
                    permisObj.LogStatus = item.LogStatus;
                    //permisObj.ThanhPhan = item.ThanhPhan;
                    perList.Add(permisObj);
                }
            }

            return perList;
        }
        private List<PermissionObj> GetPermission_QNCN(List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation

            var perList = new List<PermissionObj>();

            // For each string in the 'view' variable, create a new List<PermissionObj> object
            // that has properties set to a particular value.
            // This will result in MVC rendering each item as:
            foreach (var item in view)
            {
                if (item.ThanhPhan == "QNCN")
                {
                    var permisObj = new PermissionObj();
                    permisObj.IDQN = item.IDQN;
                    permisObj.Hoten = item.HoTen;
                    permisObj.Permission = item.Permission;
                    permisObj.LogStatus = item.LogStatus;
                    perList.Add(permisObj);
                }
            }

            return perList;
        }
        private List<PermissionObj> GetPermission_HSQ_TS (List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation

            var perList = new List<PermissionObj>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            foreach (var item in view)
            {
                if (item.ThanhPhan == "HSQ" && item.DonVi == "cTS")
                {
                    var permisObj = new PermissionObj();
                    permisObj.IDQN = item.IDQN;
                    permisObj.Hoten = item.HoTen;
                    permisObj.Permission = item.Permission;
                    permisObj.LogStatus = item.LogStatus;
                    perList.Add(permisObj);
                }
            }

            return perList;
        }
        private List<PermissionObj> GetPermission_HSQ_TT (List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation

            var perList = new List<PermissionObj>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            foreach (var item in view)
            {
                if (item.ThanhPhan == "HSQ" && item.DonVi == "cTT")
                {
                    var permisObj = new PermissionObj();
                    permisObj.IDQN = item.IDQN;
                    permisObj.Hoten = item.HoTen;
                    permisObj.Permission = item.Permission;
                    permisObj.LogStatus = item.LogStatus;
                    perList.Add(permisObj);
                }
            }

            return perList;
        }
        private List<PermissionObj> GetPermission_HSQ_dB_BD (List<ViewPermission> view)
        {
            // Create an empty list to hold result of the operation

            var perList = new List<PermissionObj>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            foreach (var item in view)
            {
                if (item.ThanhPhan == "HSQ" && ( item.DonVi == "dB" || item.DonVi == "bBD"))
                {
                    var permisObj = new PermissionObj();
                    permisObj.IDQN = item.IDQN;
                    permisObj.Hoten = item.HoTen;
                    permisObj.Permission = item.Permission;
                    permisObj.LogStatus = item.LogStatus;
                    perList.Add(permisObj);
                }
            }

            return perList;
        }

        // JSON accept or refresh permission without reload page
        public JsonResult LoadList(int id, string act)
        {
            ViewPermission obj = new ViewPermission();
               
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
