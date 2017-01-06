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
    public class IndividualController : Controller
    {
        //

        // GET: /Individual/

        public ActionResult Index(ChooseTypeModel model)
        {
            //Return path of Views part to count files

            System.Diagnostics.Debug.WriteLine(model.HoTen);
            System.Diagnostics.Debug.WriteLine(model.ID);

            //get Indicidual action
            int number = IndividualExamNumber(model.ID);
            string rdmAction = "Individual" + number;

            //return RedirectToAction(rdmAction);
            SessionHelper.SetSession(new UserSession() { UserName = model.HoTen, ID = model.ID, DeSo = number });


            return RedirectToAction(rdmAction);
        }

        //get individual exam number of user
        private int IndividualExamNumber(int id)
        {
            IndividualExamModel context = new IndividualExamModel();
            int number = context.GetOne(id).IndividualExam.GetValueOrDefault(); // convert from int? to int
            return number;
        }
        //return Views

        public ActionResult MainAction(KetQuaModel model)
        {
            string path = HttpContext.Server.MapPath("");
            string RePath = path.Replace("Individual", "Views\\Individual");
            var answer = new UserAnswer();

            answer.Object = "Individual" + model.DeSo;
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
            string desAction = model.IDQN + "_Individual" + model.DeSo;
            show.fileName = desAction;
            show.type = "Individual";
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
        public ActionResult Individual1()
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
        public ActionResult Individual2()
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
        public ActionResult Individual3()
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
        public ActionResult Individual4()
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
        public ActionResult Individual5()
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
        public ActionResult Individual6()
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
        public ActionResult Individual7()
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
        public ActionResult Individual8()
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
        public ActionResult Individual9()
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
        public ActionResult Individual10()
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
        public ActionResult Individual11()
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
        public ActionResult Individual12()
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
        public ActionResult Individual13()
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
        public ActionResult Individual14()
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
        public ActionResult Individual15()
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
        public ActionResult Individual16()
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
        public ActionResult Individual17()
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
        public ActionResult Individual18()
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
        public ActionResult Individual19()
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
        public ActionResult Individual20()
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
        public ActionResult Individual1(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual2(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual3(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual4(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual5(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual6(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual7(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual8(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual9(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual10(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual11(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual12(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual13(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual14(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual15(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual16(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual17(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual18(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual19(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
        [HttpPost]
        public ActionResult Individual20(KetQuaModel model)
        {
            return RedirectToAction("MainAction", model);
        }
    }
}
