using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class ListCategoryBrandController : Controller
    {
        PhoneEntities db = new PhoneEntities();

        // GET: ListCategoryBrand
        public ActionResult _ListCategoryBrand(int id)
        {
            var ListProduct = db.Products.Where(tbl => tbl.id_Category == id).OrderByDescending(tbl => tbl.id_Product).ToList();
            return View("_ListCategoryBrand", ListProduct);
        }
    }
}