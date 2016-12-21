using Model;
using Model.Framework;
using MvcWEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class ChooseTypeController : Controller
    {
        //
        // GET: /ChooseType/

        public ActionResult ChooseType()
        {
            var tp = "SQ";
            // Let's get all type that we need for a DropDownList
            var type = GetAllType();
            var name = GetAllName(tp);

            var model = new ChooseTypeModel();

            // Create a list of SelectListItems so these can be rendered on the page
            model.Type = GetSelectListItems(type);
            model.Name = GetSelectListItems(name);


            return View("ChooseType", model);

        }



        [HttpPost]
        public ActionResult ChooseType(ChooseTypeModel model)
        {
            var tp = model.ThanhPhan;
            //Get all type again
            var type = GetAllType();
            var name = GetAllName(tp);
            ;
            // Set these type on the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of types.
            model.Type = GetSelectListItems(type);
            model.Name = GetSelectListItems(name);

            var id = GetID(model.HoTen,tp);
            model.ID = id;
            //var permission = new PermissionModel();
            var res = check(id);

            if (res == 1)
            {
                ViewData["check"] = 1;
                //permission.SetLogStatus(id);
            }
            else
            {   
                ViewData["check"] = 0;
                return View("ChooseType", model);
            }
            
            // In case everything is fine - i.e. both "Name" and "Type" are entered/selected,
            // redirect user to the "Target" page, and pass the user object along via Session

            if (model.ThanhPhan == "SQ")
            {
                return RedirectToAction("Index", "SQ", model);
            }
            else if (model.ThanhPhan == "QNCN")
            {
                return RedirectToAction("Index", "QNCN", model);
            }
            else if (model.ThanhPhan == "HSQ")
            {
                return RedirectToAction("Index", "HSQ", model); // focus on this
            }
            else
            {
                return View();
            }
          
        }
       
        public int check (int id)
        {
            var permission = new PermissionModel();
            ViewPermission res = new ViewPermission();
            res = permission.CheckPermission(id);
            if (res.Permission == 1 && res.LogStatus == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public ActionResult Done()
        {
            // Get Choosen information from the session
            var model = Session["ChooseTypeModel"] as ChooseTypeModel;

            // Display Test page for selected type.
            return View("SQ", "Test");
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<string> GetAllType()
        {
            return new List<string>
            {
                "SQ",
                "QNCN",
                "HSQ"
            };
        }
        //private IEnumerable<string> GetAllName()
        //{
        //    var model = new DanhSachModel();
        //    var modelList = model.ListAll();
        //    var nameList = new List<string>();
        //    foreach (var item in modelList)
        //    {
        //        nameList.Add(item.HoTen);
        //    }

        //    return nameList;
        //}
        private IEnumerable<string> GetAllName(string type)
        {
            var model = new DanhSachModel();
            var modelList = model.List_ThanhPhan(type);
            var nameList = new List<string>();
            foreach (var item in modelList)
            {
                nameList.Add(item.HoTen);
            }

            return nameList;
        }
        private int GetID(string HoTen, string type)
        {
            int id = 0;
            var model = new DanhSachModel();
            var modelList = model.List_ThanhPhan(type);
            foreach(var item in modelList)
            {
                if (item.HoTen == HoTen)
                {
                    id = item.IDQN;
                }
            } 
            return id;
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        public JsonResult LoadName(string type)
        {
            var name = GetAllName(type);
            
            //var l = ob.Name.SingleOrDefault(s => s.Text == type);
            return Json(name, JsonRequestBehavior.AllowGet);
        }

    }
}
