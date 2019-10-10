using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Areas.Admin.Models;
namespace Phone.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [CheckLogin]
        public ActionResult Index()
        {
            return View();
        }
    }
}