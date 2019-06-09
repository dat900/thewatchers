using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheWatchers.Models;
namespace TheWatchers.Models
{
    public class Cart
    {
        [Key]
        public string idmadh { get; set; }
        [DisplayName("Tên đồng hồ")]
        public string iTenDH { get; set; }
        [DisplayName("Thương hiệu")]
        public string iThuonghieu { get; set; }
        [DisplayName("Số lượng")]
        public int iSoluong { get; set; }
        [DisplayName("Đơn giá")]
        public double iDongia { get; set; }
        [DisplayName("Thành tiền")]
        public double iThanhtien
        {
            get { return iSoluong * iDongia; }
        }
        TheWatchersEntities db = new TheWatchersEntities();
        public Cart(string MaDH)
        {
            idmadh = MaDH;
            dongho dh = db.donghoes.SingleOrDefault(m=>m.masp==idmadh);
            iTenDH = dh.tensp;
            iThuonghieu = dh.thuonghieu;
            iDongia = double.Parse(dh.dongia.ToString());
            iSoluong = 1;

        }
    }
}