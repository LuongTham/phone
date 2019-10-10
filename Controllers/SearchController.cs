using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class SearchController : Controller
    {
        protected PhoneEntities db = new PhoneEntities();
        // GET: Search
        public ActionResult DoSearch(string q)
        {
            var search = db.Products.Where(tbl => tbl.name.Contains(q)).ToList();
            return View("DoSearch", search);
        }
    }
}