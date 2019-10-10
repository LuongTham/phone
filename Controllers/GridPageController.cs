using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class GridPageController : Controller
    {
        // GET: GridPage
        public ActionResult CategoryGrid()
        {
            return View();
        }
    }
}