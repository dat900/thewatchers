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
    
    public partial class nhacungcap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhacungcap()
        {
            this.hoadon_nh = new HashSet<hoadon_nh>();
        }
    
        public string tenncc { get; set; }
        public string diachi_ncc { get; set; }
        public string sdt_ncc { get; set; }
        public int mancc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon_nh> hoadon_nh { get; set; }
    }
}
