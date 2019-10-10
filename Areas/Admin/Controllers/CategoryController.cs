using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Areas.Admin.Models;
using Phone.Models;
using PagedList;
namespace Phone.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        protected PhoneEntities csdl = new PhoneEntities();
        [CheckLogin]
        public ActionResult ListCategory(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page.HasValue) ? Convert.ToInt32(page) : 1;
            var list_record = csdl.Categories.OrderByDescending(tbl => tbl.id_Category).ToList();
            return View(list_record.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Delete(int id)
        {
            var record = (from tbl in csdl.Categories where tbl.id_Category == id select tbl).FirstOrDefault();
            csdl.Categories.Remove(record);
            csdl.SaveChanges();
            return RedirectToAction("ListCategory", "Category");
        }
        public ActionResult Add()
        {
            ViewBag.FormAction = "/Admin/Category/DoAdd";
            return View("AddCategory");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DoAdd()
        {
            Category record = new Category();
            record.name = Request.Form["name"];
            int hotcategory = 0;
            if (Request.Form["hotcategory"] != null)
            {
                hotcategory = 1;
            }
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/Product/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //
            record.img = img;
            record.hotcategory = Convert.ToBoolean(hotcategory);
            csdl.Categories.Add(record);
            csdl.SaveChanges();
            return RedirectToAction("ListCategory", "Category");
        }
        public ActionResult Edit(int id)
        {
            var record = (from tbl in csdl.Categories where tbl.id_Category == id select tbl).FirstOrDefault();
            ViewBag.FormAction = "/Admin/Category/DoEdit/" + id;
            return View("EditCategory", record);
        }
        public ActionResult DoEdit(int id)
        {
            var record = (from tbl in csdl.Categories where tbl.id_Category == id select tbl).FirstOrDefault();
            record.name = Request.Form["Name"];
            int hotcategory = 0;
            if (Request.Form["hotcategory"] != null)
            {
                hotcategory = 1;
            }
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
            record.hotcategory = Convert.ToBoolean(hotcategory);
            csdl.SaveChanges();
            return RedirectToAction("ListCategory", "Category");
        }
    }
}