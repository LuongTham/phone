using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public void Index()
        {
            Response.Redirect("/Admin/Home/Index");
        }
    }
}