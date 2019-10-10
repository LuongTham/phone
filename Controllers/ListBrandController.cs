using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class ListBrandController : Controller
    {
        PhoneEntities db = new PhoneEntities();
        // GET: ListBrand
        public ActionResult _ListBrand(int cateid, int brandid)
        {
            var ListBrand = db.Products.Where(tbl => tbl.id_Category == cateid && tbl.brand_id == brandid).OrderByDescending(tbl => tbl.id_Product).ToList();
            return View("_ListBrand", ListBrand);
        }
    }
}