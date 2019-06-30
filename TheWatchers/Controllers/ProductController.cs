using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
using PagedList.Mvc;
using PagedList;
using TheWatchers.Models.DAO;
namespace TheWatchers.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //TheWatchersEntities db = new TheWatchersEntities();
        public PartialViewResult NewWatchesPartial()
        {
            List<dongho> list_new = DAO_product.getNewProducts(3);
            return PartialView();
        }
        public ActionResult ProductType(string Name)
        {
            if (Name == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<dongho> dhs = DAO_product.getByType(Name);
            return View(dhs);
        }
        public ActionResult ProductDetail(string  madh)
        {
            dongho dh = DAO_product.get(madh);
            if(dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        [HttpPost]
        public ActionResult Search(FormCollection form, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            string sKey = form["keysearch"].ToString();
            IPagedList<dongho> lstkq = DAO_product.getByName(sKey).ToPagedList(pageNumber, pageSize);
            if (lstkq.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return null;
            }
            ViewBag.Thongbao = "Đã tìm thấy " + lstkq.Count.ToString() + " sản phẩm";
            return View(lstkq);
        }
    }
}