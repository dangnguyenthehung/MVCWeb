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
            string RePath = path.Replace("HSQ\\Index", "Views\\HSQ");
            int fCount = Directory.GetFiles(RePath, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount)+1;
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
            SessionHelper.SetSession(new UserSession() { UserName = model.HoTen, ID = model.ID, DeSo = rdmView });
            //Session.Add("ID", model.ID);
            //Session.Add("DeSo", rdmView);

            return RedirectToAction(rdmAction);
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

        public ActionResult MainAction(KetQuaModel model)
        {
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("HSQ", "Views\\HSQ");
            var answer = new UserAnswer();
            string correctAns = CorrectAnswerHelper.GetCorrectAnswer(answer.Object);
            answer.Object = "HSQ" + model.DeSo;
            answer.UAnswer = model.TraLoi;
            answer.CorrectAnswer = correctAns;

            decimal mark = CorrectAnswerHelper.Calculate(answer, RePath);

            decimal k = Convert.ToDecimal(6.5);
            if (8 <= mark)
            {
                model.XepLoai = "G";
            }
            else if (k <= mark)
            {
                model.XepLoai = "K";
            }
            else if (5 <= mark)
            {
                model.XepLoai = "Đ";
            }
            else
            {
                model.XepLoai = "KĐ";
            }
            model.KQ = mark;
            model.DapAn = correctAns;
            //insert
            CorrectAnswerHelper.Insert(model);
            var show = new ShowResultModel();
            show.mark = model.KQ;
            switch (model.XepLoai)
            {
                case "G":
                    show.quality = "Giỏi";
                    break;
                case "K":
                    show.quality = "Khá";
                    break;
                case "Đ":
                    show.quality = "Đạt yêu cầu";
                    break;
                default:
                    show.quality = "Không đạt yêu cầu";
                    break;
            }
            string desAction = model.IDQN + "_HSQ" + model.DeSo;
            show.fileName = desAction;
            show.type = "HSQ";
            return RedirectToAction("Index","Result",show);
        }

        [HttpGet]
        public ActionResult HSQ1()
        {
            //var model = new KetQuaModel();
            var session = SessionHelper.GetSession();
            //System.Diagnostics.Debug.WriteLine(session.ID);
            //System.Diagnostics.Debug.WriteLine(session.DeSo);

            return View();
        }
        [HttpGet]
        public ActionResult HSQ2()
        {
            var session = SessionHelper.GetSession();
            return View();
        }
        [HttpGet]
        public ActionResult HSQ3()
        {
            var session = SessionHelper.GetSession();
            return View();
        }
        [HttpGet]
        public ActionResult HSQ4()
        {
            var session = SessionHelper.GetSession();
            return View();
        }

        [HttpPost]
        public ActionResult HSQ1(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult HSQ2(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult HSQ3(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult HSQ4(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
    }
}
