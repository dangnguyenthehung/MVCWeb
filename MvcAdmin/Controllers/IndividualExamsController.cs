using Model;
using Model.Framework;
using MvcAdmin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdmin.Controllers
{
    public class IndividualExamsController : Controller
    {
        private IndividualExamModel context = new IndividualExamModel();

        // GET: IndividualExams
        public ActionResult Index()
        {
            var list = context.ListAll();
            IndividualExamMainModel viewModel = new IndividualExamMainModel();
            viewModel.ListView = list;

            var total = GetTotalExam();
            var examList = getExamList(total);
            var selectlist = GetSelectListItems(examList);
            viewModel.TotalExam = selectlist;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IndividualExamMainModel model)
        {
            var ID = model.CaptID;
            var Act = model.Action;
            if (Act == "RefreshAll" && ID == 0)
            {
                context.Refresh(ID);
            }
            else
            {
                //
            }

            return RedirectToAction("Index");
        }

        public int GetTotalExam()
        {
            int total = 0;
            string path = "D:\\DeCaNhan\\";
            int fCount = Directory.GetFiles(path, "*.cshtml", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            total = fCount;
            return total;
        }
        public IEnumerable<string> getExamList(int total)
        {
            List<string> list = new List<string>();
            var i = 0;
            for (i=0; i <= total; i++)
            {
                list.Add(i.ToString());
            }
            foreach(var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
            return list;
        }
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
                    Text = "Đề số: " + element
                });
            }

            return selectList;
        }

        public JsonResult LoadList(int id, string examNumber)
        {
            ViewIndividualExam obj = new ViewIndividualExam();

            int number = int.Parse(examNumber);
            //if (act == "Set")
            //{
                context.SetIndividualExams(id, number);
            //}
            //else
            //{
                //context.Refresh(id);
            //}
            obj = context.GetOne(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}