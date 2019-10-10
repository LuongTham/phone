using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Phone.Models;
using System.IO;

namespace Phone.Areas.Admin.Controllers
{

    public class SlideController : Controller
    {
        protected PhoneEntities csdl = new PhoneEntities();
        // GET: Admin/Slide
        public ActionResult ListSlide(int? page)
        {
            var ListSlide = csdl.Slides.OrderByDescending(tbl => tbl.Slide_id).ToList();
            int pageSize = 5;
            int pageIndex = 1;
            if (page.HasValue == true)
            {
                pageIndex = Convert.ToInt32(page);
            }
            return View(ListSlide.ToPagedList(pageIndex, pageSize));//truyen theo thu tu
        }
        public ActionResult AddSlide()
        {
            ViewBag.FormAction = "/Admin/Slide/DoAdd";
            return View("AddSlide");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoAdd(FormCollection fc)
        {
            
            Slide record = new Slide();
            record.name = fc["name"];
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/Slide/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            //if (img != "")
            record.img = img;
            csdl.Slides.Add(record);
            csdl.SaveChanges();
            return RedirectToAction("ListSlide", "Slide");

        }
        public ActionResult Edit(int id)
        {
            ViewBag.FormAction = "/Admin/Slide/DoEdit/" + id;
            var record = csdl.Slides.Where(tbl => tbl.Slide_id == id).FirstOrDefault();
            return View("EditSlide", record);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult DoEdit(FormCollection fc, int id)
        {
            var record = csdl.Slides.Where(tbl => tbl.Slide_id == id).FirstOrDefault();
            record.name = fc["name"];
            string img = "";
            if (Request.Files["img"].FileName != "")
            {
                if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/Slide/" + record.img)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Assets/Upload/Slide/" + record.img));
                }
                img = Request.Files["img"].FileName;
                var duongDanAnh = Server.MapPath("~/Assets/Upload/Slide/" + img);
                Request.Files["img"].SaveAs(duongDanAnh);
            }
            if (img != "")
            record.img = img;
            csdl.SaveChanges();
            return RedirectToAction("ListSlide", "Slide");

        }
        public void Delete(int id)
        {
            var record = csdl.Slides.Where(tbl => tbl.Slide_id == id).FirstOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/Slide/") + record.img))
            {
                System.IO.File.Delete(Server.MapPath("~/Assets/Upload/Slide/" + record.img));
            }
            csdl.Slides.Remove(record);
            csdl.SaveChanges();
            Response.Redirect("/Admin/Slide/ListSlide");
        }

    }
}