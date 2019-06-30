using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWatchers.Models;

namespace TheWatchers.Models.DAO
{
    public class DAO_order
    {
        public static TheWatchersEntities db = new TheWatchersEntities();
        public static void addOrder(donhang order)
        {
            db.donhangs.Add(order);
            db.SaveChanges();
        }
        public static List<donhang> getAllOrdersbyIDCus(int id)
        {
            return db.donhangs.Where(n => n.id_kh == id).ToList();
        }
        public static void deleteOrder(int idDH)
        {
            donhang donhangs = db.donhangs.Where(n => n.id == idDH).Single();
            donhangs.stat = -1;
            db.Entry(donhangs);
            db.SaveChanges();
        }
    }
}