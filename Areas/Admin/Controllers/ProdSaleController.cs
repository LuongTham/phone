using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Phone.Models;

namespace Phone.Areas.Admin.Controllers
{
    public class ProdSaleController : Controller
    {
        // GET: Admin/Phone
        PhoneEntities csdl = new PhoneEntities();
        public ActionResult ListProdSale(int? page)
        {
            var ListProdSale = csdl.ProdSales.OrderByDescending(tbl => tbl.id_prodSale).ToList();
            int pageSize = 5;
            int pageIndex = 1;
            if (page.HasValue == true)
            {
                pageIndex = Convert.ToInt32(page);
            }
            return View(ListProdSale.ToPagedList(pageIndex, pageSize));//truyen theo thu tu
        }
        public ActionResult Add()
        {
            ViewBag.FormAction = "/Admin/ProdSale/Doadd";
            return View("AddProdSale");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoAdd(FormCollection fc)
        {
            ProdSale record = new ProdSale();
            record.name = fc["name"];
            //
            record.newprice = 0;
            if (fc["newprice"] != "")
            record.newprice = Convert.ToInt32(fc["newprice"]);
            //
            record.oldprice = 0;
            if (fc["oldprice"] != "")
                record.oldprice = Convert.ToInt32(fc["oldprice"]);
            //
            record.id_Category = Convert.ToInt32(fc["id_Category"]);
            //
            int Random = 0;
            if (Request.Form["Random"] != null)
            {
                Random = 1;
            }
            record.Random = Convert.ToBoolean(Random);
            //
            int Bestseller = 0;
            if (Request.Form["Bestseller"] != null)
            {
                Bestseller = 1;
            }
            record.Bestseller = Convert.ToBoolean(Bestseller);
            //
            int HotSale  = 0;
            if (Request.Form["HotSale"] != null)
            {
                HotSale = 1;
            }
            record.HotSale = Convert.ToBoolean(HotSale);
            //
            int HotDeals = 0;
            if (Request.Form["HotDeals"] != null)
            {
                HotDeals = 1;
            }
            record.HotDeals = Convert.ToBoolean(HotDeals);
            //
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/Product/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //
            record.Random = Convert.ToBoolean(Random);
            record.Bestseller = Convert.ToBoolean(Bestseller);
            record.HotSale = Convert.ToBoolean(HotSale);
            record.HotDeals = Convert.ToBoolean(HotDeals);
            record.img = img;
            csdl.ProdSales.Add(record);
            csdl.SaveChanges();
            return RedirectToAction("ListProdSale", "ProdSale");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.FormAction = "/Admin/ProdSale/DoEdit/" + id;
            var record = csdl.ProdSales.Where(tbl => tbl.id_prodSale == id).FirstOrDefault();
            return View("EditProdSale", record);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoEdit(FormCollection fc, int id)
        {

            var record = csdl.ProdSales.Where(tbl => tbl.id_prodSale == id).FirstOrDefault();
            record.name = fc["name"];
            //
            record.newprice = 0;
            if (fc["newprice"] != "")
                record.newprice = Convert.ToInt32(fc["newprice"]);
            //
            record.oldprice = 0;
            if (fc["oldprice"] != "")
                record.oldprice = Convert.ToInt32(fc["oldprice"]);
            //
            record.id_Category = Convert.ToInt32(fc["id_Category"]);
            //
            int Random = 0;
            if (Request.Form["Random"] != null)
            {
                Random = 1;
            }
            record.Random = Convert.ToBoolean(Random);
            //
            int Bestseller = 0;
            if (Request.Form["Bestseller"] != null)
            {
                Bestseller = 1;
            }
            record.Bestseller = Convert.ToBoolean(Bestseller);
            //
            int HotSale = 0;
            if (Request.Form["HotSale"] != null)
            {
                HotSale = 1;
            }
            record.HotSale = Convert.ToBoolean(HotSale);
            //
            int HotDeals = 0;
            if (Request.Form["HotDeals"] != null)
            {
                HotDeals = 1;
            }
            record.HotDeals = Convert.ToBoolean(HotDeals);
            //
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/Product/" + record.img)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Assets/Upload/Product/" + record.img));
                }
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/Product/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //
            if (img != "")
            record.img = img;         
            csdl.SaveChanges();
            return RedirectToAction("ListProdSale", "ProdSale");
        }
        public void Delete(int id)
        {
            var record = csdl.ProdSales.Where(tbl => tbl.id_prodSale == id).FirstOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/Product/") + record.img))
            {
                System.IO.File.Delete(Server.MapPath("~/Assets/Upload/Product/" + record.img));
            }
            csdl.ProdSales.Remove(record);
            csdl.SaveChanges();
            Response.Redirect("/Admin/ProdSale/ListProdSale");
        }
    }
}