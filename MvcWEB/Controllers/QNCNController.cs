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
    public class QNCNController : Controller
    {
        //

        // GET: /QNCN/

        public ActionResult Index(ChooseTypeModel model)
        {
            //Return path of Views part to count files
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("QNCN\\Index", "Views\\QNCN");
            int fCount = Directory.GetFiles(RePath, "*", SearchOption.TopDirectoryOnly).Length;
            System.Diagnostics.Debug.WriteLine(fCount);
            Random rdm = new Random();
            int rdmView = rdm.Next(fCount)+1;
            //print to output for test
            System.Diagnostics.Debug.WriteLine(rdmView);
            System.Diagnostics.Debug.WriteLine(model.HoTen);
            System.Diagnostics.Debug.WriteLine(model.ID);
            //choose random action
            string rdmAction = "QNCN_" + rdmView;

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
            string RePath = path.Replace("QNCN", "Views\\QNCN");
            var answer = new UserAnswer();

            answer.Object = "QNCN_" + model.DeSo;
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
            string desAction = model.IDQN + "_QNCN_" + model.DeSo;
            show.fileName = desAction;
            show.type = "QNCN";
            return RedirectToAction("Index","Result",show);
        }

        // check log status
        public int CheckStatus (int id)
        {
            var permission = new PermissionModel();
            var check = new ChooseTypeController().checkPermission(id);
            if (check == 1)
            {
                permission.SetLogStatus(id,1);
                return 1;
            }
            else
            {
                return 0;
            }
        } // end check
        // prevent user to click back to exam after submit
        public int PreventBack()
        {
            var session = SessionHelper.GetSession();
            var permission = new PermissionModel();
            var check = new ChooseTypeController().checkPermission(session.ID);
            if (check == 2)
            {

                return 2;
            }
            else
            {
                return 0;
            }
        }
        // keep client alive - contact with server during exam time
        [HttpGet]
        public ActionResult KeepAlive()
        {
            return Content("Still alive!");
        }

        // Routing with random Examination
        [HttpGet]
        public ActionResult QNCN_1()
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
        public ActionResult QNCN_2()
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
        public ActionResult QNCN_3()
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
        public ActionResult QNCN_4()
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
        public ActionResult QNCN_5()
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
        public ActionResult QNCN_6()
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
        public ActionResult QNCN_7()
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
        public ActionResult QNCN_8()
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
        public ActionResult QNCN_9()
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
        public ActionResult QNCN_10()
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
        public ActionResult QNCN_11()
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
        public ActionResult QNCN_12()
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
        public ActionResult QNCN_13()
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
        public ActionResult QNCN_14()
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
        public ActionResult QNCN_15()
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
        public ActionResult QNCN_16()
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
        public ActionResult QNCN_17()
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
        public ActionResult QNCN_18()
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
        public ActionResult QNCN_19()
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
        public ActionResult QNCN_20()
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
        public ActionResult QNCN_21()
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
        public ActionResult QNCN_22()
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
        public ActionResult QNCN_23()
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
        public ActionResult QNCN_24()
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
        public ActionResult QNCN_25()
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
        public ActionResult QNCN_26()
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
        public ActionResult QNCN_27()
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
        public ActionResult QNCN_28()
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
        public ActionResult QNCN_29()
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
        public ActionResult QNCN_30()
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
        public ActionResult QNCN_1(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_2(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_3(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_4(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_5(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_6(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_7(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_8(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_9(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_10(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_11(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_12(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_13(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_14(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_15(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_16(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_17(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_18(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_19(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_20(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_21(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_22(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_23(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_24(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_25(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_26(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_27(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_28(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_29(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult QNCN_30(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
    }
}
