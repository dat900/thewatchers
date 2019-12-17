using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWatchers.Models;
namespace TheWatchers.Models.DAO
{
    public class DAO_product
    {
        static TheWatchersEntities db = new TheWatchersEntities();

        public static List<dongho> getNewProducts(int num)
        {
                List<dongho> list_dh = db.donghoes.Where(n=>n.act == true).Take(num).ToList();
                return list_dh;
        }
        public static dongho get(string id)
        {
            return db.donghoes.Where(n => n.masp == id).Single();
        }
        public static List<dongho> getAll()
        {
            return db.donghoes.OrderBy(n=>n.masp).ToList();
        }
        public static List<dongho> getByName(string key)
        {
            return db.donghoes.Where(n => n.tensp.Contains(key)).ToList();
        }
        public static List<dongho> getByType(string type)
        {
            return db.donghoes.Where(n => n.loai == type).ToList();
        }
        public static void add(dongho dh)
        {
            db.donghoes.Add(dh);
            db.SaveChanges();
        }
        public static void delete(dongho dh)
        {
            db.donghoes.Remove(dh);
            db.SaveChanges();
        }
        public static void update(dongho dh)
        {
            db.Entry(dh);
            db.SaveChanges();
        }
       
    }
}