using Crud_Operation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation.Controllers
{
    public class CourseController : Controller
    {
        CrudDBEntities db = new CrudDBEntities();//this is coming from edmx file => Models =>
        // GET: Course
        //For view page
        public ActionResult AddCourse()
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "SuperAdmin")
                {
                    return View();
                }                
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult AddCourseDetail(tblCourse course, HttpPostedFileBase postedFile)//tblCourse table -> have  to add name space
        {
            #region Upload image in Images folder

            //string folderPath = @"D:\CourseImages";//  Assign path as per your drive
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            string path = Server.MapPath("~/CourseImages/");
            if (!string.IsNullOrEmpty(postedFile.FileName))
            {
                //postedFile.SaveAs(path + postedFile.FileName + DateTime.Now); // Save into image folder
                postedFile.SaveAs(path + postedFile.FileName); // Save into image folder
            }
            #endregion

            course.DateCreated = DateTime.Now;
            course.CreatedBy = "Admin";
            course.IsActive = true;
            db.tblCourses.Add(course);

            db.SaveChanges();//To finaaly store into database
            return Content(course.CourseId.ToString());//Return type is string so we have to return only string value
        }

        public ActionResult ViewCourse()
        {
            return View();
        }
    }
}