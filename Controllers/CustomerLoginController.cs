using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;
namespace Phone.Controllers
{
    public class CustomerLoginController : Controller
    {
        //khai bao doi tuong de thao tac voi doi csdl
        protected PhoneEntities db = new PhoneEntities();
        // GET: Admin/Login
        public ActionResult CustomerLogin()
        {
            //Response.Write(System.Web.Helpers.Crypto.SHA256("123"));
            return View();
        }

        public ActionResult CreateAccount()
        {
            
            return View();
        }

        public void DoAdd()
        {
            var _email = Request.Form["email"];
            var number = db.Users.Where(tbl => tbl.email == _email).Count();
            if (number > 0)
            {
                Response.Redirect("/CustomerLogin/CreateAccount/Add?email=exits");
            }
            else
            {
                Customer record = new Customer();
                record.name = Request.Form["fullname"]; ;
                record.Email = Request.Form["email"];
                record.Password = System.Web.Helpers.Crypto.SHA256(Request.Form["password"]);
                db.Customers.Add(record);
                db.SaveChanges();
                Response.Redirect("/CustomerLogin/CreateAccount/Add?signup=done");
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        
        public ActionResult DoLogin()
        {
            string _email = Request.Form["email"];
            string _password = Request.Form["password"];
            string _name = "";
            //ma hoa password
            _password = System.Web.Helpers.Crypto.SHA256(_password);
            //tim kiem ban ghi
            //var record = db.users.Where(tbl => tbl.email == _email && tbl.password == password).FirstOrDefault();
            var record = (from tbl in db.Customers where tbl.Password == _password && tbl.Email == _email select tbl).FirstOrDefault();
            if (record != null)
            {
                _name = record.name;
                Session["name"] = _name;
                Session["email"] = _email;
                return RedirectToAction("IndexLoggedIn", "Home");
            }
            return RedirectToAction("CustomerLogin", "CustomerLogin");
        }

    }
}