using Crud_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Crud_Operation.Models;

namespace Crud_Operation.Controllers
{
    public class UserController : Controller
    {
        //By default Get Method
        //To View(HTML) page
        public ActionResult AddUser()
        {
            return View();
        }


        // To submit data in to database
        [HttpPost]
        public JsonResult AddUser(tblUser user)// We will get the data from frontend to user object
        {
            try
            {
                CrudDBEntities db = new CrudDBEntities();// This will come from DataContext folder(Models/CRUDModel.edmx/CRUDModel.Context.tt/CRUDModel.Context.cs)
                user.DateCreated = DateTime.Now;
                user.CreateBy = "SuperAdmin";
                user.IsActive = true;
                db.tblUsers.Add(user);
                db.SaveChanges();// To finally store in database (If we will not write it will not save data in database)

                if (user.UserId > 0)
                {
                    return Json(user.UserId, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Failed. Please try again", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }


                     
        }

        //To create view(HTML) page
        public ActionResult ViewUser()
        {
            return View();
        }

        // To get data from database
        public ActionResult ViewUserDetails()
        {
            CrudDBEntities db = new CrudDBEntities();
            var data = db.tblUsers.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
            //return View();
        }

    }
}