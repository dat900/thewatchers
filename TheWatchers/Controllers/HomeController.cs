﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;

namespace TheWatchers.Controllers
{
    public class HomeController : Controller
    {
        TheWatchersEntities db = new TheWatchersEntities();
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
        
        public ActionResult Login()
        {
           return RedirectToAction("Login", "User");
        }
        public ActionResult Register()
        {
            return RedirectToAction("Register", "User");
        }
    }
}