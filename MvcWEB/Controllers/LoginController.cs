using MvcWEB.Code;
using MvcWEB.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcWEB.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Client/Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            // var result = new AccountModel().Login(model.UserName, model.Pass);
            if (Membership.ValidateUser(model.UserName, model.Pass) && ModelState.IsValid && model.UserName != "admin")
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("ChooseType", "ChooseType");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("ChooseType", "ChooseType");
        }
    }
}
