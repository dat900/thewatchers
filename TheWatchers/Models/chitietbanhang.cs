//------------------------------------------------------------------------------
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
    
    public partial class chitietbanhang
    {
        public string seri { get; set; }
        public string masp { get; set; }
        public Nullable<int> stt_hd { get; set; }
    
        public virtual hoadon_bh hoadon_bh { get; set; }
        public virtual dongho dongho { get; set; }
        public virtual dongho_seri dongho_seri { get; set; }
    }
}