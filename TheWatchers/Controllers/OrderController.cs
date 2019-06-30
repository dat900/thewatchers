using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
using TheWatchers.Models.DAO;

namespace TheWatchers.Controllers
{
    public class OrderController : Controller
    {
        //TheWatchersEntities db = new TheWatchersEntities();
        // GET: Order
        public ActionResult Checkout()
        {
            List<Cart> cart = Session["Cart"] as List<Cart>;

            return View(cart);
        }
        [HttpPost]
        public int find_cus(string hoten, string sdt)
        {
            khachhang kh = DAO_user.getCusByNameandPhone(hoten, sdt);
            if (kh == null)
            {
                kh = new khachhang();
                kh.tenkh = hoten;
                kh.sdt_kh = sdt;
                DAO_user.addUser(kh);
                return DAO_user.getAllCus().Count -1;
            }
            return kh.makh;
        }
        public void check_out(FormCollection form)
        {
            donhang dhg = new donhang();
            dhg.id_kh = DAO_user.getCusByNameandPhone(form.Get("name"), form.Get("phone_num")).makh;
            dhg.ngay_dat = DateTime.Now.Date;
            //Lay thong tin dong trong cart de luu
            List<Cart> cart = Session["Cart"] as List<Cart>;
            DAO_order.addOrder(dhg);
            chitietdonhang ctdh = new chitietdonhang();
            foreach (Cart c in cart)
            {
                ctdh.donhang = dhg;
                ctdh.masp = c.idmadh;
                ctdh.soluong = c.iSoluong;
                DAO_orderdetail.addOrderDetail(ctdh);
            }
        }
    }
    
    
}