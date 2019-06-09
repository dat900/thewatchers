using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
using TheWatchers.Areas.admin.Models;

namespace TheWatchers.Areas.admin.Controllers
{
    public class OrdersController : Controller
    {
        TheWatchersEntities db = new TheWatchersEntities();
        // GET: admin/Order
        public ActionResult Index()
        {
            List<Order> dhg = (from d in db.donhangs
                     join c in db.khachhangs on d.id_kh equals c.makh
                     orderby d.id descending
                     select new Order
                     {
                         id = d.id,
                         kh = c.tenkh,
                         day = d.ngay_dat,
                         status = d.stat
                     }).ToList();
            return View(dhg);
        }
        public ActionResult DeleteOrder(int id_dh, string url)
        {
            donhang dhg = db.donhangs.Where(n=>n.id == id_dh).Single();
            if (dhg == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                dhg.stat = -1;
                db.Entry(dhg);
                db.SaveChanges();
            }
            return Redirect(url);
        }
        public ActionResult Ord_detail(int id_dh)
        {
            List<Ord_detail> ctdh = null;
            donhang dhg = db.donhangs.Where(n => n.id == id_dh).Single();
            if (dhg == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
               ctdh = (from ct in db.chitietdonhangs join w in db.donghoes on ct.masp equals w.masp
                       select new Ord_detail
                       {
                           w_id = ct.masp,
                           w_name = w.tensp,
                           w_brand = w.thuonghieu,
                           w_count = ct.soluong,
                           w_price = w.dongia
                       }).ToList();             
            }
            return View(ctdh);
        }
    }
}