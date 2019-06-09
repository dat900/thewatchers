using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWatchers.Areas.admin.Models
{
    public class Ord_detail
    {
        public string w_id { get; set; }
        public string w_name { get; set; }
        public string w_brand { get; set; }
        public int? w_count { get; set; }
        public double? w_price { get; set; }
    }
}