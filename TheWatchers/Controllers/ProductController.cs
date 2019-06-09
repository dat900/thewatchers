using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWatchers.Models;
using PagedList.Mvc;
using PagedList;
namespace TheWatchers.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        TheWatchersEntities db = new TheWatchersEntities();
        public PartialViewResult NewWatchesPartial()
        {
            
            return PartialView(db.donghoes.OrderBy(n=>n.masp).Take(3).ToList());
        }
        public ActionResult ProductType(string Name)
        {
            if (Name == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<dongho> dhs = db.loais.Where(n => n.ten_loai == Name).Select(n => n.donghoes) as List<dongho>;
            return View(dhs);
        }
        public ActionResult ProductDetail(string  madh)
        {
            dongho dh = db.donghoes.SingleOrDefault(n => n.masp == madh);
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
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            string sKey = form["keysearch"].ToString();
            
            
            IPagedList<dongho> lstkq = db.donghoes.Where(n => n.tensp.Contains(sKey)).OrderBy(n=>n.tensp).ToPagedList(pageNumber, pageSize);
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