using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;
using PagedList;
using Phone.Areas.Admin.Models;
namespace Phone.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        protected PhoneEntities csdl = new PhoneEntities();
        // GET: Admin/User
        [CheckLogin]
        public ActionResult ListUser(int? page)
        {
            //var list_record = (from tbl in csdl.Users select tbl).ToList();
            int pageSize = 5;
            int pageNumber = (page.HasValue) ? Convert.ToInt32(page) : 1;
            var list_record = csdl.Users.OrderByDescending(tbl => tbl.id).ToList();
            return View(list_record.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Delete(int id)
        {
            var record = (from tbl in csdl.Users where tbl.id == id select tbl).FirstOrDefault();
            csdl.Users.Remove(record);
            csdl.SaveChanges();
            return RedirectToAction("ListUser", "User");
        }
        public ActionResult Add()
        {
            ViewBag.FormAction = "/Admin/User/DoAdd";
            return View("AddUser");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public void DoAdd()
        {
            var _email = Request.Form["email"];
            var number = csdl.Users.Where(tbl => tbl.email == _email).Count();
            if (number > 0)
            {
                Response.Redirect("/Admin/User/Add?email=exits");
            }
            else { 
                User record = new User();
                record.fullname = Request.Form["fullname"]; ;
                record.email = Request.Form["email"];
                record.password = System.Web.Helpers.Crypto.SHA256(Request.Form["password"]);
                csdl.Users.Add(record);
                csdl.SaveChanges();
                Response.Redirect("/Admin/User/ListUser");
            }
        }
        public ActionResult Edit(int id)
        {
            var record = (from tbl in csdl.Users where tbl.id == id select tbl).FirstOrDefault();
            ViewBag.FormAction = "/Admin/User/DoEdit/" + id;
            return View("EditUser", record);
        }
        public ActionResult DoEdit(int id)
        {
            var record = (from tbl in csdl.Users where tbl.id == id select tbl).FirstOrDefault();
            var _password = Request.Form["Password"];
            if (_password != null)
            {
                _password = System.Web.Helpers.Crypto.SHA256(_password);
                record.password = _password;
            }
            record.fullname = Request.Form["fullname"];
            csdl.SaveChanges();
            return RedirectToAction("ListUser", "User");
        }
    }
}