using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheWatchers.Areas.admin.Models
{
    public class Product
    {
        [Key]
        public string tendh { get; set; }
        public string thuonghieudh { get; set; }
        public string loaidh { get; set; }
        public double? gia { get; set; }
    }
}