using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Phone.Models;
namespace Phone.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Phone
        PhoneEntities csdl = new PhoneEntities();
        public ActionResult ListProduct(int ?page)
        {
            var ListProduct = csdl.Products.OrderByDescending(tbl => tbl.id_Product).ToList();
            int pageSize = 5;
            int pageIndex = 1;
            if(page.HasValue==true)
            {
                pageIndex = Convert.ToInt32(page);
            }
            return View(ListProduct.ToPagedList(pageIndex, pageSize));//truyen theo thu tu
        }
        public ActionResult Add()
        {
            ViewBag.FormAction = "/Admin/Product/Doadd";
            return View("AddProduct");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoAdd(FormCollection fc)
        {
            Product record = new Product();
            record.name = fc["name"];
            record.price =0;
            if(fc["price"]!="")
                record.price=Convert.ToInt32(fc["price"]);
            record.id_Category = Convert.ToInt32(fc["id_Category"]);
            record.content = fc["content"];
            record.description = fc["description"];
            record.brand_id = Convert.ToInt32(fc["brand_id"]);
            int hotproduct = 0;
            if(Request.Form["hotproduct"]!=null)
            {
                hotproduct = 1;
            }
            record.hotproduct = Convert.ToBoolean(hotproduct);
            //
            string img = "";
            if(Request.Files["img"].FileName!="")
            { 
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/product/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //
            record.img = img;
            csdl.Products.Add(record);
            csdl.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.FormAction = "/Admin/Product/DoEdit/"+id;
            var record = csdl.Products.Where(tbl => tbl.id_Product == id).FirstOrDefault();
            return View("EditProduct",record);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoEdit(FormCollection fc,int id)
        {
            var record = csdl.Products.Where(tbl => tbl.id_Product == id).FirstOrDefault();
            record.name = fc["name"];
            record.price = 0;
            if (fc["price"] != "")
                record.price = Convert.ToInt32(fc["price"]);
            record.id_Category = Convert.ToInt32(fc["id_Category"]);
            record.content = fc["content"];
            record.description = fc["description"];
            record.brand_id = Convert.ToInt32(fc["brand_id"]);
            int hotproduct = 0;
            if (Request.Form["hotproduct"] != null)
            {
                hotproduct = 1;
            }
            record.hotproduct = Convert.ToBoolean(hotproduct);
            //
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/product/" + record.img)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Assets/Upload/product/" + record.img));
                }
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/product/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //
            if (img != "")
                record.img = img;
            csdl.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
        public void Delete(int id)
        {
            var record = csdl.Products.Where(tbl => tbl.id_Product == id).FirstOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/Product/") + record.img))
            {
                System.IO.File.Delete(Server.MapPath("~/Assets/Upload/Product/" + record.img));
            }
            csdl.Products.Remove(record);
            csdl.SaveChanges();
            Response.Redirect("/Admin/Product/ListProduct");
        }
    }
}