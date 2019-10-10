using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Areas.Admin.Controllers
{
    public class LogOutController : Controller
    {
        // GET: Admin/LogOut
        public ActionResult Index()
        {
            Session["email"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}