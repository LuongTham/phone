using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Areas.Admin.Models
{
    public class CheckLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            //kiem tra dang nhap
            if (HttpContext.Current.Session["email"] == null)
            {
                //di chuyen den action /Admin/Login
                HttpContext.Current.Response.Redirect("/Admin/Login");
            }
        }
    }
}