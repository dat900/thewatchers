﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheWatchers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class motachitiet
    {
        public string masp { get; set; }
        [DisplayName("Màu sắc:")]
        public string mausac { get; set; }
        [DisplayName("Bảo hành:")]
        public Nullable<int> baohanh { get; set; }
        [DisplayName("Chất liệu:")]
        public string khung { get; set; }
        [DisplayName("Mô tả chung:")]
        public string mota { get; set; }
    
        public virtual dongho dongho { get; set; }
    }
}
