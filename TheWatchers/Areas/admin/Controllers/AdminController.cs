using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Areas.admin.Models;
using TheWatchers.Models;

namespace TheWatchers.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: admin/Home
        public ActionResult Dashboard()
        {
            return View();
        }
       
    }
}