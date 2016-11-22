using Model;
using MvcWEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class ChooseTypeController : Controller
    {
        //
        // GET: /ChooseType/

        public ActionResult ChooseType()
        {
            // Let's get all type that we need for a DropDownList
            var type = GetAllType();
            var name = GetAllName();

            var model = new ChooseTypeModel();

            // Create a list of SelectListItems so these can be rendered on the page
            model.Type = GetSelectListItems(type);
            model.Name = GetSelectListItems(name);


            return View("ChooseType", model);


            //var iplChoosen = new ChooseTypeModel();
            ////return View(model);
            //var tupleModel = new Tuple<List<DanhSachModel>,ChooseTypeModel>(null,iplChoosen);
            //return View(tupleModel);

        }



        [HttpPost]
        public ActionResult ChooseType(ChooseTypeModel model)
        {
            //Get all type again
            var type = GetAllType();
            var name = GetAllName();

            // Set these type on the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of types.
            model.Type = GetSelectListItems(type);
            model.Name = GetSelectListItems(name);

            // In case everything is fine - i.e. both "Name" and "Type" are entered/selected,
            // redirect user to the "Done" page, and pass the user object along via Session

            //if (ModelState.IsValid)
            //{
            //   Session["ChooseTypeModel"] = model;
            //    return RedirectToAction("HSQ","Test");
            //}

            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            if (model.ThanhPhan == "SQ")
            {
                return RedirectToAction("Index", "SQ");
            }
            else if (model.ThanhPhan == "QNCN")
            {
                return RedirectToAction("QNCN", "Test");
            }
            return RedirectToAction("HSQ", "Test");

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
        private IEnumerable<string> GetAllName()
        {
            var model = new DanhSachModel();
            var modelList = model.ListAll();
            var nameList = new List<string>();
            foreach (var item in modelList)
            {
                nameList.Add(item.HoTen);
            }

            return nameList;
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

    }
}
