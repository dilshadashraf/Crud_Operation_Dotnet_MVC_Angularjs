using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation.Controllers
{
    public class ConveyanceController : Controller
    {
        // GET: Conveyance
        public ActionResult AddConveyance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddConveyanceDetails()
        {
            return View();
        }
    }
}