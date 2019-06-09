using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
using TheWatchers.Areas.admin.Models;

namespace TheWatchers.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
        TheWatchersEntities db = new TheWatchersEntities();
        [HttpPost]
        public void Login(string username, string password)
        {
            string pass = db.khachhangs.Where(n => n.tenkh == username).Select(n => n.matkhau).ToString();
            if (pass == password)
                {
                    Redirect("../ admin / Home / Index"); 
                }
            else
            {
                Response.StatusCode = 404;
            }
        }
       

    }
}