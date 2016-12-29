using Model;
using MvcWEB.Code;
using MvcWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Controllers
{
    public class SQController : Controller
    {
        //

        // GET: /SQ/

        public ActionResult Index(ChooseTypeModel model)
        {
            //Return path of Views part to count files
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("SQ\\Index", "Views\\SQ");
            int fCount = Directory.GetFiles(RePath, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount) + 1;
            //print to output for test
            System.Diagnostics.Debug.WriteLine(rdmView);
            System.Diagnostics.Debug.WriteLine(model.HoTen);
            System.Diagnostics.Debug.WriteLine(model.ID);
            //choose random action
            string rdmAction = "SQ" + rdmView;

            //return RedirectToAction(rdmAction);
            SessionHelper.SetSession(new UserSession() { UserName = model.HoTen, ID = model.ID, DeSo = rdmView });
            //Session.Add("ID", model.ID);
            //Session.Add("DeSo", rdmView);

            return RedirectToAction(rdmAction);
        }

        //return Views

        public ActionResult MainAction(KetQuaModel model)
        {
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("SQ", "Views\\SQ");
            var answer = new UserAnswer();

            answer.Object = "SQ" + model.DeSo;
            string correctAns = CorrectAnswerHelper.GetCorrectAnswer(answer.Object);
            
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
            string desAction = model.IDQN + "_SQ" + model.DeSo;
            show.fileName = desAction;
            show.type = "SQ";
            return RedirectToAction("Index", "Result", show);
        }

        // check log status
        public int CheckStatus(int id)
        {
            var permission = new PermissionModel();
            var check = new ChooseTypeController().checkPermission(id);
            if (check == 1)
            {
                permission.SetLogStatus(id);
                return 1;
            }
            else
            {
                return 0;
            }
        } // end check

        // keep client alive - contact with server during exam time
        [HttpGet]
        public ActionResult KeepAlive()
        {
            return Content("Still alive!");
        }

        // Routing with random Examination
        [HttpGet]
        public ActionResult SQ1()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            //System.Diagnostics.Debug.WriteLine(session.ID);
            //System.Diagnostics.Debug.WriteLine(session.DeSo);
            return View();
        }
        [HttpGet]
        public ActionResult SQ2()
        {
            var session = SessionHelper.GetSession();
            if (session == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ3()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ4()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ5()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ6()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ7()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ8()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ9()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SQ10()
        {
            var session = SessionHelper.GetSession();
            var check = CheckStatus(session.ID);
            if (check == 1)
            {
                // do nothing
            }
            else
            {
                return RedirectToAction("ChooseType", "ChooseType");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SQ1(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ2(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ3(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ4(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ5(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ6(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ7(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ8(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ9(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult SQ10(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
    }
}
