using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;

namespace TheWatchers.Areas.admin.Controllers
{
    public class CustomerController : Controller
    {
        TheWatchersEntities db = new TheWatchersEntities();
        // GET: admin/Customer
        public ActionResult Customer_List()
        {
            List<khachhang> list_kh = db.khachhangs.ToList();
            return View(list_kh);
        }

    }
}