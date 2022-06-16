using Crud_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Crud_Operation.Models;

namespace Crud_Operation.Controllers
{
    public class LoginController : Controller
    {
        //cshtml
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCheck(tblUser user)
        {
            CrudDBEntities db = new CrudDBEntities();
            //var result2 =  db.tblUsers.Where(a => a.UserName == user.UserName && a.Password == user.Password).Count();// int
            // Any => true/ false
            //var result =  db.tblUsers.Any(a => a.UserName == user.UserName && a.Password == user.Password);            
            //if (result)
            //{
            //    Session["UserName"] = user.UserName.ToString();
            //    return Json(true, "Home");// Redirect to page(Home Controller and Welcome ActionMethod)
            //}

            bool result = false;
            var data = db.tblUsers.SingleOrDefault(a => a.UserName == user.UserName && a.Password == user.Password);//Get the single record
            if (data != null)
            {
                result = true;
                Session["UserType"] = data.UserType;//Store user Type to check pages
                Session["UserName"] = user.UserName.ToString();
                return Json(result, JsonRequestBehavior.AllowGet);// Redirect to page(Home Controller and Welcome ActionMethod)
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}