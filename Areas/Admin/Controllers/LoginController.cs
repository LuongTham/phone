using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;
namespace Phone.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //khai bao doi tuong de thao tac voi doi csdl
        protected PhoneEntities db = new PhoneEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            //Response.Write(System.Web.Helpers.Crypto.SHA256("123"));
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DoLogin()
        {
            string _email = Request.Form["email"];
            string _password = Request.Form["password"];
            //ma hoa password
            _password = System.Web.Helpers.Crypto.SHA256(_password);
            //tim kiem ban ghi
            //var record = db.users.Where(tbl => tbl.email == _email && tbl.password == password).FirstOrDefault();
            var record = (from tbl in db.Users where tbl.password == _password select tbl).FirstOrDefault();
            if (record != null)
            {
                Session["email"] = _email;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

    }
}