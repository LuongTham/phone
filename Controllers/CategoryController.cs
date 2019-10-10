using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class CategoryController : Controller
    {
        protected PhoneEntities db = new PhoneEntities();
        // GET: Category
        public ActionResult ListCategory()
        {
            var listCategory1 = db.Categories.OrderByDescending(tbl => tbl.id_Category).ToList();
            return View("ListCategory", listCategory1);
        }
        public ActionResult DetailsPage(int id)
        {
            var product = db.Products.Where(tbl => tbl.id_Product == id).SingleOrDefault();
            return View("DetailsPage",product);
        }
    }
    }