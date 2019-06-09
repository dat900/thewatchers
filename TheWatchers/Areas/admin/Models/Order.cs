using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWatchers.Areas.admin.Models
{
    public class Order
    {
        public int id { get; set; }
        public string kh { get; set; }
        public DateTime day { get; set; }
        public int? status { get; set; }
    }
}