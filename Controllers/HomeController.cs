using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Welcome()
        {
            if(Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        //ActionResult JsonResult v
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OPRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OPRegistrationAndMail(OutPatient patient)
        {

            //db.OutPatients.Add(patient);
            //db.SaveChanges();
            //if(patient.OutPatientId > 0)
            //{
            //    bool isMailSent=  SentMail(patient.Email);
            //    return Json(true, JsonRequestBehavior.AllowGet);
            //}
            bool isMailSent = SentMail(patient.Email, patient.Disease);
            if (isMailSent)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
            //return Json(true,JsonRequestBehavior.AllowGet);
        }

        public bool SentMail(string To, string disease)
        {
            try
            {
                string from = "clientshad@gmail.com";
                string subject = "Out Patient Registration";
                string body = "Your request has been taken for " + disease + ", Team will connect you soon and schedue your appointment";

                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress(from);
                mail.Subject = subject;
                //string Body = body;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(from, "password"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}