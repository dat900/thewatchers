using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWatchers.Models.DAO
{
    public class DAO_user
    {
        static TheWatchersEntities db = new TheWatchersEntities();

        public static void addUser(khachhang kh)
        {
            db.khachhangs.Add(kh);
            db.SaveChanges();
        }
        public static khachhang getCus(int id)
        {
            return db.khachhangs.Where(n => n.makh == id).Single();
        }
        public static List<khachhang> getAllCus()
        {
            return db.khachhangs.ToList();
        }
        public static khachhang getCusByNameandPhone(string name, string phone)
        {
            return db.khachhangs.Where(n => (n.tenkh == name) && (n.sdt_kh == phone)).Single();
        }
        public static void updateCus(khachhang kh)
        {
            db.Entry(kh);
            db.SaveChanges();
        }
    }
}