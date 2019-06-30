using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWatchers.Models;
using TheWatchers.Areas.admin.Models;
using System.Web.Mvc;
using TheWatchers.Models.DAO;

namespace TheWatchers.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: admin/Product
        //TheWatchersEntities db = new TheWatchersEntities();
        public ActionResult Products()
        {
            List<dongho> list_new_prod = DAO_product.getAll();
            return View(list_new_prod);
        }
        public ActionResult Delete_Product(string tendh, string url)
        {
            dongho check_dh = DAO_product.getByName(tendh).First();
            if (check_dh != null) DAO_product.delete(check_dh);
            return Redirect(url);
        }
        public ActionResult Edit_Prd(dongho dh, string url)
        {
            DAO_product.update(dh);
            return Redirect(url);
        }
        public ActionResult Prd_detail(string tendh)
        {
            dongho product = DAO_product.getByName(tendh).First();
            product.dongia *= 1000;
            return View(product);
        }
    }
}