using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWatchers.Models;
namespace TheWatchers.Models.DAO
{
    public class DAO_orderdetail
    {
        static TheWatchersEntities db = new TheWatchersEntities();

        public static void addOrderDetail(chitietdonhang orderdetail)
        {
            db.chitietdonhangs.Add(orderdetail);
            db.SaveChanges();
        }
        public static List<chitietdonhang> getOrderDetailByIdOrder(int idOrder)
        {
            return db.chitietdonhangs.Where(n => n.id_donhang == idOrder).ToList();
        }

    }
}