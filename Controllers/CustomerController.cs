using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phone.Models;

namespace Phone.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        PhoneEntities db = new PhoneEntities();
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["name"] = null;
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult XoaSanPham(int id)
        {
            ShoppingCart objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.RemoveFromCart(id);
                Session["Cart"] = objCart;
            }
            return RedirectToAction("cart");
        }
        // thêm vào giỏ hàng 1 sản phẩm có id = id của sản phẩm
        public ActionResult ThemVaoGioHang(int id)
        {
            var P = db.Products.Where(s => s.id_Product.Equals(id)).SingleOrDefault();
            if (P != null)
            {
                ShoppingCart objCart = (ShoppingCart)Session["Cart"];
                if (objCart == null)
                {
                    objCart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem()
                {
                    ProductName = P.name,
                    ProductID = P.id_Product,
                    Price = Convert.ToString(P.price),
                    Quanlity = 1,
                    img = P.img,
                    Total = Convert.ToDouble(P.price)
                };
                objCart.AddToCart(item);
                Session["Cart"] = objCart;
                return RedirectToAction("Cart",item);
            }
            return View("Cart");
        }
        // cập nhật giỏ hàng theo loại sản phẩm và số lượng
        public ActionResult UpdateQuantity(int proID, int quantity)
        {
            int id = proID;
            ShoppingCart objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.UpdateQuantity(id, quantity);
                Session["Cart"] = objCart;
            }
            return RedirectToAction("cart");
        }
        // giỏ hàng mặc định, nếu session = null thì hiện không có hàng trong giỏ, nếu có thì trả lại list các sản phẩm
        public ActionResult Cart()
        {
            ViewBag.Title = "Giỏ hàng";
            ShoppingCartModels model = new ShoppingCartModels();
            model.Cart = (ShoppingCart)Session["Cart"];
            return View(model);
        }
    }
}