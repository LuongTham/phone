using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class SearchPriceController : Controller
    {
        PhoneEntities db = new PhoneEntities();
        // GET: SearchPrice
        public ActionResult _SearchPrice(int first_price, int last_price)
        {
            var searchPri = db.Products.Where(tbl => tbl.price >= first_price && tbl.price <= last_price).ToList();
            return View("_SearchPrice", searchPri);
        }
    }
}