using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;

namespace TheWatchers.Controllers
{
    public class OrderController : Controller
    {
        TheWatchersEntities db = new TheWatchersEntities();
        // GET: Order
        public ActionResult Checkout()
        {
            List<Cart> cart = Session["Cart"] as List<Cart>;

            return View(cart);
        }
        [HttpPost]
        public int find_cus(string hoten, string sdt)
        {
            int kh_check = -2;
            kh_check = db.khachhangs.Where(n => (n.tenkh == hoten) && (n.sdt_kh == sdt)).SingleOrDefault().makh;
            if (kh_check <=0)
            {
                khachhang kh = new khachhang();
                kh.tenkh = hoten;
                kh.sdt_kh = sdt;
                db.khachhangs.Add(kh);
                db.SaveChanges();
                return db.khachhangs.LastOrDefault().makh;
            }
            return kh_check;
        }
        public void check_out(FormCollection form)
        {
            donhang dhg = new donhang();
            dhg.id_kh = find_cus(form.Get("name"), form.Get("phone_num"));
            dhg.ngay_dat = DateTime.Now.Date;
            //Lay thong tin dong trong cart de luu
            List<Cart> cart = Session["Cart"] as List<Cart>;
            db.donhangs.Add(dhg);
            db.SaveChanges();
            chitietdonhang ctdh = new chitietdonhang();
            foreach (Cart c in cart)
            {
                ctdh.donhang = dhg;
                ctdh.masp = c.idmadh;
                ctdh.soluong = c.iSoluong;
                db.chitietdonhangs.Add(ctdh);
            }
            
            db.SaveChanges();
        }
        public ActionResult Payment()
        {

            return View();
        }
    }
    
    
}