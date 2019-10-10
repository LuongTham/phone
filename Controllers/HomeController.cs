using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;
namespace Phone.Controllers
{
    public class HomeController : Controller
    {

        private PhoneEntities db = new PhoneEntities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["email"] != null)
            {
                return RedirectToAction("IndexLoggedIn","Home");
            }
            var listCategory = db.Categories.OrderByDescending(tbl => tbl.id_Category).ToList();
            return View("_LayoutHome", listCategory);
        }
        public ActionResult IndexLoggedIn()
        {
            return View();
        }

    }
}