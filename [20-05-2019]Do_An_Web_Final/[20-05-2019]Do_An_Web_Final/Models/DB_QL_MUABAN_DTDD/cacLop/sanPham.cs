using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop
{
    public class sanPham
    {
        public int maSanPham { get; set; }
        public int maHangSX { get; set; }
        public String tenSanPham { get; set; }
        public long gia { get; set; }
        public String hinhAnh { get; set; }
        public String ngayDang { get; set; }
        public String moTa { get; set; }

        public sanPham()
        {

        }

        public sanPham(int maSanPham, int maHangSX, String tenSanPham, long gia, String hinhAnh, String ngayDang, String moTa)
        {
            this.maSanPham = maSanPham;
            this.maHangSX = maHangSX;
            this.tenSanPham = tenSanPham;
            this.gia = gia;
            this.hinhAnh = hinhAnh;
            this.ngayDang = ngayDang;
            this.moTa = moTa;
        }
    }
}