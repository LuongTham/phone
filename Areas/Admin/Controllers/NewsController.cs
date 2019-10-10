using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;
using PagedList;
using System.IO; //Input output tao thu muc xoa file tao file de nhap anh?
namespace Phone.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/Phone
       protected PhoneEntities db = new PhoneEntities();
        public ActionResult ListNews(int? page)
        {
            int pageSize = 5;
            ViewBag.pageSize = pageSize;
            int pageNumber = (page.HasValue) ? Convert.ToInt32(page) : 1;
            var list_record = db.News.OrderByDescending(tbl => tbl.id_News).ToList();
            return View(list_record.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var record = db.News.Where(tbl => tbl.id_News == id).FirstOrDefault();
            ViewBag.formAction = "/Admin/News/DoEdit/" + id;
            return View("EditNews", record);
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        //khi an nut submit thi update ban ghi
        //validateInput(false) cho phep lay gia tri html cua form-control
        public ActionResult DoEdit(int id, FormCollection fc)
        {
            var record = db.News.Where(tbl => tbl.id_News == id).FirstOrDefault();
            string _name = fc["name"];
            string _description = fc["description"];
            int _price = Convert.ToInt32(fc["price"]);
            string _content = fc["content"];
            int _hotnews = 0;
            if (Request.Form["hotnews"] != null)
                _hotnews = 1;
            string img = "";
            //neu user upload anh
            if (Request.Files["img"] != null && Request.Files["img"].ContentLength > 0)
            {
                //xoa anh
                if (record != null)
                {
                    //kiem tra xem file truong field img co ton tai khong
                    if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/News/" + record.img)))
                    {
                        //xoa anh
                        System.IO.File.Delete(Server.MapPath("~/Assets/Upload/News/" + record.img));
                    }
                }
                //lay ten file
                string _fileName = Request.Files["img"].FileName;
                //lay thoi gian gan vao ten file
                var timestamp = DateTime.Now.ToFileTime();
                _fileName = timestamp + "thang" + _fileName;
                //gan ten file vao bien img
                img = _fileName;
                //lay duong dan cua file
                string _path = Path.Combine(Server.MapPath("~/Assets/UpLoad/News"), _fileName);
                //upload file
                Request.Files["img"].SaveAs(_path);
            }
            //them ban ghi vao csdl
            record.price = _price;
            record.name = _name;
            record.description = _description;
            record.content = _content;
            record.hotnews = Convert.ToBoolean(_hotnews);
            if (img != "")
                record.img = img;
            db.SaveChanges();
            return RedirectToAction("ListNews", "News");
        }
        public ActionResult Delete(int id)
        {
            var record = db.News.Where(tbl => tbl.id_News == id).FirstOrDefault();
            //xoa file
            if (record != null)
            {
                //kiem tra xem file truong field img co ton tai khong
                if (System.IO.File.Exists(Server.MapPath("~/Assets/Upload/News/" + record.img)))
                {
                    //xoa anh
                    System.IO.File.Delete(Server.MapPath("~/Assets/Upload/News/" + record.img));
                }
            }
            //xoa ban ghi
            db.News.Remove(record);
            db.SaveChanges();
            return RedirectToAction("ListNews", "News");
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.formAction = "/Admin/News/DoAdd/";
            return View("AddNews");
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult DoAdd(FormCollection fc)
        {
            //Tao moi doi tuong la mot ban ghi
            News record = new News();
            string _name = fc["name"];
            string _description = fc["description"];
            int _price = Convert.ToInt32(fc["price"]);
            string _content = fc["content"];
            int _hotnews = 0;
            if (Request.Form["hotnews"] != null)
                _hotnews = 1;
            string img = "";
            //neu user upload anh
            if (Request.Files["img"] != null && Request.Files["img"].ContentLength > 0)
            {
                /*
                     - Request.Files["img"]!=null -> khi chon anh thi the input type="file" moi khac null
                     - Request.Files["img"].ContentLength -> tra ve dung luong file tinh bang kb
                     - DateTime.Now.ToFileTime() -> chuyen thoi gian ve thanh mot so timestam
                     - Server.MapPath("~/Assets/Upload/Phone") -> tra ve duong dan tuyet doi cua file
                     - Path.Combine(duong dan,tenfile) -> ghep duong dan va file thanh mot duong dan
                     - Request.Files["img"].SaveAs(_path) -> luu anh upload vao duong dan _path chi dinh
                  */
                //lay ten file
                string _fileName = Request.Files["img"].FileName;
                //lay thoi gian gan vao ten file
                var timestamp = DateTime.Now.ToFileTime();
                _fileName = timestamp + "_" + _fileName; //<=>1424242_hello.jpg
                //lay duong dan cua file
                string _path = Path.Combine(Server.MapPath("~/Assets/UpLoad/News"), _fileName);
                //upload file
                Request.Files["img"].SaveAs(_path);
                //gan ten file vao bien img
                img = _fileName;
            }
            record.price = _price;
            record.name = _name;
            record.description = _description;
            record.content = _content;
            record.hotnews = Convert.ToBoolean(_hotnews);
            if (img != "")
                record.img = img;
            db.News.Add(record);
            db.SaveChanges();
            return RedirectToAction("ListNews", "News");
        }
    }
}