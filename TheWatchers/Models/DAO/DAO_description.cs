using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWatchers.Models.DAO
{
    
    public class DAO_description
    {
        static TheWatchersEntities db = new TheWatchersEntities();

        public void add_description(motachitiet mt)
        {
            db.motachitiets.Add(mt);
            db.SaveChanges();
        }
        public void delete_description(motachitiet mt)
        {
            db.motachitiets.Remove(mt);
            db.SaveChanges();
        }
        public void update_description(motachitiet mt)
        {
            db.Entry(mt);
            db.SaveChanges();
        }
        public static motachitiet get_desciption_by_masp(string masp)
        {
            return db.motachitiets.Where(n => n.masp == masp).Single();
        }
    }
}