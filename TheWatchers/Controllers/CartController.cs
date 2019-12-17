using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
namespace TheWatchers.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        TheWatchersEntities db = new TheWatchersEntities();
        public List<Cart> GetCarts()
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (null == carts)
            {
                carts = new List<Cart>();
                Session["Cart"] = carts;
            }
            return carts.ToList();
        }
       [ValidateInput(false)]
        public ActionResult AddToCart(string tensp, string Url)
        {
            dongho check_dh = db.donghoes.SingleOrDefault(n => n.tensp == tensp);
            if (null == check_dh)
            {
                Response.StatusCode = 404;
                
            }
            List<Cart> carts = GetCarts();
            Cart dongho = carts.Find(n => n.idmadh == check_dh.masp);
            if (null == dongho)
            {
                dongho = new Cart(check_dh.masp);
                carts.Add(dongho);
                Session["Cart"] = carts;
            }
            else
            {
                dongho.iSoluong++;

            }
            return RedirectPermanent(Url);
        }
        public ActionResult UpdateCart(Cart cart, string Url)
        {
            dongho check_dh = db.donghoes.Single(n => n.masp == cart.idmadh);
            if (null == check_dh)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> carts = GetCarts();
            Cart dongho = carts.Find(n => n.idmadh == cart.idmadh);
            if (null != dongho)
            {
                dongho.iSoluong = int.Parse(cart.iSoluong.ToString());
            }
            return Redirect(Url);
        }
        public ActionResult DeleteCart(string MaDH, string Url)
        {
            dongho check_dh = db.donghoes.SingleOrDefault(n => n.masp == MaDH);
            if (null == check_dh)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> carts = GetCarts();
            Cart dongho = carts.Find(n => n.idmadh == MaDH);
            if (null != dongho)
            {
                carts.Remove(dongho);
                Session["Cart"] = carts;
            }
            if(carts.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }
            return Redirect(Url);
        }
        
        public ActionResult GetCart()
        {
            if(null == Session["Cart"])
            {
                return RedirectToAction("Index", "Home");
            }
            var carts = GetCarts();
            return View(carts);
        }
        public int CountDH()
        {
            int count = 0;
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (null != carts)
            {
                count = carts.Sum(n => n.iSoluong);
            }
            return count;
        }
        public double Gettotal()
        {
            double total = 0;
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (null != carts)
            {
                total = carts.Sum(n => n.iThanhtien);
            }
            return total;
        }
        public ActionResult CartPartialView()
        {
            ViewBag.TongSL = CountDH();
            return PartialView();
        }
    }
}