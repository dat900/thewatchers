using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWatchers.Models;
using TheWatchers.Areas.admin.Models;
using System.Web.Mvc;

namespace TheWatchers.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: admin/Product
        TheWatchersEntities db = new TheWatchersEntities();
        public ActionResult Products()
        {

            var products = from dh in db.donghoes
                           where dh.act == true
                           select new Product
                           {
                               tendh = dh.tensp,
                               thuonghieudh = dh.thuonghieu,
                               loaidh = dh.loai,
                               gia = dh.dongia
                           };
            return View(products.ToList());
        }
        public ActionResult Delete_Product(string tendh, string url)
        {
            var check_dh = db.donghoes.Where(n => n.tensp == tendh).FirstOrDefault();
            check_dh.act = false;
            db.Entry(check_dh);
            db.SaveChanges();
            return Redirect(url);
        }
        public ActionResult Edit_Prd(dongho dh, string url)
        {
            db.Entry(dh);
            db.SaveChanges();
            return Redirect(url);
        }
        public ActionResult Prd_detail(string tendh)
        {
            var product = db.donghoes.Where(n => n.tensp == tendh).FirstOrDefault();
            if (product == null)
            {
                Response.StatusCode = 404;
            }
            product.dongia *= 1000;
            return View(product);
        }

    }
}