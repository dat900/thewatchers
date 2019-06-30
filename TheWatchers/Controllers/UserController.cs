using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;

namespace TheWatchers.Controllers
{
    public class UserController : Controller
    {
        TheWatchersEntities db = new TheWatchersEntities();
        // GET: User
        public ActionResult Index()
        {
            khachhang kh = Session["Taikhoan"] as khachhang;
            if (kh != null)
            {
                ViewBag.TenKH = kh.tenkh.ToString();
            }
            return PartialView();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(khachhang kh)
        {
            db.khachhangs.Add(kh);
            db.SaveChanges();
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginModel model)
        {
            int username = model.username;
            string pass = model.password;
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.makh == username || n.matkhau == pass);
            if (null != kh)
            {
                ViewBag.Thongbao = "Đăng nhập thành công";
                Session["Taikhoan"] = kh;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","Đăng nhập không thành công");
            }
            return View();
        }
        public ActionResult Info(int makh)
        {
            khachhang check_kh = db.khachhangs.Where(n => n.makh == makh).Single();
            if(null == check_kh)
            {
                ViewBag.Thongbao = "Không tìm thấy khách hàng";
                return null;
            }
            return View(check_kh);
        }
        public ActionResult Orders(int makh) 
        {
            List<donhang> check_dh = db.khachhangs.Where(n => n.makh == makh).Select(n => n.donhangs) as List<donhang>;
            if (check_dh.Count == 0)
            {
                ViewBag.Thongbao = "Không có đơn hàng";
                return null;
            }
            return PartialView(check_dh);
        }
    }
}